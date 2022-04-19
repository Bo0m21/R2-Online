using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class RefineCreateInfoModel
    {
        public int Idx { get; set; }
        public int RefineId { get; set; }
        public byte Group1 { get; set; }
        public byte Group2 { get; set; }
        public byte Sort { get; set; }
        public int ItemId0 { get; set; }
        public int ItemId1 { get; set; }
        public int ItemId2 { get; set; }
        public int ItemId3 { get; set; }
        public int Cost { get; set; }
    }
}
