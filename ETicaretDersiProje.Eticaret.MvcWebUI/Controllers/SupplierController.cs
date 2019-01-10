using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Filters;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    [AuthFilter]
    public class SupplierController : Controller
    {
        private ISupplierService _supplierService;
        private ICustomerService _customerService;

        public SupplierController(ISupplierService supplierService,ICustomerService customerService)
        {
            _supplierService = supplierService;
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            SupplierListViewModel model=new SupplierListViewModel()
            {
                Suppliers = _supplierService.GetAll()
            };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var supplier = _supplierService.GetbyId(id);
            _supplierService.Delete(supplier);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            SupplierListViewModel model=new SupplierListViewModel()
            {
               Customers = new SelectList(_customerService.GetAll(),"CustomerID","FirstName"),
               Supplier = new Supplier()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier, HttpPostedFileBase image)
        {
            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Supplier/" + newFoto);
                supplier.Logo = "/Uploads/Supplier/" + newFoto;
            }

            _supplierService.Add(supplier);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var supplier = _supplierService.GetbyId(id);
            SupplierListViewModel model = new SupplierListViewModel()
            {
                Customers = new SelectList(_customerService.GetAll(), "CustomerID", "FirstName"),
                Supplier = supplier
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Supplier supplier,HttpPostedFileBase image)
        {
            if (image != null)
            {
                if (System.IO.File.Exists(Server.MapPath(supplier.Logo)))
                {
                    System.IO.File.Delete(Server.MapPath(supplier.Logo));
                }

                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Supplier/" + newFoto);
                supplier.Logo = "/Uploads/Supplier/" + newFoto;

            }

            _supplierService.Update(supplier);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var supplier = _supplierService.GetbyId(id);

            SupplierListViewModel model=new SupplierListViewModel()
            {
                Customers = new SelectList(_customerService.GetAll(),"CustomerID","FirstName"),
                Supplier = supplier
            };

            return View(model);
        }
    }
}