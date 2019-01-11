using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ETicaretDersiProje.Core.Aspects.Postsharp.ValidationAspects;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using ETicaretDersiProje.Eticaret.MvcWebUI.Filters;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private ICustomerService _customerService;
        private IRoleService _roleService;
        private ISupplierService _supplierService;
        private IOrderedService _orderedService;
        private IComplaintService _complaintService;

        public HomeController(ICategoryService categoryService, IProductService productService,ICustomerService customerService,IRoleService roleService,ISupplierService supplierService, IOrderedService orderedService,IComplaintService complaintService)
        {
            _roleService = roleService;
            _categoryService = categoryService;
            _productService = productService;
            _customerService = customerService;
            _supplierService = supplierService;
            _orderedService = orderedService;
            _complaintService = complaintService;
        }

        public ActionResult Index(int id=0 , int supplierID=0)
        {
            Session["kategoriler"] = _categoryService.GetAll();
            if (id == 0 && supplierID==0)
            {
                HomeListViewModel model = new HomeListViewModel()
                {
                    Products = _productService.GetAll(),
                    Categories = _categoryService.GetAll(),
                    Suppliers = _supplierService.GetAll()
                };
                return View(model);
            }
            else if(id!=0)
            {
                HomeListViewModel model = new HomeListViewModel()
                {
                    Products = _productService.GetAll().Where(x=>x.CategoryID==id).ToList(),
                    Categories = _categoryService.GetAll(),
                    Suppliers = _supplierService.GetAll()
                };
                return View(model);
            }else if (supplierID!=0)
            {
                HomeListViewModel model = new HomeListViewModel()
                {
                    Products = _productService.GetAll().Where(x => x.SupplierID == supplierID).ToList(),
                    Categories = _categoryService.GetAll(),
                    Suppliers = _supplierService.GetAll()
                };
                return View(model);
            }
            return RedirectToAction("Error");

        }

     

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult List(int id=0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            

            return RedirectToAction("Index");
        }

        public ActionResult Discount()
        {
            var products = _productService.GetAll().Where(x => x.DiscountAvailable == true).ToList();
            HomeListViewModel model = new HomeListViewModel()
            {
                Products = products,
                Categories = _categoryService.GetAll(),
                Suppliers = _supplierService.GetAll()
            };
            return View(model);
        }

        public ActionResult Login()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var kullanici = _customerService.Get(x=>x.Email==customer.Email && x.Password==customer.Password);
            var role = _roleService.GetbyId(kullanici.RoleId);
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
                    Session["role"] = role.RoleName.ToString();
                   
                    return RedirectToAction("Index", "Home");
                }
              
            }
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Customer customer)
        {
            var role = _roleService.GetbyRoleName("Kullanıcı");
            customer.RegistrationDate = DateTime.Now;
            if (role!=null)
            {
                customer.RoleId = role.Id;
            }
            
            _customerService.Add(customer);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
        [Auth]
        public ActionResult Complaints()
        {
            HomeListViewModel model = new HomeListViewModel()
            {
                Complaint = new Complaint()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Complaints(Complaint complaint)
        {
            complaint.CustomerID = (int)Session["id"];
            complaint.CreatedDate=DateTime.Now;
            _complaintService.Add(complaint);
            return RedirectToAction("Index");
        }
        [Auth]
        public ActionResult Orders(int id)
        {
            OrderedListViewModel model=new OrderedListViewModel()
            {
                Ordereds = _orderedService.GetAll().Where(x=>x.CustomerID==id).OrderByDescending(x => x.OrderDate).ToList()
            };
            return View(model);
        }

        public ActionResult Detail(int id)
        {
           
                var product = _productService.GetbyProduct(id);
                HomeListViewModel model = new HomeListViewModel()
                {
                    Product = product,
                    CurrentCategoryProduct = _productService.GetAll().Where(x => x.CategoryID == product.CategoryID).ToList()
                };
                return View(model);
          
         
        }

        public ActionResult Contact()
        {
            return View();
        }
        [Auth]
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
        [Auth]
        [HttpPost]
        public ActionResult Profile(Customer customer)
        {
            var role = _roleService.GetbyRoleName("Kullanıcı");
            var kullanici = _customerService.GetByIdUser(customer.CustomerID);
            customer.RoleId = (int)Session["id"];
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }


        public JsonResult SendMailToUser(string mesaj,string baslik)
        {
            var result = false;
            result = SendEmail("yunus.unver1995@gmail.com",baslik , mesaj);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(mailMessage);


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}