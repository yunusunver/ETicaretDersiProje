using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Order:IEntity
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("Payment")]
        public int PaymentID  { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate  { get; set; }
        public DateTime? ShipDate { get; set; }
        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }
        public int? Freight { get; set; }
        public int? SalesTax { get; set; }
        public bool? FulFilled { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Paid { get; set; }
        public string TransactStatus { get; set; }
        public string ErrLoc { get; set; }
        public string ErrMsg { get; set; }


        public Customer Customer { get; set; }
        public  Payment Payment { get; set; }
        public Shipper Shipper { get; set; }


    }
}
