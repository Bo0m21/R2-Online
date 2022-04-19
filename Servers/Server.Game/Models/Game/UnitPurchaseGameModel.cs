namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Unit purchase game model
    /// </summary>
    public class UnitPurchaseGameModel
    {
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
    }
}
