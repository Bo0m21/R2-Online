using System;
using System.Collections.Generic;

namespace Database.Game.Models
{
    public partial class PcInventory
    {
        public PcInventory()
        {
            PcEquips = new HashSet<PcEquip>();
        }

        public DateTime RegDate { get; set; }
        public long SerialNo { get; set; }
        public int PcNo { get; set; }
        public int ItemNo { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirm { get; set; }
        public byte Status { get; set; }
        public int Cnt { get; set; }
        public short CntUse { get; set; }
        public bool IsSeizure { get; set; }
        public int ApplyAbnItemNo { get; set; }
        public DateTime ApplyAbnItemEndDate { get; set; }
        public int Owner { get; set; }
        public int PracticalPeriod { get; set; }
        public byte BindingType { get; set; }
        public byte RestoreCnt { get; set; }
        public byte HoleCount { get; set; }

        public virtual ICollection<PcEquip> PcEquips { get; set; }
        public virtual Pc PcNoNavigation { get; set; }

    }
}
