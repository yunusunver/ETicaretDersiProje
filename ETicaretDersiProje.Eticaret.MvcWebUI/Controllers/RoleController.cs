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
    public class RoleController : Controller
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public ActionResult Index()
        {
            RoleListViewModel model=new RoleListViewModel()
            {
                Roles = _roleService.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            _roleService.Add(role);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var role = _roleService.GetbyId(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            _roleService.Update(role);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var role = _roleService.GetbyId(id);
            _roleService.Delete(role);
            return RedirectToAction("Index");
        }
    }
}