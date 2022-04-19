using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class RefineMaterialModel
    {
        public int? RefineId { get; set; }
        public int? ItemId { get; set; }
        public int? Count { get; set; }
        public byte OrderNo { get; set; }
    }
}
