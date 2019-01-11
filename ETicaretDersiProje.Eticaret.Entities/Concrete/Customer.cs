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
    public class Customer:IEntity
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1  { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public int CardExpMo { get; set; }
        public int CardExpYr { get; set; }
        public string CreditCardTypeID { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public DateTime RegistrationDate { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual List<Supplier> Supplier { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Complaint> Complaints { get; set; }
        public virtual Role Role { get; set; }
        
    }
}
