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
    public class CheckoutController : Controller
    {
        private IOrderedService _orderedService;
        private ICustomerService _customerService;
        private IOrderDetailService _orderDetailService;

        public CheckoutController(IOrderedService orderedService,ICustomerService customerService,IOrderDetailService orderDetailService)
        {
            _orderedService = orderedService;
            _customerService = customerService;
            _orderDetailService = orderDetailService;
        }
        [Auth]
        // GET: Checkout
        public ActionResult Index()
        {
            int id = (int)Session["id"];
            var customer = _customerService.GetByIdUser(id);
            CartListViewModel model=new CartListViewModel()
            {
                Carts = (List<Cart>)Session["sepet"],
                Ordered = new Ordered(),
                Customer = customer
                
            };
          
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Ordered ordered)
        {
            if (Session["sepet"] == null || (int)Session["total"] == 0)
            {
                return RedirectToAction("Index","Cart");
            }
            else
            {
                ordered.CustomerID = (int)Session["id"];
                ordered.OrderDate = DateTime.Now;


                _orderedService.Add(ordered);
                foreach (var item in (List<Cart>)Session["sepet"])
                {

                    _orderDetailService.Add(new OrderDetail
                    {
                        SupplierID = item.Product.SupplierID,
                        FulFilled = false,
                        Total = item.Total,
                        Quantity = item.Quantity,
                        Price = item.Product.UnitPrice,
                        BillDate = DateTime.Now,
                        ShipDate = DateTime.Now,
                        ProductID = item.Product.ProductID,
                        OrderedID = ordered.OrderedID

                    });
                }



                return RedirectToAction("SuccessPay");
            }
           
        }
        [Auth]
        public ActionResult SuccessPay()
        {
            int customerId = (int)Session["id"];
            var ordereds = _orderedService.GetAll().Where(x=>x.CustomerID==customerId).ToList();
            
            CartListViewModel model=new CartListViewModel()
            {
                 Ordereds= ordereds
            };
            return View(model);
        }


    }
}