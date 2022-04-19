using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class AbnormalAttrDetachModel
    {
        public int MId { get; set; }
        public byte MAppType { get; set; }
        public int MOriginAid { get; set; }
        public int MEffectAtype { get; set; }
        public byte MConditionType { get; set; }
        public int MConditionAtype { get; set; }
        public string MDesc { get; set; }
        public int MEffectAid { get; set; }
    }
}
