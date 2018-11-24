using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetbyId(int id);
        Color Add(Color color);
        Color Update(Color color);
        void Delete(Color color);
    }
}
