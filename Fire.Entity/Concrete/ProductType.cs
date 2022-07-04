using Fire.Entity.Abstrack;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fire.Entity.Concrete
{
    public class ProductType:IBaseEntity
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public decimal kgPrice { get; set; }
        public List<ProductQuantity> ProductQuantities { get; set; }

    }
}
