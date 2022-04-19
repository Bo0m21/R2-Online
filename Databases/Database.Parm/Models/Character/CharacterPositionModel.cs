using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class CharacterPositionModel
    {
        public int Id { get; set; }
        public int Class { get; set; }
        public float X { get; set; }
        public float Z { get; set; }
        public float Y { get; set; }
    }
}
