using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
    public class HomeListViewModel
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public Product Product { get; set; }

        public List<Product> CurrentCategoryProduct { get; set; }

        public Complaint Complaint { get; set; }
    }
}