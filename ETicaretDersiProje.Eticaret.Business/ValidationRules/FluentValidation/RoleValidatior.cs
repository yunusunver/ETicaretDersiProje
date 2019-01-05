using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class RoleValidatior:AbstractValidator<Role>
    {
        public RoleValidatior()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Lütfen rol tanımlaması yapınız.");
        }
    }
}
