using Fire.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Entity.Concrete
{
    public class Factory:IBaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Phone { get; set; }
        public List<FactoryProductType> factoryProductTypes { get; set; }
    }
}
