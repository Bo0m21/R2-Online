using Database.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataModel.Models
{
    public class Item
    {
        public Item()
        {
            AbnormalAdds = new List<AbnormalAdd>();
            AbnormalResists = new List<AbnormalResist>();
            AttributeAdds = new List<AttributeAdd>();
            AttributeResists = new List<AttributeResist>();
            BeadEffects = new List<BeadEffect>();
            ItemPanalties = new List<ItemPanalty>();
            Modules = new List<Module>();
            Protects = new List<Protect>();
            Skills = new List<Skill>();
            Slains = new List<Slain>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ItemTypeEnum Type { get; set; }
        public byte Level { get; set; }
        public short DHit { get; set; }
        public string DDd { get; set; }
        public short RHit { get; set; }
        public string RDd { get; set; }
        public short MHit { get; set; }
        public string MDd { get; set; }
        public short HpPlus { get; set; }
        public short Mpplus { get; set; }
        public short Str { get; set; }
        public short Dex { get; set; }
        public short Int { get; set; }
        public short DPv { get; set; }
        public short MPv { get; set; }
        public short RPv { get; set; }
        public short DDv { get; set; }
        public short MDv { get; set; }
        public short RDv { get; set; }
        public short HDPv { get; set; }
        public short HMPv { get; set; }
        public short HRPv { get; set; }
        public short HDDv { get; set; }
        public short HMDv { get; set; }
        public short HRDv { get; set; }
        public int MaxStack { get; set; }
        public short Weight { get; set; }
        public UseTypeEnum UseType { get; set; }
        public int UseNum { get; set; }
        public int Recycle { get; set; }
        public byte HpRegen { get; set; }
        public byte MpRegen { get; set; }
        public byte AttackRate { get; set; }
        public byte MoveRate { get; set; }
        public byte Critical { get; set; }
        public short TermOfValidity { get; set; }
        public short TermOfValidityMi { get; set; }
        public string Desc { get; set; }
        public ItemStatusEnum Status { get; set; }
        public int FakeId { get; set; }
        public string FakeName { get; set; }
        public string UseMsg { get; set; }
        public short Range { get; set; }
        public UseClassEnum UseClass { get; set; }
        public int DropEffect { get; set; }
        public short UseLevel { get; set; }
        public byte UseEternal { get; set; }
        public int UseDelay { get; set; }
        public bool UseInAttack { get; set; }
        public bool IsEvent { get; set; }
        public bool IsIndict { get; set; }
        public short AddWeight { get; set; }
        public ItemSubTypeEnum SubType { get; set; }
        public bool IsCharge { get; set; }
        public long NationOp { get; set; }
        public byte PshopItemType { get; set; }
        public int QuestNo { get; set; }
        public bool IsTest { get; set; }
        public byte QuestNeedCnt { get; set; }
        public byte ContentsLv { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsSealable { get; set; }
        public short AddDDWhenCritical { get; set; }
        public byte SealRemovalNeedCnt { get; set; }
        public bool IsPracticalPeriod { get; set; }
        public bool IsReceiveTown { get; set; }
        public bool IsReinforceDestroy { get; set; }
        public short AddHpPotionRestore { get; set; }
        public short AddMpPotionRestore { get; set; }
        public short AddMaxHpWhenTransform { get; set; }
        public short AddMaxMpWhenTransform { get; set; }
        public short AddAttackRateWhenTransform { get; set; }
        public short AddMoveRateWhenTransform { get; set; }
        public byte SupportType { get; set; }
        public short TermOfValidityLv { get; set; }
        public bool IsUseableUtgwsvr { get; set; }
        public short AddShortAttackRange { get; set; }
        public short AddLongAttackRange { get; set; }
        public short WeaponPoisonType { get; set; }
        public short SubDDWhenCritical { get; set; }
        public short GetItemFeedback { get; set; }
        public short EnemySubCriticalHit { get; set; }
        public bool IsPartyDrop { get; set; }
        public byte MaxBeadHoleCount { get; set; }
        public int SubTypeOption { get; set; }

        public List<AbnormalAdd> AbnormalAdds { get; set; }
        public List<AbnormalResist> AbnormalResists { get; set; }
        public List<AttributeAdd> AttributeAdds { get; set; }
        public List<AttributeResist> AttributeResists { get; set; }
        public List<BeadEffect> BeadEffects { get; set; }
        public List<ItemPanalty> ItemPanalties { get; set; }
        public List<Module> Modules { get; set; }
        public List<Protect> Protects { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Slain> Slains { get; set; }

        public ItemEquipTypeEnum GetEquipType()
        {
            ItemEquipTypeEnum equipTypeEnum = ItemEquipTypeEnum.NotEquipped;
            switch (this.Type)
            {
                case ItemTypeEnum.Weapon:
                    equipTypeEnum = ItemEquipTypeEnum.Weapon;
                    break;
                case ItemTypeEnum.Shield:
                    equipTypeEnum = ItemEquipTypeEnum.Shield;
                    break;
                case ItemTypeEnum.Armor:
                    equipTypeEnum = ItemEquipTypeEnum.Armor;
                    break;
                case ItemTypeEnum.Ring:
                    equipTypeEnum = ItemEquipTypeEnum.Ring1;
                    break;
                case ItemTypeEnum.Amulet:
                    equipTypeEnum = ItemEquipTypeEnum.Amulet;
                    break;
                case ItemTypeEnum.Boot:
                    equipTypeEnum = ItemEquipTypeEnum.Boot;
                    break;
                case ItemTypeEnum.Glove:
                    equipTypeEnum = ItemEquipTypeEnum.Glove;
                    break;
                case ItemTypeEnum.Cap:
                    equipTypeEnum = ItemEquipTypeEnum.Cap;
                    break;
                case ItemTypeEnum.Belt:
                    equipTypeEnum = ItemEquipTypeEnum.Belt;
                    break;
                case ItemTypeEnum.Cloak:
                    equipTypeEnum = ItemEquipTypeEnum.Cloak;
                    break;
                case ItemTypeEnum.Arrow:
                    equipTypeEnum = ItemEquipTypeEnum.Shield;
                    break;
                case ItemTypeEnum.ExpertnessMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.ExpertnessMaterial;
                    break;
                case ItemTypeEnum.SoulMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.SoulMaterial;
                    break;
                case ItemTypeEnum.DefenseMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.DefenseMaterial;
                    break;
                case ItemTypeEnum.AttackMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.AttackMaterial;
                    break;
                case ItemTypeEnum.LifeMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.LifeMaterial;
                    break;
                case ItemTypeEnum.EventAMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.EventAMaterial;
                    break;
                case ItemTypeEnum.EventBMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.EventBMaterial;
                    break;
                case ItemTypeEnum.EventCMaterial:
                    equipTypeEnum = ItemEquipTypeEnum.EventCMaterial;
                    break;
                case ItemTypeEnum.Servant:
                    equipTypeEnum = ItemEquipTypeEnum.Servant;
                    break;
                default:
                    break;
            }

            return equipTypeEnum;
        }
    }
}
