using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Filters;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    [AuthFilter]
    public class PaymentController : Controller
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: Payment
        public ActionResult Index()
        {
            PaymentListViewModel model=new PaymentListViewModel()
            {
                Payments = _paymentService.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            _paymentService.Add(payment);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var payment = _paymentService.GetbyId(id);

            return View(payment);
        }

        [HttpPost]
        public ActionResult Edit(Payment payment)
        {
            _paymentService.Update(payment);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var payment = _paymentService.GetbyId(id);
            _paymentService.Delete(payment);
            return RedirectToAction("Index");
        }
    }
}