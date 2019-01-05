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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,EticaretContext>,ICustomerDal
    {
        public List<Customer> GetAllCustomer()
        {
            using (var context=new EticaretContext())
            {
                return context.Customers.Include("Role").ToList();
            }
        }

        public Customer GetByIdUser(int id)
        {
            using (var context=new EticaretContext())
            {
                return context.Customers.Include("Role").SingleOrDefault(x=>x.CustomerID==id);
            }
        }
    }
}
