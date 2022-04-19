using System;

namespace Database.Game.Models
{
    public partial class PcGoldItemEffect
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public int ItemType { get; set; }
        public double ParmA { get; set; }
        public DateTime EndDate { get; set; }
        public int ItemNo { get; set; }
    }
}
