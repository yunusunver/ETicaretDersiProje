using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IOrderedService
    {
        List<Ordered> GetAll();
        Ordered GetbyId(int id);
        Ordered Add(Ordered ordered);
        Ordered Update(Ordered ordered);
        void Delete(Ordered ordered);
    }
}
