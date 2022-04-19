using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillTreeNodeItemConditionModel
    {
        public int SkillTreeNodeItemId { get; set; }
        public int SkillTreeNodeItemConditionType { get; set; }
        public int ParamA { get; set; }
        public int ParamB { get; set; }
        public int ParamC { get; set; }
    }
}
