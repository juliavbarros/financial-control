using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Web.Models;
using JVB.FinancialControl.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JVB.FinancialControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpenseAppService _expenseAppService;


        public HomeController(ILogger<HomeController> logger, IExpenseAppService expenseAppService)
        {
            _logger = logger;
            _expenseAppService = expenseAppService;
        }

        public async Task<IActionResult> Index()
        {
            int savingTypeId = 10;
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var expenses = await _expenseAppService.GetByUserId(userId);
            ViewBag.LastMonth = expenses.Where(x => x.Date.Month == DateTime.Now.AddMonths(-1).Month).Sum(x => x.Value);
            ViewBag.CurrentMonth = expenses.Where(x => x.Date.Month == DateTime.Now.Month).Sum(x => x.Value);
            ViewBag.TotalYear = expenses.Where(x => x.Date.Year == DateTime.Now.Year).Sum(x => x.Value);
            ViewBag.TotalSaving = expenses.Where(x => x.Date.Year == DateTime.Now.Year && x.ExpenseCategoryId == savingTypeId).Sum(x => x.Value);
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