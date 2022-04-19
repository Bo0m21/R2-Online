using Database.Balance.Enums;

namespace Database.Models
{
    /// <summary>
    ///     Item model
    /// </summary>
    public class ItemModel
    {
        public ItemModel()
        {
            
        }

        public int Id { get; set; }

        /// <summary>
        ///     Character id
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public ItemEquipType? Position { get; set; }

        /// <summary>
        ///     Count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     Identification
        /// </summary>
        public byte Flag { get; set; }

        /// <summary>
        ///     End tick
        /// </summary>
        public uint EndTick { get; set; }

        /// <summary>
        ///     Item status type
        /// </summary>
        public ItemStatusType ItemStatus { get; set; }

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
        public ItemBindType ItemBind { get; set; }

        /// <summary>
        ///     Restore count
        /// </summary>
        public byte Restore { get; set; }

        /// <summary>
        ///     Hole count
        /// </summary>
        public byte Hole { get; set; }

        /// <summary>
        ///     Is deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        public CharacterModel Character { get; set; }
    }
}