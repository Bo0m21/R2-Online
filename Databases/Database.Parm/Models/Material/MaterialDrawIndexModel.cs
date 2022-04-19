using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialDrawIndexModel
    {
        public long Mdid { get; set; }
        public long Mdrd { get; set; }
        public int ResType { get; set; }
        public int MaxResCnt { get; set; }
        public float? Success { get; set; }
        public string Desc { get; set; }
        public short AddQuestionMark { get; set; }
    }
}
