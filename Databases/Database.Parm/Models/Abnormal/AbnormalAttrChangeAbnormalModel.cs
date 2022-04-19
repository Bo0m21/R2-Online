using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class AbnormalAttrChangeAbnormalModel
    {
        public int MId { get; set; }
        public int MOriginAid { get; set; }
        public int MEffectAid { get; set; }
        public byte MConditionType { get; set; }
        public int MConditionAid { get; set; }
        public string MDesc { get; set; }
        public int MConditionAtype { get; set; }
    }
}
