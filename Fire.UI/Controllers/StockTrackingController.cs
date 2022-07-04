using Fire.Business.Abstrack;
using Fire.Business.Encryption;
using Fire.Entity.Concrete;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{

    public class StockTrackingController : Controller
    {
        private readonly IStockTrackingService _stockTrackingService;
        private readonly IProductTypeService _productTypeService;
        public StockTrackingController(IProductTypeService productTypeService, IStockTrackingService stockTrackingService)
        {
            _stockTrackingService = stockTrackingService;
            _productTypeService = productTypeService;
        }
        [HttpGet]
        public IActionResult List()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View(new AllLayoutViewModel
            {
                productTypes = _productTypeService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult StockUpdate(string id)
        {
            var stockid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var stock = _stockTrackingService.GetStockByProductId(Convert.ToInt32(stockid), Convert.ToInt32(keys.branchid));
            var product = _productTypeService.GetById(Convert.ToInt32(stockid));
            return View(new AllLayoutViewModel
            {
                stockTracking = stock,
                ProductType=product,
            });
        }
        [HttpPost]
        public IActionResult StockUpdate(AllLayoutViewModel model, object s)
        {

            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var productid = HttpContext.Request.RouteValues["id"];
            var id = CommondMethod.ConvertDecrypt(productid.ToString());
            var product = _productTypeService.GetById(Convert.ToInt32(id));
            var entity = _stockTrackingService.GetStockByProductId(Convert.ToInt32(id),Convert.ToInt32(keys.branchid));
            if (entity != null)
            {
                entity.totalkg = model.stockTracking.totalkg;
                entity.ModifyDate = DateTime.Today;
                _stockTrackingService.Update(entity);
            }
            else
            {
                var valueentity = new StockTracking
                {
                    CreatedDate = DateTime.Today,
                    ModifyDate = DateTime.Today,
                    productid = Convert.ToInt32(productid),
                    totalkg = model.stockTracking.totalkg,
                    İsDelete = false,
                    branchid=Convert.ToInt32(keys.branchid)
                    };
                _stockTrackingService.Create(valueentity);
            }
            return RedirectToAction("List");
        }
    }
}
