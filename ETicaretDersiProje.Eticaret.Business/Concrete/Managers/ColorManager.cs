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
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetList();
        }

        public Color GetbyId(int id)
        {
            return _colorDal.Get(x => x.ColorID == id);
        }
        [FluentValidationAspect(typeof(ColorValidatior))]
        public Color Add(Color color)
        {
            return _colorDal.Add(color);
        }
        [FluentValidationAspect(typeof(ColorValidatior))]
        public Color Update(Color color)
        {
            return _colorDal.Update(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }
    }
}
