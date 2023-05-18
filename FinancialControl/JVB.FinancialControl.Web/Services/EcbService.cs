using JVB.FinancialControl.Web.Extensions;
using JVB.FinancialControl.Web.Models.Ecb;
using JVB.FinancialControl.Web.Models.Ecb.ViewModel;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Xml.Serialization;

namespace JVB.FinancialControl.Web.Services
{
    public interface IEcbService
    {
        Task<decimal> ConvertCurrency(string fromAmount, string fromCurrency, string toCurrency);
        Task<decimal> GetLatestRateForCurrency(string currency);
    }

    public class EcbService : IEcbService
    {
        private readonly HttpClient _httpClient;
        private List<EcbCurrencyViewModel> currencyList { get; set; }

        private DateTime lastUpdate { get; set; }

        public EcbService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(appSettings.Value.CurrencyDataSourceUrl);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
        }

        public async Task<decimal> ConvertCurrency(string fromAmount, string fromCurrency, string toCurrency)
        {
            var fromRate = await GetLatestRateForCurrency(fromCurrency);
            var toRate = await GetLatestRateForCurrency(toCurrency);
            var amount = Convert.ToDecimal(fromAmount, new CultureInfo("en-US"));
            decimal convertedValue = amount / fromRate * toRate;
            return Math.Round(convertedValue, 2);
        }

        public async Task<List<EcbCurrencyViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync("stats/eurofxref/eurofxref-hist-90d.xml");

            return await ParseEnvelopeToCurrencyAsync(response);
        }

        public async Task<decimal> GetLatestRateForCurrency(string currency)
        {
            if (currency.ToLower() == "eur")
            {
                return 1;
            }
            await UpdateCurrencies();
            var rate = currencyList.Single(x => x.Name.ToLower() == currency.ToLower()).Rates.OrderByDescending(x => x.Timestamp).First().Rate;
            return rate;
        }

        private async Task UpdateCurrencies()
        {
            var cacheDurationInMinutes = Convert.ToInt32(10);

            var isCacheExpired = DateTime.Now.Subtract(lastUpdate) > TimeSpan.FromMinutes(cacheDurationInMinutes);

            if (currencyList != null && isCacheExpired == false)
                return;

            currencyList = await GetAll();

            lastUpdate = DateTime.Now;
        }

        private async Task<List<EcbCurrencyViewModel>> ParseEnvelopeToCurrencyAsync(HttpResponseMessage response)
        {
            var envelope = await ParseHttpResponseToEnvelope(response);

            var currencyResult = new List<EcbCurrencyViewModel>();
            foreach (var TimestampWithList in envelope.Cube.Cube)
            {
                var timestamp = Convert.ToDateTime(TimestampWithList.Time);
                foreach (var RateWithCurrency in TimestampWithList.Cube)
                {
                    var name = RateWithCurrency.Currency;
                    var rate = Convert.ToDecimal(RateWithCurrency.Rate, new CultureInfo("en-US"));

                    var currentCurency = currencyResult.SingleOrDefault(x => x.Name == name);
                    if (currentCurency == null)
                    {
                        currentCurency = new EcbCurrencyViewModel { Name = name, Rates = new List<CurrencyRateViewModel>() };
                        currencyResult.Add(currentCurency);
                    }
                    currentCurency.Rates.Add(new CurrencyRateViewModel() { Rate = rate, Timestamp = timestamp });
                }
            }
            return currencyResult;
        }

        private async Task<Envelope> ParseHttpResponseToEnvelope(HttpResponseMessage rawCurrencyList)
        {
            var stringCurrencyList = await rawCurrencyList.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(Envelope));
            Envelope result;
            using (TextReader reader = new StringReader(stringCurrencyList))
            {
                result = (Envelope)serializer.Deserialize(reader);
            }
            return result;
        }

       
    }
}