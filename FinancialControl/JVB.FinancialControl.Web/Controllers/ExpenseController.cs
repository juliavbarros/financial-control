using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class ExpenseController : BaseController
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly IExpenseCategoryAppService _expenseCategoryAppService;

        public ExpenseController(IExpenseAppService expenseAppService, IExpenseCategoryAppService expenseCategoryAppService)
        {
            _expenseAppService = expenseAppService;
            _expenseCategoryAppService = expenseCategoryAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _expenseAppService.GetExpenseTable(2));
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _expenseAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ExpenseViewModel expenseViewModel)
        {
            if (!ModelState.IsValid) return View(expenseViewModel);

            if (ResponseHasErrors(await _expenseAppService.Register(expenseViewModel)))
                return View(expenseViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpPost("AddOrUpdateExpense")]
        public async Task<IActionResult> AddOrUpdateExpense(int month, int categoryId, string? expenseId, decimal enteredValue)
        {
            var expenseViewModel = new ExpenseViewModel
            {
                Value = Convert.ToDecimal(enteredValue),
                ExpenseCategoryId = Convert.ToInt32(categoryId),
                UserId = 2,
                Date =new DateTime(DateTime.Now.Year, Convert.ToInt32(month), 1),
            };

            if (string.IsNullOrEmpty(expenseId))
            {
                if (ResponseHasErrors(await _expenseAppService.Register(expenseViewModel)))
                    return Json(true);
            }
            else
            {
                expenseViewModel.Id = Convert.ToInt32(expenseId);
                if (ResponseHasErrors(await _expenseAppService.Update(expenseViewModel)))
                    return Json(true);
            }

            return Json(true);
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _expenseAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(ExpenseViewModel expenseViewModel)
        {
            if (!ModelState.IsValid) return View(expenseViewModel);

            if (ResponseHasErrors(await _expenseAppService.Update(expenseViewModel)))
                return View(expenseViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var expenseViewModel = await _expenseAppService.GetById(id.Value);

            if (expenseViewModel == null) return NotFound();

            return View(expenseViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _expenseAppService.Remove(id)))
                return View(await _expenseAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("GetRevenueExpensesData")]
        public async Task<IActionResult> GetRevenueExpensesData()
        {

            var dataset1Data = await _expenseAppService.GetRevenueExpensesData();

            var chartData = new
            {
                datasets = new[] {
                new{data = dataset1Data.Expenses},
                new{data = dataset1Data.Revenues}
                }
            };


            return Json(chartData);
        }
    }
}