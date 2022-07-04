using Fire.Business.Abstrack;
using Fire.Business.Encryption;
using Fire.Entity.Concrete;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{
    public class CheckController : Controller
    {
        private readonly ICheckService _checkService;
        private readonly IBankService _bankService;
        private readonly ICustomerService _customerService;
        private readonly IFactoryService _factoryService;
        public CheckController(ICustomerService customerService, IBankService bankService, IFactoryService factoryService, ICheckService checkService)
        {
            _checkService = checkService;
            _bankService = bankService;
            _factoryService = factoryService;
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var check = _checkService.GetCheckByBranchid(Convert.ToInt32(keys.branchid));
            ViewBag.results = check;
            return View(new AllLayoutViewModel
            {
                ChecksList = check
            }); ;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var banklist = _bankService.GetAll();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var bank in banklist)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = bank.name,
                    Value = bank.id.ToString()
                });
            }
            ViewBag.banklist = selectListItems;
            return View(new AllLayoutViewModel());
        }
        [HttpPost]
        public IActionResult Add(AllLayoutViewModel model)
        {
            var id = HttpContext.Request.RouteValues["id"];
            var Authorization = HttpContext.Session.GetString("token");
            id = CommondMethod.ConvertDecrypt(id.ToString());
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var banklist = _bankService.GetAll();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var bank in banklist)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = bank.name,
                    Value = bank.id.ToString()
                });
            }
            ViewBag.banklist = selectListItems;
            var checkserialnumber = _checkService.GetCheckBySerialNumber(model.check.checkNumber);
            if (checkserialnumber != null)
                ViewBag.error = "Bu Serial Numaraya ait çek mevcuttur."; return View(new AllLayoutViewModel());
            var entity = new Check
            {
                bankid = model.bank.id,
                branchid = Convert.ToInt32(keys.branchid),
                checkDate = model.check.checkDate,
                checkNumber = model.check.checkNumber,
                CreatedDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                price = model.check.price,
                toWhoWasGiven = 0,
                whoFromGetted = Convert.ToInt32(id),
                İsDelete = false,

            };
            _checkService.Create(entity);
            return RedirectToAction("GetList");
        }
        [HttpGet]
        public IActionResult CheckGive(string id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            HttpContext.Session.SetString("checkkey", id.ToString());
            var givelist = _checkService.GetEmptyCheckByGiveNumber(Convert.ToInt32(keys.branchid), 0);
            ViewBag.results = givelist;
            return View(new AllLayoutViewModel
            {
                ChecksList = givelist
            });
        }
        [HttpPost]
        public IActionResult CheckGive(int id, int a)
        {
            var customerid = HttpContext.Session.GetString("checkkey");
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _checkService.GetById(id);
            value.toWhoWasGiven = Convert.ToInt32(CommondMethod.ConvertDecrypt(customerid.ToString()));
            value.ModifyDate = DateTime.Today;
            _checkService.Update(value);
            return RedirectToAction("List", "Customer");
        }
        [HttpGet]
        public IActionResult CheckOfCustomer(string id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var customerid = CommondMethod.ConvertDecrypt(id);
            var checklist = _checkService.GetEmptyCheckByGiveNumber(Convert.ToInt32(keys.branchid), Convert.ToInt32(customerid));
            ViewBag.results = checklist;
            return View(new AllLayoutViewModel
            {
                ChecksList = checklist
            });
        }
    }
}
