using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class GoalCategoryController : BaseController
    {
        private readonly IGoalCategoryAppService _goalCategoryAppService;

        public GoalCategoryController(IGoalCategoryAppService goalCategoryAppService)
        {
            _goalCategoryAppService = goalCategoryAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _goalCategoryAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _goalCategoryAppService.GetById(id.Value);

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
        public async Task<IActionResult> Create(GoalCategoryViewModel goalCategoryViewModel)
        {
            if (!ModelState.IsValid) return View(goalCategoryViewModel);

            if (ResponseHasErrors(await _goalCategoryAppService.Register(goalCategoryViewModel)))
                return View(goalCategoryViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _goalCategoryAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(GoalCategoryViewModel goalCategoryViewModel)
        {
            if (!ModelState.IsValid) return View(goalCategoryViewModel);

            if (ResponseHasErrors(await _goalCategoryAppService.Update(goalCategoryViewModel)))
                return View(goalCategoryViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var goalCategoryViewModel = await _goalCategoryAppService.GetById(id.Value);

            if (goalCategoryViewModel == null) return NotFound();

            return View(goalCategoryViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _goalCategoryAppService.Remove(id)))
                return View(await _goalCategoryAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }
    }
}