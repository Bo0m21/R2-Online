using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class QuestConditionModel
    {
        public int QuestNo { get; set; }
        public byte Type { get; set; }
        public int Id { get; set; }
        public int Cnt { get; set; }
        public string Desc { get; set; }
        public int SeqNo { get; set; }
    }
}
