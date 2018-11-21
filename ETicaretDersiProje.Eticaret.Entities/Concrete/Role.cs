using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Role:IEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
