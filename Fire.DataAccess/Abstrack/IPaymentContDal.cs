using Fire.Entity.Concrete;
using System;
using System.Collections.Generic;

namespace Fire.DataAccess.Abstrack
{
    public interface IPaymentContDal:IRepository<PaymentCont>
    {
        PaymentCont GetPaymentByPay(int userid, int dailytakecount, int branch, DateTime date,bool states);
    }
}
