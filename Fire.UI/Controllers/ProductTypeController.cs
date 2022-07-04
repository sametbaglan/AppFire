using Fire.Business.Abstrack;
using Fire.Business.Encryption;
using Fire.Entity.Concrete;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IProductQuantityService _productCategoriaService;
        private readonly IProductQuantityService _productQuantityService;
        private readonly IStockTrackingService _stockTrackingService;
        private readonly IPaymentContService _paymentContService;
        public ProductTypeController(IPaymentContService paymentContService,IStockTrackingService stockTrackingService, IProductQuantityService productQuantityService
            , IProductQuantityService productCategoriaService, IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
            _productCategoriaService = productCategoriaService;
            _productQuantityService = productQuantityService;
            _stockTrackingService = stockTrackingService;
            _paymentContService = paymentContService;
        }
        [HttpGet]
        public IActionResult ProductTypeAdd()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View();
        }
        [HttpPost]
        public IActionResult ProductTypeAdd(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var entity = new ProductType
            {
                CreatedDate = DateTime.Now,
                kgPrice = Convert.ToDecimal(model.ProductType.kgPrice.ToString().Replace(",", ".")),
                ModifyDate = DateTime.Now,
                Name = model.ProductType.Name,
                İsDelete = false
            };
            _productTypeService.Create(entity);
            return RedirectToAction("List");
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
        public IActionResult Update(string id)
        {
            var productid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var productcategoria = _productTypeService.GetById(Convert.ToInt32(productid));
            return View(new AllLayoutViewModel
            {
                ProductType = productcategoria
            });
        }
        [HttpPost]
        public IActionResult Update(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var productid = HttpContext.Request.RouteValues["id"];
            var product = _productTypeService.GetById(Convert.ToInt32(productid));
            product.Name = model.ProductType.Name;
            product.kgPrice = model.ProductType.kgPrice;
            product.ModifyDate = System.DateTime.Now;
            _productTypeService.Update(product);
            return RedirectToAction("List");
        }
        [HttpGet]
        public List<ProductType> GetAll()
        {

            var ds = _productTypeService.GetAll();
            return ds;
        }
        [HttpPost]
        public List<string> deneme()
        {
            var asdasd = _productTypeService.GetAll();
            //obje türünde session doldurmak
            HttpContext.Session.SetString("sessionProductType", JsonConvert.SerializeObject(asdasd));
            JsonConvert.SerializeObject(asdasd);
            List<string> dd = new List<string>();
            foreach (var item in asdasd)
            {
                dd.Add(item.Name + "," + item.kgPrice);
            }
            return dd;
        }
        [HttpPost]
        public IActionResult ekle(AllLayoutViewModel model)
        {
            if (model.Factory.CreatedDate.Year == 0001)
                model.Factory.CreatedDate = DateTime.Now;
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var customerid = HttpContext.Session.GetString("customerid");
            HttpContext.Session.SetString("customerid", "");
            int id = Convert.ToInt32(customerid);
            var quantitylist = _productQuantityService.GetProductQuantitiesByCustomerid(id,Convert.ToInt32(keys.branchid));
            var valuedate = quantitylist.Where(x => x.CreatedDate == DateTime.Today).FirstOrDefault();
            int quantity = 0;
            decimal totalkg = 0;
            decimal totalprice = 0;
            if (valuedate != null)
                quantity = valuedate.dailyTakeCount + 1;
            else
                quantity += 1;
             
            var gelenform = HttpContext.Request.Form.ToList().Where(x => x.Value != "0" && x.Key != "__RequestVerificationToken"&&x.Key!= "Factory.CreatedDate"&&x.Value.Count>1).ToList();
            for (int i = 0; i < gelenform.Count; i++)
            {
                string key = gelenform[i].Key.ToString();
                var value = gelenform[i].Value.ToList();
                string[] arra = key.Split(',');
                var keyname = arra[0];
                var keyvalue = arra[1];
                var s = keyvalue.ToString().IndexOf("_");
                keyvalue = keyvalue.Remove(s);
              
                var productypeid = _productTypeService.GetProductTypeByName(keyname);
                for (int j = 1; j < value.Count; j++)
                {
                    if (string.IsNullOrEmpty(value[j]))
                        break;
                    if (Convert.ToDecimal(value[j].Replace(",", ".")) > 0)
                    {
                        totalkg += Convert.ToDecimal(value[j]);
                        totalprice += Convert.ToDecimal(value[j]) * Convert.ToDecimal(value[0]);
                        var entity = new ProductQuantity
                        {
                            Name = keyname,
                            Totalkg = 0,
                            Totalprice = Convert.ToDecimal(value[j]) * Convert.ToDecimal(value[0]),
                            customerid = id,
                            UnitPrice = Convert.ToDecimal(value[0]),
                            dailyTakeCount = quantity,
                            productTypeid = productypeid.id,
                            Kg = Convert.ToDecimal(value[j]),
                            İsDelete = false,
                            CreatedDate = new DateTime(model.Factory.CreatedDate.Year, model.Factory.CreatedDate.Month, model.Factory.CreatedDate.Day),
                            ModifyDate = DateTime.Today,
                            branchid= Convert.ToInt32(keys.branchid)
                        };
                        _productQuantityService.Create(entity);
                        var stockcontroll = _stockTrackingService.GetStockByProductId(productypeid.id,Convert.ToInt32(keys.branchid));
                        if (stockcontroll != null)
                        {
                            stockcontroll.totalkg += entity.Kg;
                            stockcontroll.ModifyDate = DateTime.Now;
                            _stockTrackingService.Update(stockcontroll);
                        }
                        else
                        {
                            var stockentity = new StockTracking
                            {
                                CreatedDate = new DateTime(model.Factory.CreatedDate.Year, model.Factory.CreatedDate.Month, model.Factory.CreatedDate.Day),
                                ModifyDate = new DateTime(model.Factory.CreatedDate.Year, model.Factory.CreatedDate.Month, model.Factory.CreatedDate.Day),
                                productid = productypeid.id,
                                totalkg = entity.Kg,
                                İsDelete = false,
                               branchid= Convert.ToInt32(keys.branchid),
                            };
                            _stockTrackingService.Create(stockentity);
                        }
                    }
                    else
                        break;
                }
            
            }
            if (totalkg > 0 && totalprice > 0)
            {
                var entity = new PaymentCont
                {
                    branchid = Convert.ToInt32(keys.branchid),
                    CreatedDate = new DateTime(model.Factory.CreatedDate.Year, model.Factory.CreatedDate.Month, model.Factory.CreatedDate.Day),
                    dailyTakeCount = quantity,
                    ModifyDate = new DateTime(model.Factory.CreatedDate.Year, model.Factory.CreatedDate.Month, model.Factory.CreatedDate.Day),
                    totalkg = totalkg,
                    totalpice = totalprice,
                    usedid = id,
                    İsDelete = false,
                    paid = false,
                    paidprice = 0
                };
                _paymentContService.Create(entity);
            }
            return RedirectToAction("List", "Customer");
        }
        public IActionResult Add(string id)
        {
            var productid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var product = _productTypeService.GetById(Convert.ToInt32(productid));
            HttpContext.Session.SetString("customerid", productid.ToString());
            return View(new AllLayoutViewModel
            {
                ProductType = product
            });
        }
        [HttpGet]
        public IActionResult AddProductWithCustomerid(string producttypeid)
        {
            var productid = CommondMethod.ConvertToEncrypt(producttypeid);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View(new AllLayoutViewModel
            {
                ProductType = _productTypeService.GetById(Convert.ToInt32(productid))
            });
        }
        [HttpPost]
        public IActionResult AddProductWithCustomerid(ValueSum values)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var producttypeid = HttpContext.Request.RouteValues["id"];
            var customerid = HttpContext.Session.GetString("customerid");
            decimal sumtotal = 0;
            var entity = new ProductQuantity();
            List<ProductQuantity> productQuantities = new List<ProductQuantity>();
            foreach (var item in values.value)
            {
                //entity = new ProductQuantity();
                //entity.CreatedDate = System.DateTime.Now;
                //entity.Customerid = Convert.ToInt32(customerid);
                //entity.TypeProductid = Convert.ToInt32(producttypeid);
                //entity.İsDelete = false;
                //entity.Quantity = item;
                //entity.ModifyDate = DateTime.Now;
                sumtotal += item;
                _productQuantityService.Create(entity);
            }
            var value = _productTypeService.GetById(2);
            var categoria = new ProductQuantity
            {
                Name = value.Name,
                CreatedDate = DateTime.Now,
                customerid = entity.customerid,
                ModifyDate = DateTime.Now,
                Totalkg = sumtotal,
                Totalprice = sumtotal * value.kgPrice,
                UnitPrice = value.kgPrice,
                İsDelete = false
            };
            _productCategoriaService.Create(categoria);

            return Redirect("/ProductType/Add/" + customerid);
        }
    }
}
