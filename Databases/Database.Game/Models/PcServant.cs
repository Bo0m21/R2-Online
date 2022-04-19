using System;

namespace Database.Game.Models
{
    public partial class PcServant
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public long SerialNo { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
        public long Exp { get; set; }
        public short Friendly { get; set; }
        public short SkillPoint { get; set; }
        public int SkillTreePoint { get; set; }
        public bool IsRestore { get; set; }
    }
}
