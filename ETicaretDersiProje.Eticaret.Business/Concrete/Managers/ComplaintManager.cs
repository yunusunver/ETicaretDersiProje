using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Aspects.Postsharp.ValidationAspects;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Concrete.Managers
{
    public class ComplaintManager:IComplaintService
    {
        private IComplaintDal _complaintDal;

        public ComplaintManager(IComplaintDal complaintDal)
        {
            _complaintDal = complaintDal;
        }

        public List<Complaint> GetAll()
        {
            return _complaintDal.GetAllComplaints();
        }

        public Complaint GetbyId(int id)
        {
            return _complaintDal.Get(x=>x.ComplaintID==id);
        }
        [FluentValidationAspect(typeof(ComplaintValidatior))]
        public Complaint Add(Complaint complaint)
        {
            return _complaintDal.Add(complaint);
        }
        [FluentValidationAspect(typeof(ComplaintValidatior))]
        public Complaint Update(Complaint complaint)
        {
            return _complaintDal.Update(complaint);
        }

        public void Delete(Complaint complaint)
        {
            _complaintDal.Delete(complaint);
        }
    }
}
