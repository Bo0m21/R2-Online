namespace Database.Parm.Models
{
    public partial class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short HitPlus { get; set; }
        public short MpperUse { get; set; }
        public short SpellNum { get; set; }
        public string Desc { get; set; }
        public short Type { get; set; }
        public short HpperUse { get; set; }
        public short ChaoUse { get; set; }
        public short ApplyRadius { get; set; }
        public short ApplyCnt { get; set; }
        public byte ApplyRace { get; set; }
        public short CastingDelay { get; set; }
        public int ConsumeItem { get; set; }
        public byte ConsumeItemCnt { get; set; }
        public short ActiveType { get; set; }
        public string Animation { get; set; }
        public short CastingSpeed { get; set; }
        public short SkillEffect { get; set; }
        public int CamShakeWhenHit { get; set; }
        public byte CriticalEffectWhenHit { get; set; }
        public bool ActiveWeapon { get; set; }
        public int CoolTime { get; set; }
        public short CastingGroup { get; set; }
        public short CoolTimeGroup { get; set; }
        public int ConsumeItem2 { get; set; }
        public byte ConsumeItemCnt2 { get; set; }
        public bool IsCancel { get; set; }
        public bool IsAttack { get; set; }
    }
}
