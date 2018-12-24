using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Aspects.Postsharp;
using ETicaretDersiProje.Core.Aspects.Postsharp.CacheAspects;
using ETicaretDersiProje.Core.Aspects.Postsharp.PerformanceAspects;
using ETicaretDersiProje.Core.Aspects.Postsharp.ValidationAspects;
using ETicaretDersiProje.Core.CrossCuttingConcerns.Caching.Microsoft;
using ETicaretDersiProje.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using ETicaretDersiProje.Eticaret.Business.Abstract;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<Product> GetAll()
        {
            return _productDal.GetAllProduct();
        }

        public Product GetbyId(int id)
        {
            return _productDal.Get(x => x.ProductID == id);
        }

        public Product GetbyProduct(int id)
        {
            return _productDal.GetProduct(x => x.ProductID == id);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}
