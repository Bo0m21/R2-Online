using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillTreeNodeModel
    {
        public int SkillTreeNodeId { get; set; }
        public int SkillTreeId { get; set; }
        public string Name { get; set; }
        public short MaxLevel { get; set; }
        public byte NodeType { get; set; }
        public short IconSlotX { get; set; }
        public short IconSlotY { get; set; }
        public byte LineN { get; set; }
        public byte LineE { get; set; }
        public byte LineS { get; set; }
        public byte LineW { get; set; }
        public short TermOfValidity { get; set; }
    }
}
