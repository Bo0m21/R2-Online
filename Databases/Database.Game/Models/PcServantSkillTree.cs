using System;

namespace Database.Game.Models
{
    public partial class PcServantSkillTree
    {
        public DateTime RegDate { get; set; }
        public long SerialNo { get; set; }
        public int Stid { get; set; }
        public int Stniid { get; set; }
        public DateTime EndDate { get; set; }
    }
}
