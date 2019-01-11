using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.DataAccess;
using ETicaretDersiProje.Core.DataAccess.EntityFramework;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Business.Concrete.Managers;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.DataAccess.Concrete.EntityFramework;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using Ninject.Modules;

namespace ETicaretDersiProje.Eticaret.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<IColorService>().To<ColorManager>().InSingletonScope();
            Bind<ISizeService>().To<SizeManager>().InSingletonScope();
            Bind<IOrderDetailService>().To<OrderDetailManager>().InSingletonScope();
            Bind<IOrderService>().To<OrderManager>().InSingletonScope();
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<ISupplierService>().To<SupplierManager>().InSingletonScope();
            Bind<IShipperService>().To<ShipperManager>().InSingletonScope();
            Bind<IPaymentService>().To<PaymentManager>().InSingletonScope();
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<IOrderedService>().To<OrderedManager>().InSingletonScope();
            Bind<IComplaintService>().To<ComplaintManager>().InSingletonScope();

            Bind<ICategoryDal>().To<EfCategoryDal>();
            Bind<IProductDal>().To<EfProductDal>();
            Bind<IColorDal>().To<EfColorDal>();
            Bind<ISizeDal>().To<EfSizeDal>();
            Bind<IOrderDetailDal>().To<EfOrderDetailDal>();
            Bind<IOrderDal>().To<EfOrderDal>();
            Bind<IRoleDal>().To<EfRoleDal>();
            Bind<ISupplierDal>().To<EfSupplierDal>();
            Bind<IShipperDal>().To<EfShipperDal>();
            Bind<IPaymentDal>().To<EfPaymentDal>();
            Bind<ICustomerDal>().To<EfCustomerDal>();
            Bind<IOrderedDal>().To<EfOrderedDal>();
            Bind<IComplaintDal>().To<EfComplaintDal>();

            Bind<DbContext>().To<EticaretContext>();
            


        }
    }
}
