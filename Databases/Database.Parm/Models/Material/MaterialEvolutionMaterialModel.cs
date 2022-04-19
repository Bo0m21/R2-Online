using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialEvolutionMaterialModel
    {
        public long Meid { get; set; }
        public short Mtype { get; set; }
        public short Mlevel { get; set; }
        public short Mgrade { get; set; }
        public float? MSuccess { get; set; }
    }
}
