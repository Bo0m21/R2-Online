using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialDrawMaterialModel
    {
        public int Seq { get; set; }
        public long Mdid { get; set; }
        public int ItemId { get; set; }
        public int Cnt { get; set; }
    }
}
