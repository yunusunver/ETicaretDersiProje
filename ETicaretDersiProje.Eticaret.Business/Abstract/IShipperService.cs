using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IShipperService
    {
        List<Shipper> GetAll();
        Shipper GetbyId(int id);
        Shipper Add(Shipper shipper);
        Shipper Update(Shipper shipper);
        void Delete(Shipper shipper);
    }
}
