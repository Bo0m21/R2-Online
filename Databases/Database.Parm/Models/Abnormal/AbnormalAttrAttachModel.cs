using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class AbnormalAttrAttachModel
    {
        public int MId { get; set; }
        public int MOriginAid { get; set; }
        public int MEffectAid { get; set; }
        public byte MConditionType { get; set; }
        public int MConditionAtype { get; set; }
        public string MDesc { get; set; }
    }
}
