using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class OrderDetail:IEntity
    {
        public int OrderDetailID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("Payment")]
        public int PaymentID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        [ForeignKey("Size")]
        public int SizeID { get; set; }
        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public bool FulFilled { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }

        public virtual Size Size { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Color Color { get; set; }
        public virtual Order Order { get; set; }
    }
}
