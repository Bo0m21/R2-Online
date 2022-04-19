using System;

namespace Database.Game.Models
{
    public partial class PcEquip
    {
        public DateTime RegDate { get; set; }
        public int Owner { get; set; }
        public int Slot { get; set; }
        public long SerialNo { get; set; }

        public virtual PcInventory SerialNoNavigation { get; set; }
        public virtual Pc PcNoNavigation { get; set; }
    }
}
