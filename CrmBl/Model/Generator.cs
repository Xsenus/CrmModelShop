using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class Generator
    {
        Random rnd = new Random();

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRndRandomText()
                };
                Customers.Add(customer);
                result.Add(customer);
            }

            return result;
        }

        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRndRandomText()
                };
                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetRndRandomText(),
                    Price = Convert.ToDecimal(rnd.Next(5, 100000) + rnd.NextDouble()),
                    Count = rnd.Next(10, 1000)
                };
                Products.Add(product);
                result.Add(product);
            }

            return result;
        }

        /// <summary>
        /// Получение существующих продуктов.
        /// </summary>
        public List<Product> GetRadomProducts(int min, int max)
        {
            var result = new List<Product>();

            var count = rnd.Next(min, max);

            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }

            return result;
        }

        private static string GetRndRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
