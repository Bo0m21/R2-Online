using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillEnhancementModel
    {
        public int EnhancementSkillPackId { get; set; }
        public int SkillPackId { get; set; }
        public byte OrderNo { get; set; }
        public byte UseClass { get; set; }
    }
}
