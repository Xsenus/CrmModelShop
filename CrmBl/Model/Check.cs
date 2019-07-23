using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Чек.
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Уникальный идентификатор для чека.
        /// </summary>
        public int CheckId { get; set; }

        /// <summary>
        /// Обязательный уникальный идентификатор для покупателя.
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Обязательное виртуальное свойство для Entity Framework.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Уникальный идентификатор для продавца.
        /// </summary>
        public int? SellerId { get; set; }

        /// <summary>
        /// Обязательное виртуальное свойство для Entity Framework.
        /// </summary>
        public virtual Seller Seller { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Виртуальная коллекция Sells.
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        /// <summary>
        /// Сумма чека.
        /// </summary>
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{CheckId} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }
    }
}
