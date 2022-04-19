using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Parm.Models
{
    public partial class DialogModel
    {
        public DateTime RegDate { get; set; }
        public int MonsterId { get; set; }
        public string Click { get; set; }
        public string Die { get; set; }
        public string Attacked { get; set; }
        public string Target { get; set; }
        public string Bear { get; set; }
        public string Gossip1 { get; set; }
        public string Gossip2 { get; set; }
        public string Gossip3 { get; set; }
        public string Gossip4 { get; set; }
        public DateTime UptDate { get; set; }
    }
}
