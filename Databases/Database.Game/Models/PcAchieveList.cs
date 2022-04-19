using System;

namespace Database.Game.Models
{
    public partial class PcAchieveList
    {
        public int Id { get; set; }
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public byte AchieveId { get; set; }
        public short ActionCount { get; set; }
        public bool IsComplete { get; set; }
        public bool IsNew { get; set; }
        public long SerialNo { get; set; }
    }
}
