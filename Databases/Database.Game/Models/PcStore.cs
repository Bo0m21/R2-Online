using System;

namespace Database.Game.Models
{
    public partial class PcStore
    {
        public DateTime RegDate { get; set; }
        public long SerialNo { get; set; }
        public int UserNo { get; set; }
        public int ItemNo { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirm { get; set; }
        public byte Status { get; set; }
        public int Cnt { get; set; }
        public short? CntUse { get; set; }
        public bool IsSeizure { get; set; }
        public int ApplyAbnItemNo { get; set; }
        public DateTime ApplyAbnItemEndDate { get; set; }
        public int Owner { get; set; }
        public int PracticalPeriod { get; set; }
        public byte BindingType { get; set; }
        public byte RestoreCnt { get; set; }
        public byte HoleCount { get; set; }
    }
}
