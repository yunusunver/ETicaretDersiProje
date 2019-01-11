using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.MvcWebUI.Filters;
using ETicaretDersiProje.Eticaret.MvcWebUI.Models;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Controllers
{
    [AuthFilter]
    public class ComplaintController : Controller
    {
        private IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        // GET: Complaint
        public ActionResult Index()
        {
            ComplaintListViewModel model=new ComplaintListViewModel()
            {
                Complaints = _complaintService.GetAll().OrderByDescending(x=>x.CreatedDate).ToList()
            };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var complaint = _complaintService.GetbyId(id);
            _complaintService.Delete(complaint);
            return RedirectToAction("Index");
        }
    }
}