using System;

namespace Database.Game.Models
{
    public partial class PcSkillTreeInventory
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public int Stniid { get; set; }
        public DateTime EndDate { get; set; }
    }
}
