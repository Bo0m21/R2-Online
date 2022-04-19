using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class RegionQuestConditionModel
    {
        public int QuestNo { get; set; }
        public int ParmId { get; set; }
        public bool Boss { get; set; }
        public byte StepCnt { get; set; }
        public short Step1 { get; set; }
        public short Step2 { get; set; }
        public short Step3 { get; set; }
        public short TotalCnt { get; set; }
    }
}
