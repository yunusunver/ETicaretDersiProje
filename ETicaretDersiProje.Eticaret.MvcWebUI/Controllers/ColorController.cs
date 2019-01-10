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
    public class ColorController : Controller
    {
        private IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: Color
        public ActionResult Index()
        {
            ColorListViewModel model=new ColorListViewModel()
            {
                Colors = _colorService.GetAll()
            };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var color = _colorService.GetbyId(id);
            _colorService.Delete(color);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Color color)
        {
            _colorService.Add(color);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var color = _colorService.GetbyId(id);
            return View(color);
        }

        [HttpPost]
        public ActionResult Edit(Color color)
        {
            _colorService.Update(color);
            return RedirectToAction("Index");
        }




    }
}