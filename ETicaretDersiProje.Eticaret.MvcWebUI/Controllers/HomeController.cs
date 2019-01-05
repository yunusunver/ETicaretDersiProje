using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private ICustomerService _customerService;
        private IRoleService _roleService;

        public HomeController(ICategoryService categoryService, IProductService productService,ICustomerService customerService,IRoleService roleService)
        {
            _roleService = roleService;
            _categoryService = categoryService;
            _productService = productService;
            _customerService = customerService;
        }

        public ActionResult Index(int id=0)
        {
            if (id == 0)
            {
                HomeListViewModel model = new HomeListViewModel()
                {
                    Products = _productService.GetAll(),
                    Categories = _categoryService.GetAll()
                };
                return View(model);
            }
            else
            {
                HomeListViewModel model = new HomeListViewModel()
                {
                    Products = _productService.GetAll().Where(x=>x.CategoryID==id).ToList(),
                    Categories = _categoryService.GetAll()
                };
                return View(model);
            }
          
        }

        public ActionResult List(int id=0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var kullanici = _customerService.Get(x=>x.Email==customer.Email && x.Password==customer.Password);
            if (kullanici==null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (kullanici.Email==customer.Email && kullanici.Password==customer.Password)
                {
                    Session["id"] = kullanici.CustomerID;
                    Session["email"] = kullanici.Email.ToString();
                    Session["password"] = kullanici.Password.ToString();
                   
                    return RedirectToAction("Index", "Home");
                }
              
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Detail(int id)
        {
            var product = _productService.GetbyProduct(id);
            HomeListViewModel model=new HomeListViewModel()
            {
                Product = product,
                CurrentCategoryProduct=_productService.GetAll().Where(x=>x.CategoryID==product.CategoryID).ToList()
            };
            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Profile(int id)
        {
            var kullanici = _customerService.GetByIdUser(id);
            CustomerListViewModel model=new CustomerListViewModel()
            {
                Customer = kullanici,
                Roles = new SelectList(_roleService.GetAll(), "Id", "RoleName")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Profile(Customer customer)
        {
            var kullanici = _customerService.GetByIdUser(customer.CustomerID);
            
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }

   
    }
}