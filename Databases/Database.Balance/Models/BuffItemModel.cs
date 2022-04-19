namespace Database.Balance.Models
{
    /// <summary>
    ///     Buff item model
    /// </summary>
    public class BuffItemModel
    {
        public BuffItemModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Buff id
        /// </summary>
        public int BuffId { get; set; }

        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Time
        /// </summary>
        public uint Time { get; set; }

        /// <summary>
        ///     Buff
        /// </summary>
        public BuffModel Buff { get; set; }

        /// <summary>
        ///     Item
        /// </summary>
        public ItemModel Item { get; set; }
    }
}
