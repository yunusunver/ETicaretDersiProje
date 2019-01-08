using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Concrete.Managers
{
    public class RoleManager:IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetAll()
        {
            return _roleDal.GetList();
        }

        public Role GetbyRoleName(string roleName)
        {
            return _roleDal.Get(x => x.RoleName == roleName);
        }

        public Role GetbyId(int id)
        {
            return _roleDal.Get(x => x.Id == id);
        }

        public Role Add(Role role)
        {
            return _roleDal.Add(role);
        }

        public Role Update(Role role)
        {
            return _roleDal.Update(role);
        }

        public void Delete(Role role)
        {
            _roleDal.Delete(role);
        }
    }
}
