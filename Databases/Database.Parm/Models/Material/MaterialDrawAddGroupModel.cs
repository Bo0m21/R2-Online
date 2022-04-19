using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class MaterialDrawAddGroupModel
    {
        public long Mdrd { get; set; }
        public int AddGroup { get; set; }
        public int ResType { get; set; }
        public int MaxResCnt { get; set; }
        public float Success { get; set; }
        public string Desc { get; set; }
    }
}
