using ETicaretDersiProje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Size:IEntity
    {
        public int SizeID { get; set; }
        public string SizeValue { get; set; }

        public virtual List<Product> Product { get; set; }
       

        public Size()
        {
            Product=new List<Product>();
         
        }
    }
}
