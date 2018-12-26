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
    public class SupplierManager:ISupplierService
    {
        private ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public List<Supplier> GetAll()
        {
            return _supplierDal.GetAllSupplier();
        }

        public Supplier GetbyId(int id)
        {
            return _supplierDal.Get(x => x.SupplierID == id);
        }

        public Supplier Add(Supplier supplier)
        {
            return _supplierDal.Add(supplier);
        }

        public Supplier Update(Supplier supplier)
        {
            return _supplierDal.Update(supplier);
        }

        public void Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
        }
    }
}
