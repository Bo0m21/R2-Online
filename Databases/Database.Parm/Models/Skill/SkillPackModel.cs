using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class SkillPackModel
    {
        public int SkillPackId { get; set; }
        public string Name { get; set; }
        public int Itype { get; set; }
        public int IuseType { get; set; }
        public short IsubType { get; set; }
        public short TermOfValidity { get; set; }
        public string Desc { get; set; }
        public string UseMsg { get; set; }
        public short UseRange { get; set; }
        public byte UseClass { get; set; }
        public short UseLevel { get; set; }
        public string SpriteFile { get; set; }
        public int SpriteX { get; set; }
        public int SpriteY { get; set; }
        public bool IsUseableUtgwsvr { get; set; }
        public byte UseInAttack { get; set; }
        public bool? IsDrop { get; set; }
    }
}
