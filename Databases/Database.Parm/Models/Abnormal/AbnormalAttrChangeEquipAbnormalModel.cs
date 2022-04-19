using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class AbnormalAttrChangeEquipAbnormalModel
    {
        public int MId { get; set; }
        public int MConditionAid { get; set; }
        public int MOriginAtype { get; set; }
        public int MOriginAitemNo { get; set; }
        public int MEffectAid { get; set; }
        public string MDesc { get; set; }
    }
}
