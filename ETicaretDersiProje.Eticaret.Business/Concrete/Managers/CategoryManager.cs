using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Aspects.Postsharp;
using ETicaretDersiProje.Core.Aspects.Postsharp.CacheAspects;
using ETicaretDersiProje.Core.Aspects.Postsharp.LogAspects;
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
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<Category> GetAll()
        {
            
            return _categoryDal.GetList();
        }

        public Category GetbyId(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);
        }
        [FluentValidationAspect(typeof(CategoryValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Category Add(Category category)
        {
            return _categoryDal.Add(category);
        }
        [FluentValidationAspect(typeof(CategoryValidatior))]
        public Category Update(Category category)
        {
            return _categoryDal.Update(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }
    }
}
