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
    public class ShipperController : Controller
    {
        private IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // GET: Shipper
        public ActionResult Index()
        {
            ShipperListViewModel model=new ShipperListViewModel()
            {
                Shippers = _shipperService.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shipper shipper)
        {
            _shipperService.Add(shipper);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var shipper = _shipperService.GetbyId(id);
            return View(shipper);
        }
        [HttpPost]
        public ActionResult Edit(Shipper shipper)
        {
            _shipperService.Update(shipper);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var shipper = _shipperService.GetbyId(id);
            _shipperService.Delete(shipper);
            return RedirectToAction("Index");
        }
    }
}