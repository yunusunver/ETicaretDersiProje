using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class SupplierValidatior:AbstractValidator<Supplier>
    {
        public SupplierValidatior()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Lütfen bulunduğunuz şehiri giriniz.");
            RuleFor(x => x.Address1).NotEmpty().WithMessage("Lütfen adresinizi giriniz.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Lütfen şirket isminizi giriniz.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Lütfen bulunduğunuz ülkeyi giriniz");
        }
    }
}
