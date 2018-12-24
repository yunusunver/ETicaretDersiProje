using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.DataAccess.EntityFramework;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.ComplexTypes;
using ETicaretDersiProje.Eticaret.Entities.Concrete;

namespace ETicaretDersiProje.Eticaret.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,EticaretContext>,IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (EticaretContext context=new EticaretContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryID equals c.CategoryID
                    select new ProductDetail
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName
                    };
                return result.ToList();
            }

          
        }

        public List<Product> GetAllProduct()
        {
            using (var context = new EticaretContext())
            {
                return context.Products.Include("Category").Include("Color").Include("Size").Include("Supplier").ToList();
            }
        }

        public Product GetProduct(Expression<Func<Product, bool>> filter)
        {
            using (var context = new EticaretContext())
            {
                return context.Products.Include("Category").Include("Color").Include("Size").Include("Supplier").SingleOrDefault(filter);
            }
        }
    }
}
