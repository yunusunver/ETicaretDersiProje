using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Lütfen kategori ismini giriniz.").MaximumLength(50).WithMessage("Kategori ismi en fazla 50 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen kategori açıklamasını giriniz.");
        }
    }
}
