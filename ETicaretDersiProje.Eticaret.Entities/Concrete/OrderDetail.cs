using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class OrderDetail:IEntity
    {
        public int OrderDetailID { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public string OrderNumber { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        public int SizeID { get; set; }
        public int ColorID { get; set; }
        public bool FulFilled { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }
    }
}
