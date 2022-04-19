using Database.DataModel.Enums;

namespace Database.DataModel.Models
{
    public class Slain
    {
        public int Id { get; set; }
        public RaceTypeEnum Type { get; set; }
        public byte Level { get; set; }
        public short HitPlus { get; set; }
        public short Ddplus { get; set; }
        public short Rddplus { get; set; }
        public short RhitPlus { get; set; }
    }
}
