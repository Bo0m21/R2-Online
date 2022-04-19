using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class QuestInfoModel
    {
        public int QuestNo { get; set; }
        public byte Type { get; set; }
        public int? ParmA { get; set; }
        public int? ParmB { get; set; }
        public int? ParmC { get; set; }
        public string Desc { get; set; }
        public int SeqNo { get; set; }
    }
}
