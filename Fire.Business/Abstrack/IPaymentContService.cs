using Fire.Entity.Concrete;
using System;
using System.Collections.Generic;

namespace Fire.Business.Abstrack
{
    public interface IPaymentContService
    {
        List<PaymentCont> GetAll();
        PaymentCont GetById(int id);
        void Create(PaymentCont entity);
        void Delete(PaymentCont entity);
        void Update(PaymentCont entity);
        PaymentCont GetPaymentByPay(int userid, int dailytakecount, int branch, DateTime date,bool state);
    }
}
