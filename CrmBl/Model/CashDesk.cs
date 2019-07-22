using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс выполняет функцию контроллера.
    /// </summary>
    public class CashDesk
    {
        CrmContext db = new CrmContext();

        /// <summary>
        /// Номер кассы.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Продавец.
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Очередь для клиентов (взаимодействие с корзиной).
        /// </summary>
        public Queue<Cart> Queue { get; set; }

        /// <summary>
        /// Максимальная длина очереди.
        /// </summary>
        public int MaxQueueLenght { get; set; }

        /// <summary>
        /// Счетчик для учета людей не входящих в очередь.
        /// </summary>
        public int ExitCustomer { get; set; }

        /// <summary>
        /// Является ли экземпляр моделью.
        /// </summary>
        public bool IsModel { get; set; }

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }

        /// <summary>
        /// Заполнение очереди и людей которые ушли.
        /// </summary>
        public void Enqueu(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        public decimal Dequeue()
        {
            decimal sum = 0;
            var card = Queue.Dequeue();

            if (card != null)
            {
                // создаем чек
                var check = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = card.Customer.CustomerId,
                    Customer = card.Customer,
                    Created = DateTime.Now
                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in card)
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        sells.Add(sell);

                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        sum += product.Price;
                    }                    
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                }
            }
            return sum;
        }
    }
}
