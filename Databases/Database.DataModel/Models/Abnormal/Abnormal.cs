using Database.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataModel.Models
{
    public class Abnormal
    {
        public int Id { get; set; }
        public AbnormalTypeEnum Type { get; set; }
        public byte Level { get; set; }
        public byte Percent { get; set; }
        public int Time { get; set; }
        public byte Grade { get; set; }
        public string Desc { get; set; }
    }
}
