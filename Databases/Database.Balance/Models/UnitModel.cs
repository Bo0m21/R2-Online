using Database.Balance.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Balance.Models
{
    /// <summary>
    ///     Unit model
    /// </summary>
    public class UnitModel
    {
        public UnitModel()
        {
            UnitDrops = new List<UnitDropModel>();
            UnitPositions = new List<UnitPositionModel>();
            UnitPurchases = new List<UnitPurchaseModel>();
        }

        public int Id { get; set; }

        /// <summary>
        ///     Unit id
        /// </summary>
        [Required]
        public int UnitId { get; set; }

        /// <summary>
        ///     Type
        /// </summary>
        public UnitType Type { get; set; }

        /// <summary>
        ///     Unit name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     Exp from unit
        /// </summary>
        public long Exp { get; set; }

        /// <summary>
        ///     Reputation from unit
        /// </summary>
        public short Reputation { get; set; }

        /// <summary>
        ///     Direct Damage value min
        /// </summary>
        public int DDvMin { get; set; }

        /// <summary>
        ///     Direct Damage value max
        /// </summary>
        public int DDvMax { get; set; }

        /// <summary>
        ///     Magic Damage value min
        /// </summary>
        public int MDvMin { get; set; }

        /// <summary>
        ///     Magic Damage value max
        /// </summary>
        public int MDvMax { get; set; }

        /// <summary>
        ///     Range Damage value min
        /// </summary>
        public int RDvMin { get; set; }

        /// <summary>
        ///     Range Damage value max
        /// </summary>
        public int RDvMax { get; set; }

        /// <summary>
        ///     Direct Protection value
        /// </summary>
        public int DPv { get; set; }

        /// <summary>
        ///     Magic Protection value
        /// </summary>
        public int MPv { get; set; }

        /// <summary>
        ///     Ranged Protection value
        /// </summary>
        public int RPv { get; set; }

        /// <summary>
        ///     Direct hit
        /// </summary>
        public int Dhit { get; set; }

        /// <summary>
        ///     Direct Damage dodge
        /// </summary>
        public int DDd { get; set; }

        /// <summary>
        ///     Range hit
        /// </summary>
        public int Rhit { get; set; }

        /// <summary>
        ///     Range Damage dodge
        /// </summary>
        public int RDd { get; set; }

        /// <summary>
        ///     Magic hit
        /// </summary>
        public int Mhit { get; set; }

        /// <summary>
        ///     Magic Damage dodge
        /// </summary>
        public int MDd { get; set; }

        /// <summary>
        ///     Attack Rate
        /// </summary>
        public short AttackRate { get; set; }

        /// <summary>
        ///     Move Rate
        /// </summary>
        public short MoveRate { get; set; }

        /// <summary>
        ///     Hp max
        /// </summary>
        public short HpMax { get; set; }

        /// <summary>
        ///     Hp regen
        /// </summary>
        public short HpRegen { get; set; }

        /// <summary>
        ///     Mp max
        /// </summary>
        public short MpMax { get; set; }

        /// <summary>
        ///     Mp regen
        /// </summary>
        public short MpRegen { get; set; }

        /// <summary>
        ///     Distance move
        /// </summary>
        public float DistanceMove { get; set; }

        /// <summary>
        ///     Distance attack
        /// </summary>
        public float DistanceAttack { get; set; }

        /// <summary>
        ///     Is aggression 
        /// </summary>
        public bool IsAggression { get; set; }

        /// <summary>
        ///     Is transformation aggression
        /// </summary>
        public bool IsAggressionTransformation { get; set; }
        /// <summary>
        ///     Is invisible aggression
        /// </summary>
        public bool IsAggressionInvisible { get; set; }
        /// <summary>
        ///     Distance aggression
        /// </summary>
        public float DistanceAggression { get; set; }

        /// <summary>
        ///     Payment type
        /// </summary>
        public PaymentType? PaymentType { get; set; }

        /// <summary>
        ///     Script
        /// </summary>
        public int Script { get; set; }

        /// <summary>
        ///     Unit drops
        /// </summary>
        public List<UnitDropModel> UnitDrops { get; set; }

        /// <summary>
        ///     Unit positions
        /// </summary>
        public List<UnitPositionModel> UnitPositions { get; set; }

        /// <summary>
        ///     Unit purchases
        /// </summary>
        public List<UnitPurchaseModel> UnitPurchases { get; set; }
    }
}
