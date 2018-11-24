using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class ColorValidatior:AbstractValidator<Color>
    {
        public ColorValidatior()
        {
            RuleFor(x => x.ColorValue).NotEmpty().WithMessage("Lütfen renk değeri giriniz.");
        }
    }
}
