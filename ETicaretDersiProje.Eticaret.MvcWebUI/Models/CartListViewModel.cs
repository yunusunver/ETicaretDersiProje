using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
    public class CartListViewModel
    {
        public List<Cart> Carts { get; set; }
        public Cart Cart { get; set; }
        public Ordered Ordered { get; set; }
        public Customer Customer { get; set; }
        public List<Ordered> Ordereds { get; set; }

    }
}