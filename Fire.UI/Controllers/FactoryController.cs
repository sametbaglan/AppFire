using Fire.Business.Abstrack;
using Fire.Business.Encryption;
using Fire.Entity.Concrete;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Fire.UI.Models.FactoryStockControll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{
    public class FactoryController : Controller
    {
        private readonly IFactoryService _factoryservice;
        private readonly IFactoryQuantityService _factoryQuantityService;
        private readonly IProductTypeService _productTypeService;
        private readonly IStockTrackingService _stockTrackingService;
        private readonly IPaymentContService _paymentContService;
        public FactoryController(IPaymentContService paymentContService, IStockTrackingService stockTrackingService, IFactoryQuantityService factoryQuantityService,
            IProductTypeService productTypeService, IFactoryService factoryservice)
        {
            _factoryservice = factoryservice;
            _factoryQuantityService = factoryQuantityService;
            _productTypeService = productTypeService;
            _stockTrackingService = stockTrackingService;
            _paymentContService = paymentContService;
        }
        #region
        public IActionResult List()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            ViewBag.results = _factoryservice.GetAll();
            return View(new AllLayoutViewModel
            {
                Factories = _factoryservice.GetAll()
            });
        }
        public IActionResult AddFactory()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View();
        }
        [HttpPost]
        public IActionResult AddFactory(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var factory = new Factory
            {
                CreatedDate = System.DateTime.Now,
                ModifyDate = System.DateTime.Now,
                İsDelete = false,
                name = model.Factory.name,
                Phone = model.Factory.Phone
            };
            _factoryservice.Create(factory);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var factoryid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _factoryservice.GetById(Convert.ToInt32(factoryid));
            return View(new AllLayoutViewModel
            {
                Factory = value
            });
        }
        [HttpPost]
        public IActionResult Update(AllLayoutViewModel model, int id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var deger = _factoryservice.GetById(model.Customer.id);
            deger.name = model.Factory.name;
            deger.Phone = model.Factory.Phone;
            deger.ModifyDate = System.DateTime.Now;
            _factoryservice.Update(deger);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var customer = _factoryservice.GetById(id);
            customer.İsDelete = true;
            _factoryservice.Update(customer);
            return RedirectToAction("List");
        }
        #endregion
        [HttpGet]
        public IActionResult FactoryReceptAddByFactoryid(string factoryid)
        {
            var id = CommondMethod.ConvertDecrypt(factoryid);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");

            return View(new AllLayoutViewModel
            {
                productTypes = _productTypeService.GetAll()
            });
        }
        [HttpPost]
        public IActionResult FactoryReceptAddByFactoryid(AllLayoutViewModel allLayoutViewModel)
        {
            if (allLayoutViewModel.Factory.CreatedDate.Year == 0001)
                allLayoutViewModel.Factory.CreatedDate = DateTime.Now;
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var factoryid = HttpContext.Request.RouteValues["id"];
            int id = Convert.ToInt32(CommondMethod.ConvertDecrypt(factoryid.ToString()));
            var factoryquantitylist = _factoryQuantityService.GetFactoryQuantitiesByFactoryid(id, Convert.ToInt32(keys.branchid));
            var valuedate = factoryquantitylist.Where(x => x.CreatedDate == DateTime.Today).FirstOrDefault();
            int quantity = 0;
            decimal totalkg = 0;
            decimal totalprice = 0;
            if (valuedate != null)
                quantity = valuedate.dailyTakeCount + 1;
            else
                quantity += 1;
            var gelenform = HttpContext.Request.Form.ToList().Where(x => x.Value != "0" && x.Value.Count > 1 && x.Key != "__RequestVerificationToken" && x.Key != "Factory.CreatedDate").ToList();
            var factorystockvalue = FactoryStockControllViewModel.stockcontroll(gelenform, _stockTrackingService, _productTypeService, Convert.ToInt32(keys.branchid));
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
                decimal val = 0;
                if (string.IsNullOrEmpty(factorystockvalue))
                {
                    for (int j = 1; j < value.Count; j++)
                    {
                        if (value[0] != "0")
                            val = Convert.ToDecimal(keyvalue);
                        else
                            val = Convert.ToDecimal(val = Convert.ToDecimal(keyvalue));
                        if (string.IsNullOrEmpty(value[j]))
                            break;
                        if (Convert.ToDecimal(value[j].Replace(",", ".")) > 0)
                        {
                            totalkg += Convert.ToDecimal(value[j]);
                            totalprice += Convert.ToDecimal(value[j])* val;
                            var entity = new FactoryQuantity
                            {
                                Name = keyname,
                                Totalkg = 0,
                                Totalprice = Convert.ToDecimal(value[j]) * val,
                                factoryid = id,
                                UnitPrice =val,
                                dailyTakeCount = quantity,
                                factoryproducttypeid = productypeid.id,
                                İsDelete = false,
                                CreatedDate = new DateTime(allLayoutViewModel.Factory.CreatedDate.Year, allLayoutViewModel.Factory.CreatedDate.Month, allLayoutViewModel.Factory.CreatedDate.Day),
                                ModifyDate = DateTime.Today,
                                Kg = Convert.ToDecimal(value[j]),
                                branchid = Convert.ToInt32(keys.branchid),
                            };
                            _factoryQuantityService.Create(entity);
                            var stock = _stockTrackingService.GetStockByProductId(productypeid.id, Convert.ToInt32(keys.branchid));
                            stock.totalkg = stock.totalkg - entity.Kg;
                            _stockTrackingService.Update(stock);

                        }
                        else
                            break;
                    }
                }
                else
                {
                    ViewBag.message = $"{factorystockvalue}  ürünün stoğu yeterli değildir. Lütfen stoğunuzu güncelleyin";
                    return View();
                }

            }
            if (totalkg > 0 && totalprice > 0)
            {
                var entities = new PaymentCont
                {
                    branchid = Convert.ToInt32(keys.branchid),
                    CreatedDate = new DateTime(allLayoutViewModel.Factory.CreatedDate.Year, allLayoutViewModel.Factory.CreatedDate.Month, allLayoutViewModel.Factory.CreatedDate.Day),
                    dailyTakeCount = quantity,
                    ModifyDate = new DateTime(allLayoutViewModel.Factory.CreatedDate.Year, allLayoutViewModel.Factory.CreatedDate.Month, allLayoutViewModel.Factory.CreatedDate.Day),
                    totalkg = totalkg,
                    totalpice = totalprice,
                    usedid = id,
                    İsDelete = false,
                    paid = false,
                    paidprice = 0,
                    states=true
                };
                _paymentContService.Create(entities);
            }
           
            return RedirectToAction("List", "Factory");
        }
        [HttpGet]
        public IActionResult GetBeforeReceiptByFactoryid(string id)
        {
            var factoryid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            HttpContext.Session.SetString("fabrikaid", factoryid.ToString());
            var list = _factoryQuantityService.GetFactoryQuantitiesByFactoryid(Convert.ToInt32(factoryid), Convert.ToInt32(keys.branchid)).Select(x => new FactoryQuantity
            {
                id = x.id,
                CreatedDate = x.CreatedDate,
                dailyTakeCount = x.dailyTakeCount
            });
            var dateof = new List<int>();
            var quantityview = new List<FactoryQuantityViewModel>();
            foreach (var item in list)
            {
                if (dateof.Contains(item.dailyTakeCount) == false && dateof.Contains(item.id) == false)
                {
                    dateof.Add(item.dailyTakeCount);
                    dateof.Add(item.id);
                    var quantity = new FactoryQuantityViewModel
                    {
                        createdate = item.CreatedDate,
                        id = item.id,
                        quantity = item.dailyTakeCount
                    };
                    quantityview.Add(quantity);
                }
            }
            return View(new AllLayoutViewModel
            {
                factoryQuantityViewModels = quantityview
            });
        }
        [HttpGet]
        public IActionResult GetFisByid(string quantity, DateTime date)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            quantity = CommondMethod.ConvertDecrypt(quantity);
            string[] val = quantity.Split(',');
            quantity = val[0];
            val = val[1].Split('.');
            date = new DateTime(Convert.ToInt32(val[2]), Convert.ToInt32(val[1]), Convert.ToInt32(val[0]));
            var id = HttpContext.Session.GetString("fabrikaid");
            var list = _factoryQuantityService.GetFactoryQuantitiesByFactoryid(Convert.ToInt32(id), Convert.ToInt32(keys.branchid));
            var dailey = Convert.ToInt32(quantity);
            var d = list.Where(x => x.CreatedDate == date && x.dailyTakeCount == dailey).ToList();
            var s = d.Sum(x => x.Totalprice);
            ViewBag.totalprice = s;
            ViewBag.quantity = quantity;
            ViewBag.date = date.ToShortDateString();
            return View(new AllLayoutViewModel
            {
                factoryQuantities = d,
                productTypes = _productTypeService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult FullPaid(string quantity, DateTime date)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            quantity = CommondMethod.ConvertDecrypt(quantity);
            string[] val = quantity.Split(',');
            quantity = val[0];
            val = val[1].Split('.');
            date = new DateTime(Convert.ToInt32(val[2]), Convert.ToInt32(val[1]), Convert.ToInt32(val[0]));
            var customer = HttpContext.Session.GetString("fabrikaid");
            var payment = _paymentContService.GetPaymentByPay(Convert.ToInt32(customer), Convert.ToInt32(quantity), Convert.ToInt32(keys.branchid), date, true);
            if (payment != null)
            {
                var entity = new ProductQauntityViewModel
                {
                    createdate = date,
                    quantity = Convert.ToInt32(quantity),
                    id = Convert.ToInt32(customer),
                    branchid = Convert.ToInt32(keys.branchid)
                };
                var json = JsonConvert.SerializeObject(entity);
                HttpContext.Session.SetString("factoryentity", json);
            }
            return View(new AllLayoutViewModel
            {
                paymentCont = payment

            }); ;
        }
        [HttpPost]
        public IActionResult FullPaid(string deger)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var gelenprodutc = HttpContext.Session.GetString("factoryentity");
            var value = Convert.ToDecimal(deger);
            var deserilazeproduct = JsonConvert.DeserializeObject<ProductQauntityViewModel>(gelenprodutc);
            var datetime = new DateTime(deserilazeproduct.createdate.Year, deserilazeproduct.createdate.Month, deserilazeproduct.createdate.Day);
            var payment = _paymentContService.GetPaymentByPay(deserilazeproduct.id, deserilazeproduct.quantity,
                deserilazeproduct.branchid, deserilazeproduct.createdate, true);
            if (payment != null)
            {
                if (payment.totalpice >= Convert.ToDecimal(deger))
                {
                        payment.paidprice += value;
                    payment.totalpice = payment.totalpice - value;
                        if (payment.totalpice==0)
                            payment.paid = true;
                        _paymentContService.Update(payment);
                }
                else
                {
                    ViewBag.error = "Girilen değer verilecek olan ücretten büyük olamaz";
                }
            }
            return View(new AllLayoutViewModel
            {
                paymentCont = payment
            });
        }
        [HttpGet]
        public List<FactoryQuantity> GetQuantityByTypeid(string typeid)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            var list = _factoryQuantityService.GetQuantitiesByTypeid(Convert.ToInt32(typeid), Convert.ToInt32(keys.branchid)).ToList();
            return list;
            //tarihler manuel olacak YAPILDI
            //fabrikalar kısmında ürünlerle ürüm miktarları uyuşmamazlık YAPILDI
        }
        [HttpPost]
        public List<FactoryStockControllViewModel> Deneme(string quantity, DateTime date)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            string[] val = quantity.Split(',');
            quantity = val[0];
            val = val[1].Split('.');
            var datetime = new DateTime(Convert.ToInt32(val[2]), Convert.ToInt32(val[1]), Convert.ToInt32(val[0]));
            var id = HttpContext.Session.GetString("fabrikaid");
            var list = _factoryQuantityService.GetFactoryQuantitiesByFactoryid(Convert.ToInt32(id), Convert.ToInt32(keys.branchid));
            var dailey = Convert.ToInt32(quantity);
            var factorylist = list.Where(x => x.CreatedDate == datetime && x.dailyTakeCount == dailey).ToList();
            var factorylistgroup = factorylist.GroupBy(x => x.Name);
            var factoryquantity = new FactoryStockControllViewModel();
            var factoryquantityList = new List<FactoryStockControllViewModel>();
            var quantityFactory = new List<FactoryQuantity>();
            foreach (var item in factorylistgroup)
            {
                quantityFactory = new List<FactoryQuantity>();
                factoryquantity = new FactoryStockControllViewModel();
                factoryquantity.name = item.Key;
                foreach (var key in item)
                {
                    var factory = new FactoryQuantity
                    {
                        Kg = key.Kg,
                        Totalprice = key.Totalprice
                    };
                    quantityFactory.Add(factory);
                }
                factoryquantity.factoryQuantities = quantityFactory;
                factoryquantityList.Add(factoryquantity);
            }
            return factoryquantityList;
        }
    }
}