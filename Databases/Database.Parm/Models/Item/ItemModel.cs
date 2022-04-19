using System;
using System.Collections.Generic;

namespace Database.Parm.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public byte Level { get; set; }
        public short Dhit { get; set; }
        public string DDd { get; set; }
        public short Rhit { get; set; }
        public string Rdd { get; set; }
        public short Mhit { get; set; }
        public string Mdd { get; set; }
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
        public short Hdpv { get; set; }
        public short Hmpv { get; set; }
        public short Hrpv { get; set; }
        public short Hddv { get; set; }
        public short Hmdv { get; set; }
        public short Hrdv { get; set; }
        public int MaxStack { get; set; }
        public short Weight { get; set; }
        public int UseType { get; set; }
        public int UseNum { get; set; }
        public int Recycle { get; set; }
        public byte HpRegen { get; set; }
        public byte Mpregen { get; set; }
        public byte AttackRate { get; set; }
        public byte MoveRate { get; set; }
        public byte Critical { get; set; }
        public short TermOfValidity { get; set; }
        public short TermOfValidityMi { get; set; }
        public string Desc { get; set; }
        public byte Status { get; set; }
        public int FakeId { get; set; }
        public string FakeName { get; set; }
        public string UseMsg { get; set; }
        public short Range { get; set; }
        public byte UseClass { get; set; }
        public int DropEffect { get; set; }
        public short UseLevel { get; set; }
        public byte UseEternal { get; set; }
        public int UseDelay { get; set; }
        public byte UseInAttack { get; set; }
        public bool IsEvent { get; set; }
        public bool IsIndict { get; set; }
        public short AddWeight { get; set; }
        public short SubType { get; set; }
        public bool IsCharge { get; set; }
        public long NationOp { get; set; }
        public byte PshopItemType { get; set; }
        public int QuestNo { get; set; }
        public bool IsTest { get; set; }
        public byte QuestNeedCnt { get; set; }
        public byte ContentsLv { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsSealable { get; set; }
        public short AddDdwhenCritical { get; set; }
        public byte SealRemovalNeedCnt { get; set; }
        public bool IsPracticalPeriod { get; set; }
        public bool IsReceiveTown { get; set; }
        public bool IsReinforceDestroy { get; set; }
        public short AddPotionRestore { get; set; }
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
        public short SubDdwhenCritical { get; set; }
        public short GetItemFeedback { get; set; }
        public short EnemySubCriticalHit { get; set; }
        public bool IsPartyDrop { get; set; }
        public byte MaxBeadHoleCount { get; set; }
        public int SubTypeOption { get; set; }
    }
}
