using Fire.Business.Abstrack;
using Fire.Entity.Concrete;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IProductQuantityService _productQuantityService;
        private readonly IFactoryQuantityService _factoryQuantityService;
        public ReportController(IProductQuantityService productQuantityService, IFactoryQuantityService factoryQuantityServic)
        {
            _factoryQuantityService = factoryQuantityServic;
            _productQuantityService = productQuantityService;
        }

        [HttpGet]
        public IActionResult DailyReport()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View(new AllLayoutViewModel());
        }
        [HttpPost]
        public IActionResult DailyReport(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _productQuantityService.GetMostReportByDate(model.productQuantity.CreatedDate, model.productQuantity.ModifyDate, Convert.ToInt32(keys.branchid));
            var quantityGroups = value.GroupBy(x => x.Name);
            var quantityList = new List<ProductQuantity>();
            foreach (var item in quantityGroups)
            {
                decimal totalkg = 0;
                int customerid = 0;
                foreach (var key in item)
                {
                    totalkg += key.Kg;
                    customerid = key.customerid;
                }
                var entity = new ProductQuantity
                {
                    Name = item.Key,
                    Totalkg = totalkg,
                    customerid = customerid
                };
                quantityList.Add(entity);
            }
            var val = quantityList.OrderByDescending(x => x.Totalkg).Select(x => new ProductQuantity
            {
                Totalkg = x.Totalkg,
                Name = x.Name,
                customerid = x.customerid
            }).ToList();
            return View(new AllLayoutViewModel
            {
                productQuantities = val
            });

        }
        [HttpGet]
        public IActionResult FactoryReport()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View(new AllLayoutViewModel());
        }
        [HttpPost]
        public IActionResult FactoryReport(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _factoryQuantityService.GetMostReportByDate(model.Factory.CreatedDate, model.Factory.ModifyDate, Convert.ToInt32(keys.branchid));
            var quantityGroups = value.GroupBy(x => x.Name);
            var quantityList = new List<FactoryQuantity>();
            foreach (var item in quantityGroups)
            {
                decimal totalkg = 0;
                int customerid = 0;
                foreach (var key in item)
                {
                    totalkg += key.Kg;
                    customerid = key.factoryid;
                }
                var entity = new FactoryQuantity
                {
                    Name = item.Key,
                    Totalkg = totalkg,
                    factoryid = customerid
                };
                quantityList.Add(entity);
            }
            var val = quantityList.OrderByDescending(x => x.Totalkg).Select(x => new FactoryQuantity
            {
                Totalkg = x.Totalkg,
                Name = x.Name,
                factoryid = x.factoryid
            }).ToList();
            return View(new AllLayoutViewModel
            {
                factoryQuantities = val
            });
        }
    }
}
