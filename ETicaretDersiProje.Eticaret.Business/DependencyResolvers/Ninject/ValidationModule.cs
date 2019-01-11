using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace ETicaretDersiProje.Eticaret.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Category>>().To<CategoryValidatior>().InSingletonScope();
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
            Bind<IValidator<Color>>().To<ColorValidatior>().InSingletonScope();
            Bind<IValidator<Size>>().To<SizeValidatior>().InSingletonScope();
            Bind<IValidator<Customer>>().To<CustomerValidatior>().InSingletonScope();
            Bind<IValidator<Shipper>>().To<ShipperValidatior>().InSingletonScope();
            Bind<IValidator<Supplier>>().To<SupplierValidatior>().InSingletonScope();
            Bind<IValidator<Role>>().To<RoleValidatior>().InSingletonScope();
            Bind<IValidator<Ordered>>().To<OrderedValidatior>().InSingletonScope();
            Bind<IValidator<Complaint>>().To<ComplaintValidatior>().InSingletonScope();
        }
    }
}
