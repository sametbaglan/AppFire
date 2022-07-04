using Fire.Entity.Concrete;
using Fire.UI.Models.CustomerViewModels;
using System.Collections.Generic;

namespace Fire.UI.Models.AllViewModels
{
    public class AllLayoutViewModel
    {
        public bank bank { get; set; }
        public List<Check> ChecksList { get; set; }
        public Check check { get; set; }
        public PaymentCont paymentCont { get; set; }
        public StockTracking stockTracking { get; set; }
        public ProductQauntityViewModel productQauntityViewModel { get; set; }
        public List<FactoryQuantity> factoryQuantities { get; set; }
        public List<FactoryQuantityViewModel> factoryQuantityViewModels { get; set; }
        public List<FactoryProductType> factoryProductTypes { get; set; }
        public List<ProductQauntityViewModel>  productQauntityViewModels { get; set; }
        public List<Customer>  ListCustomer{ get; set; }
        public CustomerAddViewModel CustomerAdd { get; set; }
        public Customer Customer { get; set; }
        public List<Employees> ListEmployees { get; set; }
        public Employees employees { get; set; }
        public List<Expenses>ListExpenses{ get; set; }
        public Expenses AddExpenses { get; set; }
        public List<ProductType>productTypes{ get; set; }
        public ProductType ProductType { get; set; }
        public List<ProductQuantity>productCategorias { get; set; }
        public ProductQuantity productCategoria { get; set; }
        public List<ProductQuantity> productQuantities { get; set; }
        public ProductQuantity productQuantity { get; set; }
        public ValueSum ValueSum { get; set; }
        public Factory Factory { get; set; }
        public List<Factory> Factories { get; set; }
        public User User { get; set; }

    }
}
