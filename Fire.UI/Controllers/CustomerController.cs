using Fire.Business.Abstrack;
using Fire.Business.Encryption;
using Fire.DataAccess.DbConnection;
using Fire.Entity.Concrete;
using Fire.UI.Filter;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Fire.UI.Models.CustomerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{

    //[ServiceFilter(typeof(AuthorizationAttribute))]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductQuantityService _productQuantityService;
        private readonly IProductTypeService _productTypeService;
        private readonly IPaymentContService _paymentContService;
        public CustomerController(IPaymentContService paymentContService, IProductQuantityService productQuantityService, IProductTypeService productTypeService, ICustomerService customerService)
        {
            _customerService = customerService;
            _productTypeService = productTypeService;
            _productQuantityService = productQuantityService;
            _paymentContService = paymentContService;
        }
        public IActionResult List()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            ////dolu sessionu deserialize yapmak
            //var gelenprodutc = HttpContext.Session.GetString("sessionProductType");
            //var deserilazeproduct = JsonConvert.DeserializeObject<List<ProductType>>(gelenprodutc);
            ViewBag.results = _customerService.GetAll().Where(x => x.İsDelete == false);
            return View(new AllLayoutViewModel
            {
                ListCustomer = _customerService.GetAll().Where(x => x.İsDelete == false).ToList(),
            });
        }
        public IActionResult Add()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View();
        }
        [HttpPost]
        public IActionResult Add(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");

            var entity = new Customer
            {
                Surname = model.CustomerAdd.Surname,
                CreatedDate = System.DateTime.Now,
                ModifyDate = System.DateTime.Now,
                Name = model.CustomerAdd.Name,
                PhoneNumber = model.CustomerAdd.PhoneNumber,
                İsDelete = false
            };
            _customerService.Create(entity);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var customerid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _customerService.GetById(Convert.ToInt32(customerid));
            return View(new AllLayoutViewModel
            {
                Customer = value
            });
        }
        [HttpPost]
        public IActionResult Update(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var id = HttpContext.Request.RouteValues["id"];
            var deger = _customerService.GetById(Convert.ToInt32(id));
            deger.Name = model.Customer.Name;
            deger.PhoneNumber = model.Customer.PhoneNumber;
            deger.Surname = model.Customer.Surname;
            deger.ModifyDate = System.DateTime.Now;
            _customerService.Update(deger);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var customer = _customerService.GetById(id);
            customer.İsDelete = true;
            _customerService.Update(customer);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult GetBeforeFisWithCustomerid(string id)
        {
            var customerid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            HttpContext.Session.SetString("customerid", customerid.ToString());
            var quantitys = _productQuantityService.GetProductQuantitiesByCustomerid(Convert.ToInt32(customerid), Convert.ToInt32(keys.branchid)).Select(x => new ProductQuantity
            {
                id = x.id,
                dailyTakeCount = x.dailyTakeCount,
                CreatedDate = x.CreatedDate
            });
            var dateof = new List<int>();
            var quantityview = new List<ProductQauntityViewModel>();
            foreach (var item in quantitys)
            {
                if (dateof.Contains(item.dailyTakeCount) == false && dateof.Contains(item.id) == false)
                {
                    dateof.Add(item.dailyTakeCount);
                    dateof.Add(item.id);
                    var quantity = new ProductQauntityViewModel
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
                productQauntityViewModels = quantityview
            }); ;
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
            var customer = HttpContext.Session.GetString("customerid");
            var list = _productQuantityService.GetProductQuantitiesByCustomerid(Convert.ToInt32(customer), Convert.ToInt32(keys.branchid));
            var d = list.Where(x => x.CreatedDate == date && x.dailyTakeCount == Convert.ToInt32(quantity)).ToList();
            var s = d.Sum(x => x.Totalprice);
            ViewBag.totalprice = s;
            ViewBag.quantity = quantity;
            ViewBag.date = date.ToShortDateString();
            return View(new AllLayoutViewModel
            {
                productQuantities = d,
                productTypes = _productTypeService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult FullPaid(string quantity, int a)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            quantity = CommondMethod.ConvertDecrypt(quantity);
            string[] val = quantity.Split(',');
            quantity = val[0];
            val = val[1].Split('.');
            var datetime = new DateTime(Convert.ToInt32(val[2]), Convert.ToInt32(val[1]), Convert.ToInt32(val[0]));
            var customer = HttpContext.Session.GetString("customerid");
            var paymentlist = _paymentContService.GetPaymentByPay(Convert.ToInt32(customer), Convert.ToInt32(quantity), Convert.ToInt32(keys.branchid), datetime, false);
            if (paymentlist != null)
            {
                var entity = new ProductQauntityViewModel
                {
                    createdate = datetime,
                    quantity = Convert.ToInt32(quantity),
                    id = Convert.ToInt32(customer),
                    branchid = Convert.ToInt32(keys.branchid)
                };
                var json = JsonConvert.SerializeObject(entity);
                HttpContext.Session.SetString("entity", json);
            }
            return View(new AllLayoutViewModel
            {
                paymentCont = paymentlist
            });
        }
        [HttpPost]
        public IActionResult FullPaid(string deger)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = Convert.ToDecimal(deger);
            var gelenprodutc = HttpContext.Session.GetString("entity");
            var deserilazeproduct = JsonConvert.DeserializeObject<ProductQauntityViewModel>(gelenprodutc);
            var datetime = new DateTime(deserilazeproduct.createdate.Year, deserilazeproduct.createdate.Month, deserilazeproduct.createdate.Day);
            var payment = _paymentContService.GetPaymentByPay(deserilazeproduct.id,
                deserilazeproduct.quantity, deserilazeproduct.branchid, deserilazeproduct.createdate, false);
            if (payment != null)
            {
                if (payment.totalpice >= Convert.ToDecimal(deger))
                {
                    payment.paidprice += value;
                    payment.totalpice = payment.totalpice - value;
                    if (payment.totalpice == 0)
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
        public List<ProductQuantity> GetQuantityByTypeid(string typeid)
        {
            var list = _productQuantityService.GetQuantitiesByTypeid(Convert.ToInt32(typeid)).ToList();
            return list;
        }
        [HttpPost]
        public List<ProductQuantityViewModel> Deneme(string quantity, DateTime date)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            string[] val = quantity.Split(',');
            quantity = val[0];
            val = val[1].Split('.');
            var datetime = new DateTime(Convert.ToInt32(val[2]), Convert.ToInt32(val[1]), Convert.ToInt32(val[0]));
            var customer = HttpContext.Session.GetString("customerid");
            var list = _productQuantityService.GetProductQuantitiesByCustomerid(Convert.ToInt32(customer), Convert.ToInt32(keys.branchid));
            var d = list.Where(x => x.CreatedDate == datetime && x.dailyTakeCount == Convert.ToInt32(quantity)).ToList();
            var quantitygroup = d.GroupBy(x => x.Name).ToList();
            var quantityentity = new ProductQuantityViewModel();
            var quantityList = new List<ProductQuantityViewModel>();
            var ss = new List<ProductQuantity>();
            foreach (var item in quantitygroup)
            {
                ss = new List<ProductQuantity>();
                quantityentity = new ProductQuantityViewModel();
                var keyname = item.Key;
                quantityentity.name = keyname;
                foreach (var key in item)
                {
                    var product = new ProductQuantity
                    {
                        Totalprice = key.Totalprice,
                        Kg = key.Kg
                    };
                    ss.Add(product);

                }
                quantityentity.productQuantities = ss;
                quantityList.Add(quantityentity);
            }
            return quantityList;
        }
    }
}