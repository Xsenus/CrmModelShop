using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Продавец.
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Имя продавца.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Виртуальная коллекция чеков.
        /// </summary>
        public virtual ICollection<Check> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
