using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Route("[controller]")]
    public class QuotationController : BaseController
    {
        private readonly IQuotationAppService _quotationAppService;

        public QuotationController(IQuotationAppService quotationAppService)
        {
            _quotationAppService = quotationAppService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _quotationAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(QuotationViewModel quotationViewModel)
        {
            if (!ModelState.IsValid) return View(quotationViewModel);

            if (ResponseHasErrors(await _quotationAppService.Register(quotationViewModel)))
                return View(quotationViewModel);

            return RedirectToAction("Index");
        }
    }
}