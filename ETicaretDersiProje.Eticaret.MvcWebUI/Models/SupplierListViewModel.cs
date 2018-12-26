using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
    public class SupplierListViewModel
    {
        public List<Supplier> Suppliers { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public Supplier Supplier { get; set; } 
    }
}