using Fire.Entity.Abstrack;

namespace Fire.Entity.Concrete
{
    public class PaymentCont:IBaseEntity
    {
        public int id { get; set; }
        public int usedid { get; set; }
        public int dailyTakeCount { get; set; }
        public decimal totalkg { get; set; }
        public decimal totalpice { get; set; }
        public int branchid { get; set; }
        public bool paid { get; set; }
        public decimal paidprice { get; set; }
        public bool states { get; set; }

    }
}
