using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class DialogScriptModel
    {
        public DateTime RegDate { get; set; }
        public int MonsterId { get; set; }
        public string ScriptText { get; set; }
        public DateTime UptDate { get; set; }
    }
}
