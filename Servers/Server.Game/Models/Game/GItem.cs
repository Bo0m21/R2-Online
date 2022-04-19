using Database.DataModel.Enums;
using Database.DataModel.Models;
using Server.Game.Models.Game;
using System.Collections.Generic;

namespace Server.Game.Models.Game
{
    /// <summary>
    ///     Item game model
    /// </summary>
    public class GItem : Item
    {
        public GItem()
            : base()
        {

        }

        public GItem(Item parmItem)
            : base()
        {
            Id = parmItem.Id;
            EquipType = parmItem.GetEquipType();
            Type = parmItem.Type;
            Name = parmItem.Name;
            DPv = parmItem.DPv;
            MPv = parmItem.MPv;
            RPv = parmItem.RPv;
            DHit = parmItem.DHit;
            DDd = parmItem.DDd;
            RHit = parmItem.RHit;
            MHit = parmItem.MHit;
            Critical = parmItem.Critical;
            EnemySubCriticalHit = parmItem.EnemySubCriticalHit;
            AddDDWhenCritical = parmItem.AddDDWhenCritical;
            SubDDWhenCritical = parmItem.SubDDWhenCritical;
            Str = parmItem.Str;
            Dex = parmItem.Dex;
            Int = parmItem.Int;
            HpPlus = parmItem.HpPlus;
            HpRegen = parmItem.HpRegen;
            AddHpPotionRestore = parmItem.AddHpPotionRestore;
            AddMaxHpWhenTransform = parmItem.AddMaxHpWhenTransform;
            Mpplus = parmItem.Mpplus;
            MpRegen = parmItem.MpRegen;
            AddMpPotionRestore = parmItem.AddMpPotionRestore;
            AddMaxMpWhenTransform = parmItem.AddMaxMpWhenTransform;
            Weight = parmItem.Weight;
            AddWeight = parmItem.AddWeight;
            MaxStack = parmItem.MaxStack;
            AttackRate = parmItem.AttackRate;
            AddAttackRateWhenTransform = parmItem.AddAttackRateWhenTransform;
            MoveRate = parmItem.MoveRate;
            AddMoveRateWhenTransform = parmItem.AddMoveRateWhenTransform;
            AddShortAttackRange = parmItem.AddShortAttackRange;
            UseLevel = parmItem.UseLevel;
            UseInAttack = parmItem.UseInAttack;
            IsConfirm = parmItem.IsConfirm;

            TermOfValidity = parmItem.TermOfValidity;
        }
        public GItem(GItem model)
            : base()
        {
            Id = model.Id;
            EquipType = model.EquipType;
            Type = model.Type;
            Name = model.Name;

            

            DPv = model.DPv;
            MPv = model.MPv;
            RPv = model.RPv;
            DHit = model.DHit;
            DDd = model.DDd;
            RHit = model.RHit;
            MHit = model.MHit;
            Critical = model.Critical;
            EnemySubCriticalHit = model.EnemySubCriticalHit;
            AddDDWhenCritical = model.AddDDWhenCritical;
            SubDDWhenCritical = model.SubDDWhenCritical;
            Str = model.Str;
            Dex = model.Dex;
            Int = model.Int;
            HpPlus = model.HpPlus;
            HpRegen = model.HpRegen;
            AddHpPotionRestore = model.AddHpPotionRestore;
            AddMaxHpWhenTransform = model.AddMaxHpWhenTransform;
            Mpplus = model.Mpplus;
            MpRegen = model.MpRegen;
            AddMpPotionRestore = model.AddMpPotionRestore;
            AddMaxMpWhenTransform = model.AddMaxMpWhenTransform;
            Weight = model.Weight;
            AddWeight = model.AddWeight;
            MaxStack = model.MaxStack;
            AttackRate = model.AttackRate;
            AddAttackRateWhenTransform = model.AddAttackRateWhenTransform;
            MoveRate = model.MoveRate;
            AddMoveRateWhenTransform = model.AddMoveRateWhenTransform;
            AddShortAttackRange = model.AddShortAttackRange;
            UseLevel = model.UseLevel;
            UseInAttack = model.UseInAttack;

            SerialNumber = model.SerialNumber;
            EquipPos = model.EquipPos;
            Count = model.Count;
            IsConfirm = model.IsConfirm;
            EndTick = model.EndTick;
            UseCount = model.UseCount;
            EatTime = model.EatTime;
            TermOfValidity = model.TermOfValidity;
            ItemBind = model.ItemBind;
            Restore = model.Restore;
            Hole = model.Hole;
        }

        public ItemEquipTypeEnum EquipType { get; set; }
        public int DDdMin { get; set; }
        public int DDdMax { get; set; }
        public int RDdMin { get; set; }
        public int RDdMax { get; set; }
        public int MDdMin { get; set; }
        public int MDdMax { get; set; }
        public ItemEquipTypeEnum? EquipPos { get; set; }
        public int Count { get; set; }
        public uint EndTick { get; set; }
        public short UseCount { get; set; }
        public uint EatTime { get; set; }
        public ItemBindTypeEnum ItemBind { get; set; }
        public byte Restore { get; set; }
        public byte Hole { get; set; }

        

        public ulong SerialNumber { get; set; }
    }
}
