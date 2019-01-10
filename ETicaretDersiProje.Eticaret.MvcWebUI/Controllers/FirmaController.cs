using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    public class FirmaController : Controller
    {
        private IProductService _productService;
        private ISupplierService _supplierService;
        private ICategoryService _categoryService;
        private IColorService _colorService;
        private ISizeService _sizeService;
        private IOrderDetailService _orderDetailService;

        public FirmaController(IProductService productService,ISupplierService supplierService,IColorService colorService,ISizeService sizeService,ICategoryService categoryService,IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _supplierService = supplierService;
            _categoryService = categoryService;
            _colorService = colorService;
            _sizeService = sizeService;
            _orderDetailService = orderDetailService;
        }

        // GET: Firma
        public ActionResult Index()
        {
            var supplier= _supplierService.GetSupplierbyCustomer((int)Session["id"]);
            ProductListViewModel model=new ProductListViewModel()
            {
                 Products = _productService.GetAll().Where(x=>x.SupplierID==supplier.SupplierID).ToList()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Categories = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName").ToList(),
                Sizes = new SelectList(_sizeService.GetAll(), "SizeID", "SizeValue").ToList(),
                Colors = new SelectList(_colorService.GetAll(), "ColorID", "ColorValue").ToList(),
                Suppliers = new SelectList(_supplierService.GetAll(), "SupplierID", "CompanyName").ToList(),
                Product = new Product()
            };
            return View(model);
            
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            var supplier = _supplierService.GetSupplierbyCustomer((int)Session["id"]);
            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoInfo = new FileInfo(image.FileName);

                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/Product/" + newFoto);
                product.Picture = "/Uploads/Product/" + newFoto;
            }

            product.SupplierID = supplier.SupplierID;
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
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {

            var supplier = _supplierService.GetSupplierbyCustomer((int)Session["id"]);
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

            product.SupplierID = supplier.SupplierID;
            _productService.Update(product);


            return RedirectToAction("Index");
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


        public ActionResult ListOrdered()
        {
            var orders = _orderDetailService.GetAll().Where(x => x.SupplierID == (int) Session["id"]).ToList();

            return View(orders);
        }
        public ActionResult OrderDetailDelete(int id)
        {
            var order = _orderDetailService.GetbyId(id);
            _orderDetailService.Delete(order);
            return RedirectToAction("ListOrdered");
        }
    }
}