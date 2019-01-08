using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAll();
        Role GetbyId(int id);
        Role Add(Role role);
        Role Update(Role role);
        void Delete(Role role);
        Role GetbyRoleName(string roleName);
    }
}
