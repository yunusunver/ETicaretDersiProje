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
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private IRoleService _roleService;

        public CustomerController(ICustomerService customerService,IRoleService roleService)
        {
            _customerService = customerService;
            _roleService = roleService;
        }

        public ActionResult Index()
        {
            CustomerListViewModel model=new CustomerListViewModel()
            {
                Customers = _customerService.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            CustomerListViewModel model=new CustomerListViewModel()
            {
                Customers = new List<Customer>(),
                Customer = new Customer(),
                Roles = new SelectList(_roleService.GetAll(), "Id", "RoleName")
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customer.RegistrationDate=DateTime.Now;
            _customerService.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetbyId(id);

            CustomerListViewModel model=new CustomerListViewModel()
            {
                Customers = _customerService.GetAll(),
                Customer = customer,
                Roles = new SelectList(_roleService.GetAll(), "Id", "RoleName")
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetbyId(id);
            _customerService.Delete(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var customer = _customerService.GetbyId(id);
            CustomerListViewModel model=new CustomerListViewModel()
            {
                Customer = customer,
                Role = _roleService.GetbyId(customer.RoleId)
               
            };
            return View(model);
        }


    }
}