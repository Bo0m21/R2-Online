using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillResourceModel
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public int? Type { get; set; }
        public string FileName { get; set; }
        public int? PosX { get; set; }
        public int? PosY { get; set; }
    }
}
