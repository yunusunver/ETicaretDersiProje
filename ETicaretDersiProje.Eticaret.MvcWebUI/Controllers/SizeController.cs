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
    public class SizeController : Controller
    {
        private ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        public ActionResult Index()
        {
            SizeListViewModel model=new SizeListViewModel()
            {
                Sizes=_sizeService.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Size size)
        {
            _sizeService.Add(size);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var size = _sizeService.GetbyId(id);
            _sizeService.Delete(size);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var size = _sizeService.GetbyId(id);
            _sizeService.Update(size);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Size size)
        {
            _sizeService.Update(size);
            return RedirectToAction("Index");
        }
    }
}