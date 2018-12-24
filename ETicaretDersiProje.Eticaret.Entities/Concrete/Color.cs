using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Color:IEntity
    {
        public int ColorID { get; set; }
        public string ColorValue { get; set; }

        public virtual List<Product> Product { get; set; }

        public Color()
        {
            Product=new List<Product>();
        }
    }
}
