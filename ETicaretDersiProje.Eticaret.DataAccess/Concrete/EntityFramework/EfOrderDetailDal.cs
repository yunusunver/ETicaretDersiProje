using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.DataAccess.EntityFramework;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal:EfEntityRepositoryBase<OrderDetail,EticaretContext>,IOrderDetailDal
    {
        public List<OrderDetail> GetAllOrderDetail()
        {
            using (var context = new EticaretContext())
            {
                return context.OrderDetails.Include("Supplier").Include("Product").Include("Ordered").ToList();
            }
        }
    }
}
