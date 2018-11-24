using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Lütfen ürün açıklamasını giriniz.");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Lütfen ürün fiyatını giriniz.");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Lütfen ürün ismini giriniz.");
            RuleFor(x => x.Picture).NotEmpty().WithMessage("Lütfen ürün resmi ekleyiniz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Lütfen kategoriyi seçiniz.");

        }
    }
}
