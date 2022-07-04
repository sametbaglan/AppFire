﻿using Fire.Business.Abstrack;
using Fire.DataAccess.Abstrack;
using Fire.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Business.Concrete
{
    public class PaymentContManager : IPaymentContService
    {
        private readonly IPaymentContDal _paymentContDal;
        public PaymentContManager(IPaymentContDal paymentContDal)
        {
            _paymentContDal = paymentContDal;
        }
        public void Create(PaymentCont entity)
        {
            _paymentContDal.Create(entity);
        }

        public void Delete(PaymentCont entity)
        {
            _paymentContDal.Delete(entity);
        }

        public List<PaymentCont> GetAll()
        {
            return _paymentContDal.GetAll();
        }

        public PaymentCont GetById(int id)
        {
            return _paymentContDal.GetById(id);
        }

        public PaymentCont GetPaymentByPay(int userid, int dailytakecount, int branch, DateTime date,bool state)
        {
            return _paymentContDal.GetPaymentByPay(userid, dailytakecount, branch, date,state);
        }

        public void Update(PaymentCont entity)
        {
            _paymentContDal.Update(entity);
        }
    }
}
