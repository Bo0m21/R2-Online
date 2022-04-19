using Database.DataModel.Enums;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Unit drop game model
    /// </summary>
    public class GUnitDrop
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
        ///     Item status type
        /// </summary>
        public ItemStatusEnum ItemStatus { get; set; }

        /// <summary>
        ///     Use count
        /// </summary>
        public short UseCount { get; set; }

        /// <summary>
        ///     Eat time
        /// </summary>
        public uint EatTime { get; set; }

        /// <summary>
        ///     Term of effectivity
        /// </summary>
        public int TermOfEffectivity { get; set; }

        /// <summary>
        ///     Item bind type
        /// </summary>
        public ItemBindTypeEnum ItemBind { get; set; }

        /// <summary>
        ///     Count
        /// </summary>
        public int Count{ get; set; }

        /// <summary>
        ///     Percent
        /// </summary>
        public float Percent { get; set; }
    }
}
