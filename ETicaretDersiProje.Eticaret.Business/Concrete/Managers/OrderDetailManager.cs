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
    public class OrderDetailManager:IOrderDetailService
    {
        private IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailDal.GetAllOrderDetail();
        }

      

        public OrderDetail GetbyId(int id)
        {
            return _orderDetailDal.Get(x=>x.OrderDetailID==id);
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            return _orderDetailDal.Add(orderDetail);
        }

        public OrderDetail Update(OrderDetail orderDetail)
        {
            return _orderDetailDal.Update(orderDetail);
        }

        public void Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
        }
    }
}
