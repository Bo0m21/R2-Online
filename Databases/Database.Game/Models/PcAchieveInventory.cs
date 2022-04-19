using System;

namespace Database.Game.Models
{
    public partial class PcAchieveInventory
    {
        public DateTime RegDate { get; set; }
        public long SerialNo { get; set; }
        public int PcNo { get; set; }
        public int ItemNo { get; set; }
        public int AchieveGuildId { get; set; }
        public int CoinPoint { get; set; }
        public byte SlotNo { get; set; }
        public byte AchieveId { get; set; }
        public int Exp { get; set; }
        public byte LimitLevel { get; set; }
        public bool IsSeizure { get; set; }
    }
}
