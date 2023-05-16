using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class TaxController : BaseController
    {
        private readonly ITaxAppService _taxAppService;

        public TaxController(ITaxAppService taxAppService)
        {
            _taxAppService = taxAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _taxAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _taxAppService.GetById(id.Value);

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
        public async Task<IActionResult> Create(TaxViewModel taxViewModel)
        {
            if (!ModelState.IsValid) return View(taxViewModel);

            if (ResponseHasErrors(await _taxAppService.Register(taxViewModel)))
                return View(taxViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _taxAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(TaxViewModel taxViewModel)
        {
            if (!ModelState.IsValid) return View(taxViewModel);

            if (ResponseHasErrors(await _taxAppService.Update(taxViewModel)))
                return View(taxViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var taxViewModel = await _taxAppService.GetById(id.Value);

            if (taxViewModel == null) return NotFound();

            return View(taxViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _taxAppService.Remove(id)))
                return View(await _taxAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }
    }
}