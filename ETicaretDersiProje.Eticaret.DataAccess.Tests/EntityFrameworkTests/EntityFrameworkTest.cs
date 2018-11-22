using System;
using ETicaretDersiProje.Eticaret.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ETicaretDersiProje.Eticaret.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_categories()
        {
            EfCategoryDal categoryDal=new EfCategoryDal();
            var result = categoryDal.GetList();
            Assert.AreEqual(2,result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_categories()
        {
            EfCategoryDal categoryDal = new EfCategoryDal();
            var result = categoryDal.GetList(x=>x.CategoryName.Contains("E"));
            Assert.AreEqual(1, result.Count);
        }
    }
}
