using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // Arrange - объявление
            var customer = new Customer()
            {
                Name = "TestUser"
            };

            var product1 = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };

            var product2 = new Product()
            {
                ProductId = 2,
                Name = "prod3",
                Price = 200,
                Count = 20
            };

            var cart = new Cart(customer);

            var expectedResult = new List<Product>()
            {
                product1,
                product1,
                product2
            };

            // Act - выполнение действие

            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);

            var cartResult = cart.GetAll();

            // Assert - сравнение ожидаемого результата и что получилось по факту

            Assert.AreEqual(expectedResult.Count, cartResult.Count);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }
    }
}