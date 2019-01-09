using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Cart:IEntity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
