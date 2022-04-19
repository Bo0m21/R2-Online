using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillTreeNodeItemModel
    {
        public int SkillTreeNodeItemId { get; set; }
        public int SkillTreeNodeId { get; set; }
        public int SkillPackId { get; set; }
        public short Level { get; set; }
    }
}
