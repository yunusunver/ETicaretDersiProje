using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Supplier:IEntity
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactFName { get; set; }
        public string ContactLName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string DiscountType { get; set; }
        public int? DiscountRate { get; set; }
        public bool? DiscountAvailable { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public string Logo { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
    }
}
