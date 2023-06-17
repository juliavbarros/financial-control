using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class QuotationController : BaseController
    {
        private readonly IQuotationAppService _quotationAppService;
        private readonly ICurrencyAppService _currencyAppService;
        private readonly IEcbService _ecbService;

        public QuotationController(
            IQuotationAppService quotationAppService,
            ICurrencyAppService currencyAppService,
            IEcbService ecbService)
        {
            _quotationAppService = quotationAppService;
            _currencyAppService = currencyAppService;
            _ecbService = ecbService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.CurrencyList = await _currencyAppService.GetAll();

            return View((await _quotationAppService.GetAll()).Where(x=> x.UserId == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))).OrderByDescending(x => x.Id));
        }

        [AllowAnonymous]
        [HttpGet("ConvertCurrency")]
        public async Task<IActionResult> ConvertCurrency(string value, string fromCurrency, string toCurrency)
        {
            value = value.Replace(".", string.Empty).Replace(",", string.Empty);
            var convertedValue = await _ecbService.ConvertCurrency(value, fromCurrency, toCurrency); ;

            return Json(convertedValue.ToString("N2"));
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string initialValue, string convertedValue, string fromCurrency, string fromCurrencyId, string toCurrencyId, string userId)
        {
            var quotationViewModel = new QuotationViewModel
            {
                InitialValue = Convert.ToDecimal(initialValue),
                ConvertedValue = Convert.ToDecimal(convertedValue),
                FromCurrencyId = Convert.ToInt32(fromCurrencyId),
                ToCurrencyId = Convert.ToInt32(toCurrencyId),
                UserId = Convert.ToInt32(userId),
                QuotationDate = DateTime.Now,
                Rate = await _ecbService.GetLatestRateForCurrency(fromCurrency)
            };

            if (ResponseHasErrors(await _quotationAppService.Register(quotationViewModel)))
                return Json(new { success = false, error = "Erro ao salvar informações, por favor contate administrador" });

            return Json(new { success = true });
        }
    }
}