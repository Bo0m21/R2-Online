using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class QuestModel
    {
        public int QuestNo { get; set; }
        public string QuestNm { get; set; }
        public byte Class { get; set; }
        public short Level1 { get; set; }
        public short? Level2 { get; set; }
        public int PreQuestNo { get; set; }
        public byte IsOverlap { get; set; }
        public string QuestDesc { get; set; }
        public bool Abandonment { get; set; }
        public byte Difficulty { get; set; }
        public int RewardNo { get; set; }
        public byte ScriptType { get; set; }
        public short Place { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double PosZ { get; set; }
        public bool Visible { get; set; }
        public byte TextNo { get; set; }
        public int ParentNo { get; set; }
        public int FindNpc { get; set; }
        public int CompletionNpc { get; set; }
        public byte QuestKind { get; set; }
    }
}
