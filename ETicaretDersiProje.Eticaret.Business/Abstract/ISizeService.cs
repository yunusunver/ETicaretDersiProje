using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface ISizeService
    {
        List<Size> GetAll();
        Size GetbyId(int id);
        Size Add(Size size);
        Size Update(Size size);
        void Delete(Size size);
    }
}
