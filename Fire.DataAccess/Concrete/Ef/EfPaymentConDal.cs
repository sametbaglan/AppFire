using Fire.DataAccess.Abstrack;
using Fire.DataAccess.DbConnection;
using Fire.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fire.DataAccess.Concrete.Ef
{
    public class EfPaymentConDal : EfRepositoryDal<PaymentCont, DataContext>, IPaymentContDal
    {
        public PaymentCont GetPaymentByPay(int userid, int dailytakecount, int branch, DateTime date,bool state)
        {
            using (var db = new DataContext())
            {
                return db.PaymentCont.Where(x => x.usedid == userid&&x.states==state && x.dailyTakeCount == dailytakecount && x.branchid == branch && x.CreatedDate == date && x.İsDelete == false).FirstOrDefault();
            };
        }
    }
}
