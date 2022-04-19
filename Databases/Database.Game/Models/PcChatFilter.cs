using System;

namespace Database.Game.Models
{
    public partial class PcChatFilter
    {
        public DateTime RegDate { get; set; }
        public int OwnerPcNo { get; set; }
        public int ChatFilterPcNo { get; set; }
        public string ChatFilterPcNm { get; set; }

        public virtual Pc OwnerPcNoNavigation { get; set; }
    }
}
