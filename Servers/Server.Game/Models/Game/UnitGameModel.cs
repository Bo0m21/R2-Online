using Database.Balance.Enums;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Network;
using System;
using System.Collections.Generic;

namespace Server.Game.Models.GameModels
{
    public class UnitGameModel
    {
        public UnitGameModel()
        {
            Drops = new List<UnitDropGameModel>();
            VisibleCharacterGames = new List<GameSession>();
            VisibleItemGames = new List<PublicItemGameModel>();
            VisibleUnitGames = new List<UnitGameModel>();
        }
        //TODO Сделать для мобов тип монстров(ангел, демон, нежить, маги и т.д.)
        //TODO Сделать критическую атаку для мобов
        #region Unit balance database
        /// <summary>
        ///     Unit id
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        ///     Type
        /// </summary>
        public UnitType Type { get; set; }

        /// <summary>
        ///     Unit name
        /// </summary>
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
        ///     Is aggression transformation
        /// </summary>
        public bool IsAggressionTransformation { get; set; }

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
        #endregion

        #region Default fields
        /// <summary>
        ///     Drops
        /// </summary>
        public List<UnitDropGameModel> Drops { get; set; }

        /// <summary>
        ///     Position default
        /// </summary>
        public Vector3 PositionDefault { get; set; }

        /// <summary>
        ///     Direction sight default
        /// </summary>
        public float DirectionSightDefault { get; set; }

        /// <summary>
        ///     Millisecond to respawn
        /// </summary>
        public int Respawn { get; set; }
        #endregion

        #region General fields
        /// <summary>
        ///     Unique identifier
        /// </summary>
        public UniqueIdentifier UniqueIdentifier { get; set; }

        /// <summary>
        ///     Attacked unique identifier
        /// </summary>
        public UniqueIdentifier AttackedUniqueIdentifier { get; set; }
        #endregion

        #region Unit fields
        /// <summary>
        ///     Hp
        /// </summary>
        public short Hp { get; set; }

        /// <summary>
        ///     Mp
        /// </summary>
        public short Mp { get; set; }

        /// <summary>
        ///     Position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        ///     Direction sight
        /// </summary>
        public float DirectionSight { get; set; }

        /// <summary>
        ///     Time for last update hp amd mp
        /// </summary>
        public DateTime LastUpdateHpMp { get; set; }

        /// <summary>
        ///     Is vsible first
        /// </summary>
        public bool IsVsibleFirst { get; set; }

        /// <summary>
        ///     Is dead
        /// </summary>
        public DateTime? DeadTime { get; set; }
        #endregion

        #region Visible fields
        /// <summary>
        ///     Visible character game
        /// </summary>
        public List<GameSession> VisibleCharacterGames { get; set; }

        /// <summary>
        ///     Visible item game
        /// </summary>
        public List<PublicItemGameModel> VisibleItemGames { get; set; }

        /// <summary>
        ///     Visible unit game
        /// </summary>
        public List<UnitGameModel> VisibleUnitGames { get; set; }
        #endregion
    }
}
