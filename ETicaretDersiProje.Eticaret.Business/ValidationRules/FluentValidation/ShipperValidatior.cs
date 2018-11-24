using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class ShipperValidatior:AbstractValidator<Shipper>
    {
        public ShipperValidatior()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Lütfen şirket adını giriniz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Lüfen telefon numaranızı giriniz.");
        }
    }
}
