using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialEvolutionResultModel
    {
        public long Meid { get; set; }
        public int ItemId { get; set; }
        public float? MPercent { get; set; }
    }
}
