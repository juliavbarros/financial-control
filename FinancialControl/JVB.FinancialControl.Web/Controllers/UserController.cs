using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly IUserTypeAppService _userTypeAppService;

        public UserController(IUserAppService userAppService, IUserTypeAppService userTypeAppService)
        {
            _userAppService = userAppService;
            _userTypeAppService = userTypeAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _userAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userViewModel = await _userAppService.GetById(id.Value);

            if (userViewModel == null) return NotFound();

            return View(userViewModel);
        }

        [AllowAnonymous]
        [HttpGet("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.UserTypeList = await _userTypeAppService.GetAll();
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            ViewBag.UserTypeList = await _userTypeAppService.GetAll();
            if (!ModelState.IsValid) return View(userViewModel);

            if (ResponseHasErrors(await _userAppService.Register(userViewModel)))
                return View(userViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userViewModel = await _userAppService.GetById(id.Value);

            if (userViewModel == null) return NotFound();

            ViewBag.UserTypeList = await _userTypeAppService.GetAll();

            return View(userViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            ViewBag.UserTypeList = await _userTypeAppService.GetAll();

            if (!ModelState.IsValid) return View(userViewModel);

            if (ResponseHasErrors(await _userAppService.Update(userViewModel)))
                return View(userViewModel);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userViewModel = await _userAppService.GetById(id.Value);

            if (userViewModel == null) return NotFound();

            return View(userViewModel);
        }

        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ResponseHasErrors(await _userAppService.Remove(id)))
                return View(await _userAppService.GetById(id));

            ViewBag.Sucesso = "User Removed!";
            return RedirectToAction("Index");
        }
    }
}