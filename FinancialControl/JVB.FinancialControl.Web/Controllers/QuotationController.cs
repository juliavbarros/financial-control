using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JVB.FinancialControl.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class QuotationController : BaseController
    {
        //private readonly ICurrencyAppService _currencyAppService;
        //private readonly IEcbService _ecbService;

        //public QuotationController(IEcbService ecbService)
        //{
        //    _ecbService = ecbService;
        //}

        //[AllowAnonymous]
        //[HttpGet("Index")]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _projectAppService.GetAll());
        //}
    }
}