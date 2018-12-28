using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.DataAccess;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        List<Order> GetAllOrder();
        Order GetByOrderId(Expression<Func<Order, bool>> filter);
    }
}
