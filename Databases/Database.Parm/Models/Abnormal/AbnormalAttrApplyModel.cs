using System;
using System.Collections.Generic;

namespace Database.Parm.Models
{
    public partial class AbnormalAttrApplyModel
    {
        public int MId { get; set; }
        public int MOriginAid { get; set; }
        public byte MOriginAtype { get; set; }
        public int MConditionAid { get; set; }
        public string MDesc { get; set; }
    }
}
