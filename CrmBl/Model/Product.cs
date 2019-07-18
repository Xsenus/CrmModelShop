using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Продукт.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор класса.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Наименование продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество товара.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Виртуальная коллекция Sells.
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
