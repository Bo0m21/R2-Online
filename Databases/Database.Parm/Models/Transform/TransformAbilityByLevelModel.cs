using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class TransformAbilityByLevelModel
    {
        public int Level { get; set; }
        public short MaxHp { get; set; }
        public short MaxMp { get; set; }
        public short MaxWeight { get; set; }
        public short ShortAttackRate { get; set; }
        public short LongAttackRate { get; set; }
        public short MoveRate { get; set; }
        public int Type { get; set; }
    }
}
