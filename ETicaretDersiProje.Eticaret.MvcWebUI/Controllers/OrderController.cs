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
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IShipperService _shipperService;
        private IPaymentService _paymentService;

        public OrderController(IOrderService orderService, ICustomerService customerService, IShipperService shipperService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _shipperService = shipperService;
            _paymentService = paymentService;
        }

        public ActionResult Index()
        {
            OrderListViewModel model=new OrderListViewModel()
            {
                Orders = _orderService.GetAll()
            }; 
            return View(model);
        }

        public ActionResult Create()
        {
            OrderListViewModel model=new OrderListViewModel()
            {
                Customers = new SelectList(_customerService.GetAll(),"CustomerID","FirstName").ToList(),
                Payments = new SelectList(_paymentService.GetAll(),"PaymentID","PaymentType").ToList(),
                Shippers = new SelectList(_shipperService.GetAll(),"ShipperID","CompanyName").ToList(),
                Order = new Order()
                
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            _orderService.Add(order);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var order = _orderService.GetbyOrderId(id);

            OrderListViewModel model = new OrderListViewModel()
            {
                Customers = new SelectList(_customerService.GetAll(), "CustomerID", "FirstName").ToList(),
                Payments = new SelectList(_paymentService.GetAll(), "PaymentID", "PaymentType").ToList(),
                Shippers = new SelectList(_shipperService.GetAll(), "ShipperID", "CompanyName").ToList(),
                Order = order

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var order = _orderService.GetbyId(id);
            _orderService.Delete(order);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var order = _orderService.GetbyOrderId(id);
            OrderListViewModel model=new OrderListViewModel()
            {
                Order = order
            };
            return View(model);
        }

    }
}