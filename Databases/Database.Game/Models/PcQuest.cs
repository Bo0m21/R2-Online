using System;

namespace Database.Game.Models
{
    public partial class PcQuest
    {
        public int PcNo { get; set; }
        public int QuestNo { get; set; }
        public int Value { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LimitTime { get; set; }
    }
}
