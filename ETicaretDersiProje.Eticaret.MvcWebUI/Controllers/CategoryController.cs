using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ETicaretDersiProje.Core.Aspects.Postsharp.ValidationAspects;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Filters;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;
using FluentValidation.Resources;
using FluentValidation.Results;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    [AuthFilter]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = new CategoryListViewModel
            {
                Categories=_categoryService.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category,HttpPostedFileBase image)
        {
          


            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Category/" + newFoto);
                category.Picture = "/Uploads/Category/" + newFoto;
            }
         
            category.Active = true;
            _categoryService.Add(category);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetbyId(id);

            if (System.IO.File.Exists(Server.MapPath(category.Picture)))
            {
                System.IO.File.Delete(Server.MapPath(category.Picture));
            }
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetbyId(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category,HttpPostedFileBase image)
        {
            if (image != null)
            {
                if (System.IO.File.Exists(Server.MapPath(category.Picture)))
                {
                    System.IO.File.Delete(Server.MapPath(category.Picture));
                }
                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Category/" + newFoto);
                category.Picture = "/Uploads/Category/" + newFoto;
                category.Active = true;
                
            }
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }


    }
}