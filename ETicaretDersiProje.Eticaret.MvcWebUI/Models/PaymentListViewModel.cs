using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
    public class PaymentListViewModel
    {
        public List<Payment> Payments { get; set; }
    }
}