using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.DataAccess;
using ETicaretDersiProje.Eticaret.Entities.ComplexTypes;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
        List<Product> GetAllProduct();
        Product GetProduct(Expression<Func<Product, bool>> filter);

    }
}
