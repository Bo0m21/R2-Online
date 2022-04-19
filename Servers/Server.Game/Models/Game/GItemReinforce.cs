namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Item reinforce game model
    /// </summary>
    public class GItemReinforce
    {
        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Item  old id
        /// </summary>
        public int? ItemOldId { get; set; }

        /// <summary>
        ///     Item  new id
        /// </summary>
        public int? ItemNewId { get; set; }

        /// <summary>
        ///     Item  1 id
        /// </summary>
        public int Item1Id { get; set; }

        /// <summary>
        ///     Item  1 count
        /// </summary>
        public int Item1Count { get; set; }

        /// <summary>
        ///     Item  2 id
        /// </summary>
        public int? Item2Id { get; set; }

        /// <summary>
        ///     Item  2 count
        /// </summary>
        public int Item2Count { get; set; }

        /// <summary>
        ///     Item  3 id
        /// </summary>
        public int? Item3Id { get; set; }

        /// <summary>
        ///     Item  3 count
        /// </summary>
        public int Item3Count { get; set; }

        /// <summary>
        ///     Percent
        /// </summary>
        public float Percent { get; set; }
    }
}
