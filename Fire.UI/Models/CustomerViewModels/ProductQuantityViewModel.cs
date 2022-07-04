using Fire.Entity.Concrete;
using System.Collections.Generic;

namespace Fire.UI.Models.CustomerViewModels
{
    public class ProductQuantityViewModel
    {
        public string name{ get; set; }
        public List<ProductQuantity> productQuantities{ get; set; }
    }
    public class ProductquantityModel
    {
        public List<ProductQuantityViewModel> productQuantityViewModels { get; set; }
    }
}
