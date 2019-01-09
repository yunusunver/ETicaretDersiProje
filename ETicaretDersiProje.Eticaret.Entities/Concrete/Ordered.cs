using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Ordered:IEntity
    {
        public int OrderedID { get; set; }
        public int CustomerID { get; set; }
        public int OrderNumber { get; set; }
        public int  Price { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool Shipped { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }


    }
}
