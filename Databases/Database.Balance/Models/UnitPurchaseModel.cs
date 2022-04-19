namespace Database.Balance.Models
{
    /// <summary>
    ///     Unit purchase model
    /// </summary>
    public class UnitPurchaseModel
    {
        public UnitPurchaseModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Unit id
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        ///     Flag
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        ///     Sort key
        /// </summary>
        public int SortKey { get; set; }

        /// <summary>
        ///     Unit
        /// </summary>
        public UnitModel Unit { get; set; }

        /// <summary>
        ///     Item
        /// </summary>
        public ItemModel Item { get; set; }
    }
}
