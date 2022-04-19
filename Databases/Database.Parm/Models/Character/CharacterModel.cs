using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class CharacterModel
    {
        public int Id { get; set; }
        public int Class { get; set; }
        public short Level { get; set; }
        public int DPv { get; set; }
        public int MPv { get; set; }
        public int RPv { get; set; }
        public int Dhit { get; set; }
        public int DDd { get; set; }
        public int Rhit { get; set; }
        public int RDd { get; set; }
        public int Mhit { get; set; }
        public int MDd { get; set; }
        public short Str { get; set; }
        public short Dex { get; set; }
        public short Int { get; set; }
        public short HpMax { get; set; }
        public short HpRegen { get; set; }
        public short MpMax { get; set; }
        public short MpRegen { get; set; }
        public short WeightMax { get; set; }
        public short AttackRate { get; set; }
        public short MoveRate { get; set; }
        public int DDvMax { get; set; }
        public int DDvMin { get; set; }
        public int MDvMax { get; set; }
        public int MDvMin { get; set; }
        public int RDvMax { get; set; }
        public int RDvMin { get; set; }
    }
}
