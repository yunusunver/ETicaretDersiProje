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
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private ISizeService _sizeService;
        private IColorService _colorService;
        private ISupplierService _supplierService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISizeService sizeService, IColorService colorService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _sizeService = sizeService;
            _colorService = colorService;
            _supplierService = supplierService;
        }

        public ActionResult Index()
        {
            ProductListViewModel model=new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var product = _productService.GetbyId(id);
            if (System.IO.File.Exists(Server.MapPath(product.Picture)))
            {
                System.IO.File.Delete(Server.MapPath(product.Picture));
            }
            _productService.Delete(product);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ProductListViewModel model=new ProductListViewModel()
            {
                Categories =new SelectList(_categoryService.GetAll(),"CategoryID","CategoryName").ToList(),
                Sizes = new SelectList(_sizeService.GetAll(), "SizeID", "SizeValue").ToList(),
                Colors = new SelectList(_colorService.GetAll(), "ColorID", "ColorValue").ToList(),
                Suppliers= new SelectList(_supplierService.GetAll(), "SupplierID", "CompanyName").ToList(),
                Product = new Product()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase image)
        {

            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Product/" + newFoto);
                product.Picture = "/Uploads/Product/" + newFoto;
            }

            _productService.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _productService.GetbyId(id);
            ProductListViewModel model = new ProductListViewModel()
            {
                Categories = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName").ToList(),
                Sizes = new SelectList(_sizeService.GetAll(), "SizeID", "SizeValue").ToList(),
                Colors = new SelectList(_colorService.GetAll(), "ColorID", "ColorValue").ToList(),
                Suppliers = new SelectList(_supplierService.GetAll(), "SupplierID", "CompanyName").ToList(),
                Product = product
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product,HttpPostedFileBase image)
        {


            if (image != null)
            {
                if (System.IO.File.Exists(Server.MapPath(product.Picture)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Picture));
                }

                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Product/" + newFoto);
                product.Picture = "/Uploads/Product/" + newFoto;
               
            }
            _productService.Update(product);


            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var product = _productService.GetbyProduct(id);
            ProductListViewModel model = new ProductListViewModel()
            {
                Product = product
            };
            return View(model);
        }
    }
}