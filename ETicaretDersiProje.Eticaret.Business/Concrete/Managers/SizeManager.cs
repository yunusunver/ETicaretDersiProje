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
    public class SizeManager:ISizeService
    {
        private ISizeDal _sizeDal;

        public SizeManager(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }

        public List<Size> GetAll()
        {
            return _sizeDal.GetList();
        }

        public Size GetbyId(int id)
        {
            return _sizeDal.Get(x => x.SizeID == id);
        }

        public Size Add(Size size)
        {
            return _sizeDal.Add(size);
        }

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
