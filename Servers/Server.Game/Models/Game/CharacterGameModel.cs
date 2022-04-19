using Database.Balance.Enums;
using Packets.Server.Game.Structures;
using Server.Game.Core.Enums;
using Server.Game.Models.Game;
using Server.Game.Network;
using System;
using System.Collections.Generic;

namespace Server.Game.Models.GameModels
{
    /// <summary>
    ///     Character game model
    /// </summary>
    public class CharacterGameModel
    {
        public CharacterGameModel()
        {
            Items = new List<ItemGameModel>();
            Buffs = new List<BuffGameModel>();
            VisibleCharacterGames = new List<GameSession>();
            VisibleItemGames = new List<PublicItemGameModel>();
            VisibleUnitGames = new List<UnitGameModel>();
        }

        #region Character database
        public int Id { get; set; }

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
        #endregion

        #region Character balance database
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
        ///     Range Protection value
        /// </summary>
        public int RPv { get; set; }

        /// <summary>
        ///     Direct hit
        /// </summary>
        public int DHit { get; set; }

        /// <summary>
        ///     Direct Damage dodge
        /// </summary>
        public int DDd { get; set; }

        /// <summary>
        ///     Range hit
        /// </summary>
        public int RHit { get; set; }

        /// <summary>
        ///     Range Damage dodge
        /// </summary>
        public int RDd { get; set; }

        /// <summary>
        ///     Magic hit
        /// </summary>
        public int MHit { get; set; }

        /// <summary>
        ///     Magic Damage dodge
        /// </summary>
        public int MDd { get; set; }

        /// <summary>
        ///     Strength
        /// </summary>
        public short Str { get; set; }

        /// <summary>
        ///     Adroitness
        /// </summary>
        public short Dex { get; set; }

        /// <summary>
        ///     Intelligence
        /// </summary>
        public short Int { get; set; }

        /// <summary>
        ///     Health point max
        /// </summary>
        public short HpMax { get; set; }

        /// <summary>
        ///     Health point regen
        /// </summary>
        public short HpRegen { get; set; }

        /// <summary>
        ///     Magic point max
        /// </summary>
        public short MpMax { get; set; }

        /// <summary>
        ///     Magic point regen
        /// </summary>
        public short MpRegen { get; set; }

        /// <summary>
        ///     Weight
        /// </summary>
        public short WeightMax { get; set; }

        /// <summary>
        ///     Attack rate
        /// </summary>
        public short AttackRate { get; set; }

        /// <summary>
        ///     Move rate
        /// </summary>
        public short MoveRate { get; set; }
        #endregion

        #region Character balance calculate
        /// <summary>
        ///     Critical
        /// </summary>
        public short Critical { get; set; }

        /// <summary>
        ///     Critical protect
        /// </summary>
        public short CriticalProtect { get; set; }

        /// <summary>
        ///     DDv critical add
        /// </summary>
        public short DDvCriticalAdd { get; set; }

        /// <summary>
        ///     DDv critical remove
        /// </summary>
        public short DDvCriticalRemove { get; set; }

        /// <summary>
        ///     Human killer
        /// </summary>
        public short HumanKiller { get; set; }

        /// <summary>
        ///     Human protect
        /// </summary>
        public short HumanProtect { get; set; }

        /// <summary>
        ///     Mob killer
        /// </summary>
        public short MobKiller { get; set; }

        /// <summary>
        ///     Mob protect
        /// </summary>
        public short MobProtect { get; set; }

        /// <summary>
        ///     Hp potion restore
        /// </summary>
        public short HpPotionRestore { get; set; }

        /// <summary>
        ///     Add potion restore hp
        /// </summary>
        public short AddPotionRestoreHp { get; set; }

        /// <summary>
        ///     Add transform hp
        /// </summary>
        public short AddTransformMaxHp { get; set; }

        /// <summary>
        ///     Mp potion restore
        /// </summary>
        public short MpPotionRestore { get; set; }

        /// <summary>
        ///     Add potion restore mp
        /// </summary>
        public short AddPotionRestoreMp { get; set; }

        /// <summary>
        ///     Add transform max hp
        /// </summary>
        public short AddTransformMaxMp { get; set; }

        /// <summary>
        ///     Weight
        /// </summary>
        public short Weight { get; set; }

        /// <summary>
        ///     Attack speed when transform
        /// </summary>
        public short AttackRateWhenTransform { get; set; }

        /// <summary>
        ///     Move speed when transform
        /// </summary>
        public short MoveRateWhenTransform { get; set; }

        /// <summary>
        ///     Distance attack
        /// </summary>
        public float DistanceAttack { get; set; }
        #endregion

        #region Default fields
        /// <summary>
        ///     Items
        /// </summary>
        public List<ItemGameModel> Items { get; set; }

        /// <summary>
        ///     Items
        /// </summary>
        public List<BuffGameModel> Buffs { get; set; }
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

        #region Character fields
        /// <summary>
        ///     Character action
        /// </summary>
        public uint Action { get; set; }

        /// <summary>
        ///     Time for last update hp amd mp
        /// </summary>
        public DateTime LastUpdateHpMp { get; set; }

        /// <summary>
        ///     Is vsible first
        /// </summary>
        public bool IsVsibleFirst { get; set; }

        /// <summary>
        ///     Is dead, dead time
        /// </summary>
        public DateTime? DeadTime { get; set; }
        
        /// <summary>
        ///     Attack target
        /// </summary>
        public AttackType AttackTarget { get; set; }


        public UniqueIdentifier TargetSessionGameId { get; set; }
        public ushort AttackType { get; set; }
        public Vector3 AttackPosition { get; set; }
        public byte AttackFlag { get; set; }

        public bool checkAttack { get; set; }

        public DateTime AttackDateTime { get; set; }

        #endregion
    }
}
