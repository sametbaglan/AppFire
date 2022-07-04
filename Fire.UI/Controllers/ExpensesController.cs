using Fire.Business.Abstrack;
using Fire.Business.Encryption;
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
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        private readonly IEmployeesService _employeesService;
        public ExpensesController(IEmployeesService employeesService, IExpensesService expensesService)
        {
            _expensesService = expensesService;
            _employeesService = employeesService;
        }
        public IActionResult GetList()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var list = _expensesService.GetAllByBranchid(Convert.ToInt32(keys.branchid));
            list.Where(x => x.İsDelete == false).ToList();
            var toplam = list.Sum(x => x.ExpensesPrice);
            ViewBag.totalexpenses = toplam;
            return View(new AllLayoutViewModel
            {
                ListExpenses = list
            });
        }
        [HttpGet]
        public IActionResult DailyExpenses()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var list = _expensesService.GetAllExpensesWithDataTime(DateTime.Now,Convert.ToInt32(keys.branchid));
            ViewBag.totalexpenses = list.Sum(x => x.ExpensesPrice);
            return View(new AllLayoutViewModel
            {
                ListExpenses = list
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
            var entity = new Expenses
            {
                Description = model.AddExpenses.Description,
                ExpensesPrice = model.AddExpenses.ExpensesPrice,
                İsDelete = false,
                CreatedDate = System.DateTime.Today,
                ModifyDate = System.DateTime.Today,
                branchid=Convert.ToInt32(keys.branchid)
            };
            _expensesService.Create(entity);
            return RedirectToAction("GetList");
        }
        public IActionResult Update(string id)
        {
            var expensesid = CommondMethod.ConvertDecrypt(id);
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            var expenses = _expensesService.GetById(Convert.ToInt32(expensesid));
            if (expenses.branchid  == Convert.ToInt32(keys.branchid))
            {
                return View(new AllLayoutViewModel
                {
                    AddExpenses = expenses
                });
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var expenses = _expensesService.GetById(model.AddExpenses.id);
            if (expenses.branchid == Convert.ToInt32(keys.branchid))
            {
                expenses.ExpensesPrice = model.AddExpenses.ExpensesPrice;
                expenses.Description = model.AddExpenses.Description;
                _expensesService.Update(expenses);
                return RedirectToAction("List");
            }
            return NotFound();
        }
        public IActionResult MounthExpenses()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var employeeslist = _employeesService.GetAll();
            var total = employeeslist.Sum(x => x.Salary);
            var list = _expensesService.GetAllExpensesWithDataTime(DateTime.Now,Convert.ToInt32(keys.branchid));
            var lastdayofthemonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (lastdayofthemonth.Month == DateTime.Now.Month && lastdayofthemonth.Day == DateTime.Now.Day && lastdayofthemonth.Year == DateTime.Now.Year)
            {
                var d = list.Where(x => x.personSalaryControll == false).FirstOrDefault();
                if (d != null)
                {
                    var entity = new Expenses
                    {
                        personSalaryControll = true,
                        Description = "Personel Giderleri",
                        CreatedDate = lastdayofthemonth,
                        ExpensesPrice = total,
                        ModifyDate = lastdayofthemonth,
                        İsDelete = false
                    };
                    _expensesService.Create(entity);
                }
            }
            else if (lastdayofthemonth.Year == DateTime.Now.Year && lastdayofthemonth.Month < DateTime.Now.Month)
            {
                var d = list.Where(x => x.personSalaryControll == true).FirstOrDefault();
                if (d == null)
                {
                    var entity = new Expenses
                    {
                        personSalaryControll = true,
                        Description = "Personel Giderleri",
                        CreatedDate = lastdayofthemonth,
                        ExpensesPrice = total,
                        ModifyDate = lastdayofthemonth,
                        İsDelete = false
                    };
                    _expensesService.Create(entity);
                }
            }
            ViewBag.sumtotal = list.Sum(x => x.ExpensesPrice);
            return View(new AllLayoutViewModel
            {
                ListExpenses = _expensesService.MonthlyExpenses(DateTime.Now.Month,Convert.ToInt32(keys.branchid))
            }); ;
        }
        public IActionResult YearlyExpenses()
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var list = _expensesService.YearlyExpenses(DateTime.Now.Year,Convert.ToInt32(keys.branchid));
            ViewBag.total = list.Sum(x => x.ExpensesPrice);
            return View(new AllLayoutViewModel
            {
                ListExpenses = list
            }); ;
        }
    }
}