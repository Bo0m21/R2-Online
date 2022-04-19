using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class RegionOptionModel
    {
        public int Place { get; set; }
        public bool IsSupport { get; set; }
        public double ExpRate { get; set; }
        public double MonsterItemDropRate { get; set; }
        public bool ShowPlayerName { get; set; }
        public double MonSilverDropRate { get; set; }
        public bool NoDropItemOnDeath { get; set; }
        public bool NoExpDescOnDeath { get; set; }
    }
}
