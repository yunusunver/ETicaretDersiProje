using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
    public class OrderListViewModel
    {
        public List<Order> Orders { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Payments { get; set; }
        public IEnumerable<SelectListItem> Shippers { get; set; }

        public Order Order { get; set; }

    }
}