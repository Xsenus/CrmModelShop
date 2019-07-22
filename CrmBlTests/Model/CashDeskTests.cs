using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // Arrange
            var customer1 = new Customer()
            {
                Name = "testuser1",
                CustomerId = 1
            };

            var customer2 = new Customer()
            {
                Name = "testuser2",
                CustomerId = 2
            };

            var seller = new Seller()
            {
                Name = "sellername",
                SellerId = 1
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

            var cart1 = new Cart(customer1);
            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            var cart2 = new Cart(customer2);
            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);

            var cashdesk = new CashDesk(1, seller);
            cashdesk.MaxQueueLenght = 10;
            cashdesk.Enqueu(cart1);
            cashdesk.Enqueu(cart2);

            var cart1ExprextedResult = 400;
            var cart2ExprextedResult = 500;

            // Act

            var cart1ActualResult = cashdesk.Dequeue();
            var cart2ActualResult = cashdesk.Dequeue();

            // Assert

            Assert.AreEqual(cart1ExprextedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExprextedResult, cart2ActualResult);
            Assert.AreEqual(7, product1.Count);
            Assert.AreEqual(17, product2.Count);
        }
    }
}