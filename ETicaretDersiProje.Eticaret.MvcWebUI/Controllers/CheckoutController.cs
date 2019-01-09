using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    public class CheckoutController : Controller
    {
        private IOrderedService _orderedService;

        public CheckoutController(IOrderedService orderedService)
        {
            _orderedService = orderedService;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            return RedirectToAction("Index");
        }


    }
}