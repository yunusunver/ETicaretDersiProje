using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAll();
        OrderDetail GetbyId(int id);
        OrderDetail Add(OrderDetail orderDetail);
        OrderDetail Update(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
    }
}
