using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductID { get; set; }
        public string ProductName{ get; set; }
        public string ProductDescription { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int UnitPrice { get; set; }
        public int SizeID { get; set; }
        public int ColorID { get; set; }
        public int Discount  { get; set; }
        public string Picture { get; set; }
        public bool DiscountAvailable  { get; set; }
        public bool CurrentOrder { get; set; }
    }
}
