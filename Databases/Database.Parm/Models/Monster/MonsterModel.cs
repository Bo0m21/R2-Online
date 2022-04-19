using System;
using System.Collections.Generic;

namespace Database.Parm.Models
{
    public partial class MonsterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Class { get; set; }
        public long Exp { get; set; }
        public short Hit { get; set; }
        public short MinD { get; set; }
        public short MaxD { get; set; }
        public short AttackRateOrg { get; set; }
        public short MoveRateOrg { get; set; }
        public short AttackRateNew { get; set; }
        public short MoveRateNew { get; set; }
        public short Hp { get; set; }
        public short Mp { get; set; }
        public short MoveRange { get; set; }
        public short GbjType { get; set; }
        public short RaceType { get; set; }
        public short AiType { get; set; }
        public short CastingDelay { get; set; }
        public short Chaotic { get; set; }
        public int SameRace1 { get; set; }
        public int SameRace2 { get; set; }
        public int SameRace3 { get; set; }
        public int SameRace4 { get; set; }
        public int SightRange { get; set; }
        public int AttackRange { get; set; }
        public int SkillRange { get; set; }
        public int BodySize { get; set; }
        public short DetectTransF { get; set; }
        public short DetectTransP { get; set; }
        public short DetectChao { get; set; }
        public int AiEx { get; set; }
        public double Scale { get; set; }
        public bool IsResistTransF { get; set; }
        public bool IsEvent { get; set; }
        public bool IsTest { get; set; }
        public short HpNew { get; set; }
        public short MpNew { get; set; }
        public int BuyMerchanId { get; set; }
        public int SellMerchanId { get; set; }
        public int ChargeMerchanId { get; set; }
        public short TransformWeight { get; set; }
        public long NationOp { get; set; }
        public short HpRegen { get; set; }
        public short MpRegen { get; set; }
        public byte ContentsLv { get; set; }
        public bool IsEventTest { get; set; }
        public bool IsShowHp { get; set; }
        public byte SupportType { get; set; }
        public short VolitionOfHonor { get; set; }
        public short WmapIconType { get; set; }
        public bool IsAmpliableTermOfValidity { get; set; }
        public byte AttackType { get; set; }
        public byte TransType { get; set; }
        public short DPv { get; set; }
        public short MPv { get; set; }
        public short RPv { get; set; }
        public short DDv { get; set; }
        public short MDv { get; set; }
        public short RDv { get; set; }
        public short SubDDwhenCritical { get; set; }
        public short EnemySubCriticalHit { get; set; }
        public byte EventQuest { get; set; }
    }
}
