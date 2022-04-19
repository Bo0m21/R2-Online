using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataModel.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public byte Level { get; set; }
        public string DiceDamage { get; set; }
        public short Damage { get; set; }
    }
}
