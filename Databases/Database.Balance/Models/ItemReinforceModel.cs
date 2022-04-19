namespace Database.Balance.Models
{
    /// <summary>
    ///     Item reinforce model
    /// </summary>
    public class ItemReinforceModel
    {
        public ItemReinforceModel()
        {

        }

        public int Id { get; set; }

        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Item old id
        /// </summary>
        public int? ItemOldId { get; set; }

        /// <summary>
        ///     Item new id
        /// </summary>
        public int? ItemNewId { get; set; }

        /// <summary>
        ///     Item 1 id
        /// </summary>
        public int Item1Id { get; set; }

        /// <summary>
        ///     Item 1 count
        /// </summary>
        public int Item1Count { get; set; }

        /// <summary>
        ///     Item 2 id
        /// </summary>
        public int? Item2Id { get; set; }

        /// <summary>
        ///     Item 2 count
        /// </summary>
        public int Item2Count { get; set; }

        /// <summary>
        ///     Item 3 id
        /// </summary>
        public int? Item3Id { get; set; }

        /// <summary>
        ///     Item 3 count
        /// </summary>
        public int Item3Count { get; set; }

        /// <summary>
        ///     Percent
        /// </summary>
        public float Percent { get; set; }

        /// <summary>
        ///     Item
        /// </summary>
        public ItemModel Item { get; set; }

        /// <summary>
        ///     Item old
        /// </summary>
        public ItemModel ItemOld { get; set; }

        /// <summary>
        ///     Item new
        /// </summary>
        public ItemModel ItemNew { get; set; }

        /// <summary>
        ///     Item 1 model
        /// </summary>
        public ItemModel Item1 { get; set; }

        /// <summary>
        ///     Item 2 model
        /// </summary>
        public ItemModel Item2 { get; set; }

        /// <summary>
        ///     Item 3 model
        /// </summary>
        public ItemModel Item3 { get; set; }
    }
}
