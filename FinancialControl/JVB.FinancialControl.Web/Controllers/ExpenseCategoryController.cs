using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class ExpenseCategoryController : BaseController
    {
        private readonly IExpenseCategoryAppService _expenseCategoryAppService;

        public ExpenseCategoryController(IExpenseCategoryAppService expenseCategoryAppService)
        {
            _expenseCategoryAppService = expenseCategoryAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _expenseCategoryAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _expenseCategoryAppService.GetById(id.Value);

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
        public async Task<IActionResult> Create(ExpenseCategoryViewModel expenseCategoryViewModel)
        {
            if (!ModelState.IsValid) return View(expenseCategoryViewModel);

            if (ResponseHasErrors(await _expenseCategoryAppService.Register(expenseCategoryViewModel)))
                return View(expenseCategoryViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _expenseCategoryAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(ExpenseCategoryViewModel expenseCategoryViewModel)
        {
            if (!ModelState.IsValid) return View(expenseCategoryViewModel);

            if (ResponseHasErrors(await _expenseCategoryAppService.Update(expenseCategoryViewModel)))
                return View(expenseCategoryViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var expenseCategoryViewModel = await _expenseCategoryAppService.GetById(id.Value);

            if (expenseCategoryViewModel == null) return NotFound();

            return View(expenseCategoryViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _expenseCategoryAppService.Remove(id)))
                return View(await _expenseCategoryAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }
    }
}