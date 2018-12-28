using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetbyId(int id);
        Order GetbyOrderId(int id);
        Order Add(Order order);
        Order Update(Order order);
        void Delete(Order order);
    }
}
