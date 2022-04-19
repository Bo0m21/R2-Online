using System;

namespace Database.Game.Models
{
    public partial class PcBead
    {
        public DateTime RegDate { get; set; }
        public long OwnerSerialNo { get; set; }
        public byte BeadIndex { get; set; }
        public int ItemNo { get; set; }
        public DateTime EndDate { get; set; }
        public short CntUse { get; set; }
    }
}
