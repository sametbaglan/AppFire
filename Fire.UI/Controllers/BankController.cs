using Fire.Business.Abstrack;
using Fire.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        public IActionResult List()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View();
        }
    }
}
