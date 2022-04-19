﻿using Database.Balance.Enums;

namespace Database.Balance.Models
{
    /// <summary>
    ///     Unit drop model
    /// </summary>
    public class UnitDropModel
    {
        public UnitDropModel()
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
        ///     Count from
        /// </summary>
        public int CountFrom { get; set; }

        /// <summary>
        ///     Count to
        /// </summary>
        public int CountTo { get; set; }

        /// <summary>
        ///     Percent
        /// </summary>
        public float Percent { get; set; }

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
