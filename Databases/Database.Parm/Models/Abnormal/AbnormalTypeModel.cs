using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class AbnormalTypeModel
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
        public bool Removable { get; set; }
        public string FileName { get; set; }
        public short IconX { get; set; }
        public short IconY { get; set; }
        public bool Copyable { get; set; }
    }
}
