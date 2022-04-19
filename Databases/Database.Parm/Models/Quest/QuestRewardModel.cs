using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class QuestRewardModel
    {
        public int RewardNo { get; set; }
        public long Exp { get; set; }
        public int Id { get; set; }
        public int Cnt { get; set; }
        public byte Binding { get; set; }
        public byte Status { get; set; }
        public int EffTime { get; set; }
        public int ValTime { get; set; }
    }
}
