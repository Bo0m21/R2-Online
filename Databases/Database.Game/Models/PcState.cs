using System;

namespace Database.Game.Models
{
    public partial class PcState
    {
        public int No { get; set; }
        public short Level { get; set; }
        public long Exp { get; set; }
        public int HpAdd { get; set; }
        public int Hp { get; set; }
        public int MpAdd { get; set; }
        public int Mp { get; set; }
        public int MapNo { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public short Stomach { get; set; }
        public string Ip { get; set; }
        public DateTime? LoginTm { get; set; }
        public DateTime? LogoutTm { get; set; }
        public int TotUseTm { get; set; }
        public int PkCnt { get; set; }
        public int Chaotic { get; set; }
        public int DiscipleJoinCount { get; set; }
        public int PartyMemCntLevel { get; set; }
        public long LostExp { get; set; }
        public bool IsLetterLimit { get; set; }
        public short Flag { get; set; }
        public bool? IsPreventItemDrop { get; set; }
        public short SkillTreePoint { get; set; }
        public long RestExpGuild { get; set; }
        public long RestExpActivate { get; set; }
        public long RestExpDeactivate { get; set; }
        public short Qmcnt { get; set; }
        public short GuildQmcnt { get; set; }

        public virtual Pc NoNavigation { get; set; }
    }
}
