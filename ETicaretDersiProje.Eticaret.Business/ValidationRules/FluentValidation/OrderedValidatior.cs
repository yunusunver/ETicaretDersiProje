using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class OrderedValidatior:AbstractValidator<Ordered>
    {
        public OrderedValidatior()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen emailinizi giriniz.").MaximumLength(50).WithMessage("Email adresiniz  en fazla 50 karakter olabilir.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen adınızı  giriniz.").MaximumLength(50).WithMessage("Adınız en fazla 50 karakter olabilir.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen soyadınızı giriniz.").MaximumLength(50).WithMessage("Soyadınız en fazla 50 karakter olabilir.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Lütfen telefon numaranızı  giriniz.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Lütfen bulunduğunuz ülkeyi  giriniz.").MaximumLength(50).WithMessage("En fazla 50 karakter olabilir.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Lütfen bulunduğunuz şehiri  giriniz.").MaximumLength(50).WithMessage("En fazla 50 karakter olabilir.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Lütfen adresinizi  giriniz.").MaximumLength(200).WithMessage("Adresiniz en fazla 200 karakter olabilir.");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Lütfen posta kodunu  giriniz.").MaximumLength(5).WithMessage("En fazla 5 karakter olabilir.");

        }
    }
}
