using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillEnhancementMaterialModel
    {
        public int EskillPackId { get; set; }
        public byte OrderNo { get; set; }
        public int ItemId { get; set; }
        public int Cnt { get; set; }
    }
}
