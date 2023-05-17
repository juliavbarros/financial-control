using JVB.FinancialControl.Common.Login;
using JVB.FinancialControl.Web.Models;
using JVB.FinancialControl.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JVB.FinancialControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEcbService _ecbService;

        public HomeController(ILogger<HomeController> logger, IEcbService ecbService)
        {
            _logger = logger;
            _ecbService = ecbService;
        }

        public IActionResult Index()
        {
            //var test = await _ecbService.ConvertCurrency("5000", "EUR", "USD");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}