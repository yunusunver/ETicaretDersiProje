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
    public class EfSupplierDal:EfEntityRepositoryBase<Supplier,EticaretContext>,ISupplierDal
    {

        public List<Supplier> GetAllSupplier()
        {
            using (var context = new EticaretContext())
            {
                return context.Suppliers.Include("Customer").ToList();
            }
        }
    }
}
