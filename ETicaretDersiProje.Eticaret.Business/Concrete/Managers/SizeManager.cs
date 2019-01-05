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
    public class SizeManager:ISizeService
    {
        private ISizeDal _sizeDal;
        private IProductDal _productDal;
        private IOrderDetailDal _orderDetailDal;

        public SizeManager(ISizeDal sizeDal,IProductDal productDal,IOrderDetailDal orderDetailDal)
        {
            _sizeDal = sizeDal;
            _productDal = productDal;
            _orderDetailDal = orderDetailDal;
        }

        public List<Size> GetAll()
        {
            return _sizeDal.GetList();
        }

        public Size GetbyId(int id)
        {
            return _sizeDal.Get(x => x.SizeID == id);
        }
        [FluentValidationAspect(typeof(SizeValidatior))]
        public Size Add(Size size)
        {
            return _sizeDal.Add(size);
        }
        [FluentValidationAspect(typeof(SizeValidatior))]
        public Size Update(Size size)
        {
            return _sizeDal.Update(size);
        }

        public void Delete(Size size)
        {
          
            _sizeDal.Delete(size);
        }
    }
}
