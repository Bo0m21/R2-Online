using System;

namespace Database.Game.Models
{
    public partial class PcSkillPackInventory
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public int Spid { get; set; }
        public DateTime EndDate { get; set; }
    }
}
