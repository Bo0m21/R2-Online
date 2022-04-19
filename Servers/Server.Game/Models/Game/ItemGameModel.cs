using Database.Balance.Enums;
using Database.Balance.Models;
using Server.Game.Models.Game;
using System.Collections.Generic;

namespace Server.Game.Models.GameModels
{
    /// <summary>
    ///     Item game model
    /// </summary>
    public class ItemGameModel
    {
        public ItemGameModel()
        {
            Buffs = new List<BuffGameModel>();
        }
        public ItemGameModel(ItemGameModel model)
        {
            ItemId = model.ItemId;
            EquipType = model.EquipType;
            Type = model.Type;
            Name = model.Name;
            DDvMin = model.DDvMin;
            DDvMax = model.DDvMax;
            MDvMin = model.MDvMin;
            MDvMax = model.MDvMax;
            RDvMin = model.RDvMin;
            RDvMax = model.RDvMax;
            DPv = model.DPv;
            MPv = model.MPv;
            RPv = model.RPv;
            Dhit = model.Dhit;
            DDd = model.DDd;
            Rhit = model.Rhit;
            RDd = model.RDd;
            Mhit = model.Mhit;
            MDd = model.MDd;
            Critical = model.Critical;
            CriticalProtect = model.CriticalProtect;
            DDvCriticalAdd = model.DDvCriticalAdd;
            DDvCriticalRemove = model.DDvCriticalRemove;
            HumanKiller = model.HumanKiller;
            HumanProtect = model.HumanProtect;
            MobKiller = model.MobKiller;
            MobProtect = model.MobProtect;
            Str = model.Str;
            Dex = model.Dex;
            Int = model.Int;
            Hp = model.Hp;
            HpRegen = model.HpRegen;
            HpPotionRestore = model.HpPotionRestore;
            AddPotionRestoreHp = model.AddPotionRestoreHp;
            AddTransformMaxHp = model.AddTransformMaxHp;
            Mp = model.Mp;
            MpRegen = model.MpRegen;
            MpPotionRestore = model.MpPotionRestore;
            AddPotionRestoreMp = model.AddPotionRestoreMp;
            AddTransformMaxMp = model.AddTransformMaxMp;
            Weight = model.Weight;
            WeightMax = model.WeightMax;
            IsStack = model.IsStack;
            AttackRate = model.AttackRate;
            AttackRateWhenTransform = model.AttackRateWhenTransform;
            MoveRate = model.MoveRate;
            MoveRateWhenTransform = model.MoveRateWhenTransform;
            DistanceAttack = model.DistanceAttack;
            UseLevel = model.UseLevel;
            UseKnight = model.UseKnight;
            UseRanger = model.UseRanger;
            UseMagician = model.UseMagician;
            UseAssassin = model.UseAssassin;
            UseSummoner = model.UseSummoner;
            UseInAttack = model.UseInAttack;
            Percent = model.Percent;

            SerialNumber = model.SerialNumber;
            Id = model.Id;
            Position = model.Position;
            Count = model.Count;
            Flag = model.Flag;
            EndTick = model.EndTick;
            UseCount = model.UseCount;
            EatTime = model.EatTime;
            TermOfEffectivity = model.TermOfEffectivity;
            ItemBind = model.ItemBind;
            Restore = model.Restore;
            Hole = model.Hole;
        }

        #region Item common fields
        /// <summary>
        ///     Item id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///     Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Item status type
        /// </summary>
        public ItemStatusType ItemStatus { get; set; }

        /// <summary>
        ///     Item type
        /// </summary>
        public ItemType Type { get; set; }

        /// <summary>
        ///     Weight
        /// </summary>
        public short Weight { get; set; }

        /// <summary>
        ///     Is stack
        /// </summary>
        public bool IsStack { get; set; }
        #endregion

        #region Item database
        public int Id { get; set; }

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
        #endregion

        #region Item equip balance database
        /// <summary>
        ///     Type
        /// </summary>
        public ItemEquipType? EquipType { get; set; }

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
        ///     Health point
        /// </summary>
        public short Hp { get; set; }

        /// <summary>
        ///     Health point regen
        /// </summary>
        public short HpRegen { get; set; }

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
        ///     Magic point
        /// </summary>
        public short Mp { get; set; }

        /// <summary>
        ///     Magic point regen
        /// </summary>
        public short MpRegen { get; set; }

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
        ///     Weight max
        /// </summary>
        public short WeightMax { get; set; }

        /// <summary>
        ///     Attack rate
        /// </summary>
        public short AttackRate { get; set; }

        /// <summary>
        ///     Attack speed when transform
        /// </summary>
        public short AttackRateWhenTransform { get; set; }

        /// <summary>
        ///     Move rate
        /// </summary>
        public short MoveRate { get; set; }

        /// <summary>
        ///     Move speed when transform
        /// </summary>
        public short MoveRateWhenTransform { get; set; }

        /// <summary>
        ///     Distance attack
        /// </summary>
        public float DistanceAttack { get; set; }

        /// <summary>
        ///     Use level
        /// </summary>
        public short UseLevel { get; set; }

        /// <summary>
        ///   Use Knight
        /// </summary>
        public bool UseKnight { get; set; }

        /// <summary>
        ///     Use Ranger
        /// </summary>
        public bool UseRanger { get; set; }

        /// <summary>
        ///     Use Magician
        /// </summary>
        public bool UseMagician { get; set; }

        /// <summary>
        ///     Use Assassin
        /// </summary>
        public bool UseAssassin { get; set; }

        /// <summary>
        ///     Use Summoner
        /// </summary>
        public bool UseSummoner { get; set; }

        /// <summary>
        ///     Use in attack
        /// </summary>
        public bool UseInAttack { get; set; }
        #endregion

        #region Item material balance database
        /// <summary>
        ///     Percent
        /// </summary>
        public float Percent { get; set; }
        #endregion

        #region Default fields
        /// <summary>
        ///     Serial number
        /// </summary>
        public ulong SerialNumber { get; set; }

        public List<BuffGameModel> Buffs { get; set; }
        #endregion
    }
}
