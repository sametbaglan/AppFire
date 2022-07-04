using Fire.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Entity.Concrete
{
    public class FactoryQuantity:IBaseEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Totalkg { get; set; }
        public decimal Totalprice { get; set; }
        public int factoryid { get; set; }
        public decimal UnitPrice { get; set; }
        public int dailyTakeCount { get; set; }
        public int factoryproducttypeid { get; set; }
        public decimal Kg { get; set; }
        public bool paid { get; set; }
        public decimal alacak { get; set; }
        public int branchid { get; set; }

    }
}
