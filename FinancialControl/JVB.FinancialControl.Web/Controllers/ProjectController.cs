using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProjectController : BaseController
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _projectAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _projectAppService.GetById(id.Value);

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
        public async Task<IActionResult> Create(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return View(projectViewModel);

            if (ResponseHasErrors(await _projectAppService.Register(projectViewModel)))
                return View(projectViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _projectAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return View(projectViewModel);

            if (ResponseHasErrors(await _projectAppService.Update(projectViewModel)))
                return View(projectViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var projectViewModel = await _projectAppService.GetById(id.Value);

            if (projectViewModel == null) return NotFound();

            return View(projectViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _projectAppService.Remove(id)))
                return View(await _projectAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }
    }
}