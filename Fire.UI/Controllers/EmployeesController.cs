using Fire.Business.Abstrack;
using Fire.Entity.Concrete;
using Fire.UI.Filter;
using Fire.UI.Models;
using Fire.UI.Models.AllViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static Fire.UI.Models.AuthorizationCont;

namespace Fire.UI.Controllers
{
    
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        public IActionResult List()
        {
      
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            return View(new AllLayoutViewModel
            {
                ListEmployees = _employeesService.GetListEmployeesByBranchid(Convert.ToInt32(keys.branchid))
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
            var entity = new Employees
            {
                Name = model.employees.Name,
                Surname = model.employees.Surname,
                CreatedDate = new DateTime(model.employees.CreatedDate.Year, model.employees.CreatedDate.Month, model.employees.CreatedDate.Day),
                ModifyDate= new DateTime(model.employees.CreatedDate.Year, model.employees.CreatedDate.Month, model.employees.CreatedDate.Day),
                Salary = model.employees.Salary,
                İsDelete = false,
                branchid = Convert.ToInt32(keys.branchid)
            };
            _employeesService.Create(entity);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");

            var value = _employeesService.GetById(id);
            if (value.branchid == Convert.ToInt32(keys.branchid))
            {
                return View(new AllLayoutViewModel
                {
                    employees = _employeesService.GetById(id)
                });
            }
            return NotFound();

        }
        public IActionResult Update(AllLayoutViewModel model)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _employeesService.GetById(model.employees.id);
            if (value.branchid == Convert.ToInt32(keys.branchid))
            {
                value.Name = model.employees.Name;
                value.Surname = model.employees.Surname;
                _employeesService.Update(value);
                return RedirectToAction("List");
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Authorization = HttpContext.Session.GetString("token");
            TokenKeys keys = AuthorizationCont.Authorization(Authorization);
            if (keys == null)
                return Redirect("/Error/401");
            var value = _employeesService.GetById(id);
            if (value.branchid == Convert.ToInt32(keys.branchid))
            {
                value.İsDelete = true;
                value.ModifyDate = DateTime.Now;
                return RedirectToAction("List");
            }
            return NotFound();
        }
    }
}