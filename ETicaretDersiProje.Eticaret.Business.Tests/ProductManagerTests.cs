using System;
using ETicaretDersiProje.Eticaret.Business.Concrete.Managers;
using ETicaretDersiProje.Eticaret.DataAccess.Abstract;
using ETicaretDersiProje.Eticaret.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ETicaretDersiProje.Eticaret.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock=new Mock<IProductDal>();
            ProductManager productManager=new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
