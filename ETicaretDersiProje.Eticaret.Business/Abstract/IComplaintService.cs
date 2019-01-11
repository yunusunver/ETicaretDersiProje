using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IComplaintService
    {
        List<Complaint> GetAll();
        Complaint GetbyId(int id);
        Complaint Add(Complaint complaint);
        Complaint Update(Complaint complaint);
        void Delete(Complaint complaint);
    }
}
