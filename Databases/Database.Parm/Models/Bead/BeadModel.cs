using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class BeadModel
    {
        public int ItemId { get; set; }
        public int TargetIpos { get; set; }
        public double Prob { get; set; }
        public short Group { get; set; }
        public int ItemSubType { get; set; }
    }
}
