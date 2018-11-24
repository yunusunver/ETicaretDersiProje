using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IPaymentService
    {
        List<Payment> GetAll();
        Payment GetbyId(int id);
        Payment Add(Payment payment);
        Payment Update(Payment payment);
        void Delete(Payment payment);
    }
}
