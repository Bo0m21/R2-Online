using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialDrawResultModel
    {
        public int Seq { get; set; }
        public long Mdrd { get; set; }
        public int ItemId { get; set; }
        public float? PerOrRate { get; set; }
        public byte ItemStatus { get; set; }
        public int Cnt { get; set; }
        public int Binding { get; set; }
        public int EffTime { get; set; }
        public short ValTime { get; set; }
        public int Resource { get; set; }
        public byte AddGroup { get; set; }
    }
}
