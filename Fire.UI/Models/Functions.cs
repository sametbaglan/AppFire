using Fire.Business.Abstrack;
using Fire.Business.Concrete;
using Fire.DataAccess.DbConnection;
using Fire.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fire.UI.Models
{

    public class Functions
    {
        static DataContext db = new DataContext();
        public static string name { get; set; }
        public static decimal TotalMountPrice(int Mounth)
        {
            var list = db.Expenses.Where(x => x.CreatedDate.Month == Mounth && x.CreatedDate.Year == DateTime.Now.Year).ToList();
            decimal tutar = 0;
            foreach (var item in list)
            {
                tutar += item.ExpensesPrice;
            }
            return tutar;
        }
        public static decimal TotalYearPrice(int year)
        {
            var list = db.Expenses.Where(x => x.CreatedDate.Year == year).ToList();
            decimal tutar = 0;
            foreach (var item in list)
            {
                tutar += item.ExpensesPrice;
            }
            return tutar;
        }
        public static string product(int id)
        {
            var result = db.ProductTypes.Where(x => x.id == id).FirstOrDefault();
            return result.Name;
        }
        public static List<ProductQuantity> Quantity(string name)
        {
            var list = db.productQuantity.Where(x => x.Name == name).ToList();
            return list;
        }
        public static bool paymentstate(int customerid, int quantity, DateTime date)
        {
            var value = db.productQuantity.Where(x => x.customerid == customerid && x.dailyTakeCount == quantity && x.CreatedDate == date).ToList();
            return false;

        }
        public static List<StockTracking> stockTrackings(int id)
        {
            return db.StockTracking.Where(x => x.productid == id).ToList();
        }
        public static string ProductName(int id)
        {
            var pro = db.ProductTypes.Where(x => x.id == id).FirstOrDefault();
            return pro.Name;
        }
        public static string FactoryName(int id)
        {
            var result = db.factories.Where(x => x.id == id).FirstOrDefault();
            return result.name + " " + result.Phone;
        }
        public static string CustomerName(int customerid)
        {
           var result= db.Customers.Where(x => x.id == customerid).FirstOrDefault();
            if (result == null)
            {
                return "boş";
            }

            return result.Name + " " + result.Surname + " " + result.PhoneNumber;
        }
        public static string bankname(int bankid)
        {
            return db.Bank.Where(x => x.id == bankid).FirstOrDefault().name;
        }
        public static string branchname(int branchid)
        {
            return db.Branch.Where(x => x.id == branchid).FirstOrDefault().branch;
        }
    }
}
