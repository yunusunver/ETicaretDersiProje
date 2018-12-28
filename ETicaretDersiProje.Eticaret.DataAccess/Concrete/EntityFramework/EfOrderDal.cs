using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.DataAccess.EntityFramework;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal:EfEntityRepositoryBase<Order,EticaretContext>,IOrderDal
    {
        public List<Order> GetAllOrder()
        {
            using (var context=new EticaretContext())
            {
                return context.Orders.Include("Customer").Include("Payment").Include("Shipper").ToList();
            }
        }

        public Order GetByOrderId(Expression<Func<Order, bool>> filter)
        {
            using (var context=new EticaretContext())
            {
                return context.Orders.Include("Customer").Include("Shipper").Include("Payment").SingleOrDefault(filter);
            }
        }
    }
}
