using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialItemInfoModel
    {
        public int ItemId { get; set; }
        public short Mtype { get; set; }
        public short Mgrade { get; set; }
        public short Mlevel { get; set; }
        public short Menchant { get; set; }
    }
}
