using Database.DataModel.Enums;
using System.Collections.Generic;

namespace Database.DataModel.Models
{
    public class Monster
    {
        public Monster()
        {
            AbnormalAdds = new List<AbnormalAdd>();
            AbnormalResists = new List<AbnormalResist>();
            AttributeAdds = new List<AttributeAdd>();
            AttributeResists = new List<AttributeResist>();
            Drops = new List<MonsterDrop>();
            Protects = new List<Protect>();
            Slains = new List<Slain>();
            Roles = new List<NpcRoleEnum>();
            Spots = new List<MonsterSpot>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public PcClassEnum Class { get; set; }
        public ulong Exp { get; set; }
        public short Hit { get; set; }
        public short MinDamage { get; set; }
        public short MaxDamage { get; set; }
        public short AttackRateOrg { get; set; }
        public short MoveRateOrg { get; set; }
        public short AttackRateNew { get; set; }
        public short MoveRateNew { get; set; }
        public short HpMax { get; set; }
        public short MpMax { get; set; }
        public short MoveRange { get; set; }
        public GbjClassEnum Type { get; set; }
        public RaceTypeEnum RaceType { get; set; }
        public AiTypeEnum AiType { get; set; }
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
        public short DetectTransformF { get; set; }
        public short DetectTransformP { get; set; }
        public short DetectChaotic { get; set; }
        public AiTypeEnum AiEx { get; set; }
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
        public short WMapIconType { get; set; }
        public bool IsAmpliableTermOfValidity { get; set; }
        public AttackTypeEnum AttackType { get; set; }
        public byte TransType { get; set; }
        public short DPv { get; set; }
        public short MPv { get; set; }
        public short RPv { get; set; }
        public short DDv { get; set; }
        public short MDv { get; set; }
        public short RDv { get; set; }
        public short SubDDWhenCritical { get; set; }
        public short EnemySubCriticalHit { get; set; }
        public byte EventQuest { get; set; }

        public List<AbnormalAdd> AbnormalAdds { get; set; }
        public List<AbnormalResist> AbnormalResists { get; set; }
        public List<AttributeAdd> AttributeAdds { get; set; }
        public List<AttributeResist> AttributeResists { get; set; }
        public List<MonsterDrop> Drops { get; set; }
        public List<Protect> Protects { get; set; }
        public List<Slain> Slains { get; set; }
        public List<NpcRoleEnum> Roles { get; set; }
        public List<MonsterSpot> Spots { get; set; }
    }
}
