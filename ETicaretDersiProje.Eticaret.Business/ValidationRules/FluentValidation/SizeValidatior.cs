using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class SizeValidatior:AbstractValidator<Size>
    {
        public SizeValidatior()
        {
            RuleFor(x => x.SizeValue).NotEmpty().WithMessage("Lütfen boyut değerini giriniz.");
        }
    }
}
