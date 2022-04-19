namespace Database.Game.Models
{
    public partial class PcCoolTime
    {
        public int PcNo { get; set; }
        public int Sid { get; set; }
        public short CoolTimeGroup { get; set; }
        public int RemainTime { get; set; }
    }
}
