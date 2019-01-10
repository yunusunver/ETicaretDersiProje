using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface ISupplierService
    {
        List<Supplier> GetAll();
        Supplier GetbyId(int id);
        Supplier Add(Supplier supplier);
        Supplier Update(Supplier supplier);
        void Delete(Supplier supplier);
        Supplier GetSupplierbyCustomer(int id);
    }
}
