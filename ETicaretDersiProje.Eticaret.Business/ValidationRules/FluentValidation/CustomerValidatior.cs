using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class CustomerValidatior:AbstractValidator<Customer>
    {
        public CustomerValidatior()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen e-mail adresinizi giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen parolanızı giriniz.").MinimumLength(6)
                .WithMessage("Parolanız en az 6 karakter olmalıdır.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen adınızı giriniz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen soyadınızı giriniz.");
        }
    }
}
