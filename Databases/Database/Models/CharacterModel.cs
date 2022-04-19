using Database.Balance.Enums;
using Packets.Server.Game.Structures;
using System;
using System.Collections.Generic;

namespace Database.Models
{
    /// <summary>
    ///     Character model
    /// </summary>
    public class CharacterModel
    {
        public CharacterModel()
        {
            Items = new List<ItemModel>();
        }

        public int Id { get; set; }

        /// <summary>
        ///     Account id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Slot number
        /// </summary>
        public byte SlotNumber { get; set; }

        /// <summary>
        ///     Character class
        /// </summary>
        public CharacterType Class { get; set; }

        /// <summary>
        ///     Gender
        /// </summary>
        public byte Gender { get; set; }

        /// <summary>
        ///     Head
        /// </summary>
        public byte Head { get; set; }

        /// <summary>
        ///     Face
        /// </summary>
        public byte Face { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public short Level { get; set; }

        /// <summary>
        ///     Exp
        /// </summary>
        public long Exp { get; set; }

        /// <summary>
        ///     Health point
        /// </summary>
        public short Hp { get; set; }

        /// <summary>
        ///     Magic point
        /// </summary>
        public short Mp { get; set; }

        /// <summary>
        ///     Reputation
        /// </summary>
        public short Reputation { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        ///     Direction sight
        /// </summary>
        public float DirectionSight { get; set; }

        /// <summary>
        ///     Create date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Last login date
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        ///     Delete date
        /// </summary>
        public DateTime DeleteDate { get; set; }

        /// <summary>
        ///     Is deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        public AccountModel Account { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}