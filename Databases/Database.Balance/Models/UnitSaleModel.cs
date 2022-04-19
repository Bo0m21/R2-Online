namespace Database.Balance.Models
{
    /// <summary>
    ///     Unit sale model
    /// </summary>
    public class UnitSaleModel
    {
        public UnitSaleModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        ///     Item
        /// </summary>
        public ItemModel Item { get; set; }
    }
}
