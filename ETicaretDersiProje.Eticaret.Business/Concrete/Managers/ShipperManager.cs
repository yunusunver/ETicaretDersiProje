using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Aspects.Postsharp.ValidationAspects;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Concrete.Managers
{
    public class ShipperManager:IShipperService
    {
        private IShipperDal _shipperDal;

        public ShipperManager(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }

        public List<Shipper> GetAll()
        {
            return _shipperDal.GetList();
        }

        public Shipper GetbyId(int id)
        {
            return _shipperDal.Get(x => x.ShipperID == id);
        }
        [FluentValidationAspect(typeof(ShipperValidatior))]
        public Shipper Add(Shipper shipper)
        {
            return _shipperDal.Add(shipper);
        }
        [FluentValidationAspect(typeof(ShipperValidatior))]
        public Shipper Update(Shipper shipper)
        {
            return _shipperDal.Update(shipper);
        }

        public void Delete(Shipper shipper)
        {
            _shipperDal.Delete(shipper);
        }
    }
}
