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
    public class OrderManager:IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAllOrder();
        }

        public Order GetbyId(int id)
        {
            return _orderDal.Get(x => x.OrderID == id);
        }
        public Order GetbyOrderId(int id)
        {
            return _orderDal.GetByOrderId(x => x.OrderID == id);
        }

        public Order Add(Order order)
        {
            return _orderDal.Add(order);
        }

        public Order Update(Order order)
        {
            return _orderDal.Update(order);
        }

        public void Delete(Order order)
        {
            _orderDal.Delete(order);
        }
    }
}
