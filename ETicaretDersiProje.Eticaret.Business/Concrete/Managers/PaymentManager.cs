using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Concrete.Managers
{
    public class PaymentManager:IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public List<Payment> GetAll()
        {
            return _paymentDal.GetList();
        }

        public Payment GetbyId(int id)
        {
            return _paymentDal.Get(x => x.PaymentID == id);
        }

        public Payment Add(Payment payment)
        {
            return _paymentDal.Add(payment);
        }

        public Payment Update(Payment payment)
        {
            return _paymentDal.Update(payment);
        }

        public void Delete(Payment payment)
        {
             _paymentDal.Delete(payment);
        }
    }
}
