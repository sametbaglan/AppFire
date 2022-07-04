using Fire.Entity.Abstrack;

namespace Fire.Entity.Concrete
{
    public class Payment:IBaseEntity
    {
        public int id { get; set; }
        public int usedid { get; set; }
        public decimal debtprice { get; set; }
        public decimal giveprice { get; set; }
    }
}
