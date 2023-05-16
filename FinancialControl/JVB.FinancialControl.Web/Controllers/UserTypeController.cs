using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserTypeController : BaseController
    {
        private readonly IUserTypeAppService _userTypeAppService;

        public UserTypeController(IUserTypeAppService userTypeAppService)
        {
            _userTypeAppService = userTypeAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _userTypeAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _userTypeAppService.GetById(id.Value);

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
        public async Task<IActionResult> Create(UserTypeViewModel userTypeViewModel)
        {
            if (!ModelState.IsValid) return View(userTypeViewModel);

            if (ResponseHasErrors(await _userTypeAppService.Register(userTypeViewModel)))
                return View(userTypeViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _userTypeAppService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(UserTypeViewModel userTypeViewModel)
        {
            if (!ModelState.IsValid) return View(userTypeViewModel);

            if (ResponseHasErrors(await _userTypeAppService.Update(userTypeViewModel)))
                return View(userTypeViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userTypeViewModel = await _userTypeAppService.GetById(id.Value);

            if (userTypeViewModel == null) return NotFound();

            return View(userTypeViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _userTypeAppService.Remove(id)))
                return View(await _userTypeAppService.GetById(id));

            ViewBag.Sucesso = "Projeto removido!";
            return RedirectToAction("Index");
        }
    }
}