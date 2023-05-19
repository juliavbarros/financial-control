using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class GoalController : BaseController
    {
        private readonly IGoalAppService _goalAppService;

        public GoalController(IGoalAppService goalAppService)
        {
            _goalAppService = goalAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _goalAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _goalAppService.GetById(id.Value);

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
        public async Task<IActionResult> Create(GoalViewModel goalViewModel)
        {
            if (!ModelState.IsValid) return View(goalViewModel);

            if (ResponseHasErrors(await _goalAppService.Register(goalViewModel)))
                return View(goalViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _goalAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(GoalViewModel goalViewModel)
        {
            if (!ModelState.IsValid) return View(goalViewModel);

            if (ResponseHasErrors(await _goalAppService.Update(goalViewModel)))
                return View(goalViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var goalViewModel = await _goalAppService.GetById(id.Value);

            if (goalViewModel == null) return NotFound();

            return View(goalViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _goalAppService.Remove(id)))
                return View(await _goalAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }
    }
}