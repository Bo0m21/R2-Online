using System;
using System.Collections.Generic;


namespace Database.Game.Models
{
    public partial class PcAbnormal
    {
        public int PcNo { get; set; }
        public int ParmNo { get; set; }
        public int LeftTime { get; set; }
        public int AbParmNo { get; set; }
        public byte? RestoreCnt { get; set; }

        public virtual Pc PcNoNavigation { get; set; }
    }
}
