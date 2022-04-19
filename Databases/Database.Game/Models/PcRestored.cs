using System;

namespace Database.Game.Models
{
    public partial class PcRestored
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public string PcNm { get; set; }
        public string PcRestoredOperator { get; set; }
    }
}
