namespace CrmBl.Model
{
    /// <summary>
    /// Продажа.
    /// </summary>
    public class Sell
    {
        /// <summary>
        /// Уникальный идентификатор продажи.
        /// </summary>
        public int SellId { get; set; }

        /// <summary>
        /// Уникальный идентификатор для чека.
        /// </summary>
        public int CheckId { get; set; }

        /// <summary>
        /// Уникальный идентификатор для продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Виртуальное свойство для чека.
        /// </summary>
        public virtual Check Check { get; set; }

        /// <summary>
        /// Виртуальное свойство для продукта.
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
