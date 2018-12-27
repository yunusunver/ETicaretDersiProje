using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        public Role Role { get; set; }
    }
}