using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Common.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JVB.FinancialControl.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public IActionResult Login(string returnUrl = "/")
        {
            LoginViewModel loginModel = new LoginViewModel();
            loginModel.ReturnUrl = returnUrl;
            return View(loginModel);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _accountAppService.Login(loginViewModel);

            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, string.Format("{0} {1}", user.FirstName, user.LastName)),
                    new Claim(ClaimTypes.Role, user.UsertTypeName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties()
                    {
                        IsPersistent = loginViewModel.RememberLogin
                    });
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Credenciais Inválidas";
                return View(loginViewModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}