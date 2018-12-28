using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Shipper:IEntity
    {
        public int ShipperID { get; set; }
        public string CompanyName{ get; set; }
        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
