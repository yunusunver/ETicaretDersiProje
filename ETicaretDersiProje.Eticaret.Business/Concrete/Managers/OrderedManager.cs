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
    public class OrderedManager:IOrderedService
    {
        private IOrderedDal _orderedDal;

        public OrderedManager(IOrderedDal orderedDal)
        {
            _orderedDal = orderedDal;
        }

        public List<Ordered> GetAll()
        {
            return _orderedDal.GetList();
        }

        

        public Ordered GetbyId(int id)
        {
            return _orderedDal.Get(x=>x.OrderedID==id);
        }
        [FluentValidationAspect(typeof(OrderedValidatior))]
        public Ordered Add(Ordered ordered)
        {
            return _orderedDal.Add(ordered);
        }

        public Ordered Update(Ordered ordered)
        {
            return _orderedDal.Update(ordered);
        }

        public void Delete(Ordered ordered)
        {
            _orderedDal.Delete(ordered);
        }
    }
}
