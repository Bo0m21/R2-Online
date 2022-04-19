using System;

namespace Database.Game.Models
{
    public partial class PcDeleted
    {
        public DateTime RegDate { get; set; }
        public int PcNo { get; set; }
        public string PcNm { get; set; }

        public virtual Pc PcNoNavigation { get; set; }
    }
}
