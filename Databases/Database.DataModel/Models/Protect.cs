using Database.DataModel.Enums;

namespace Database.DataModel.Models
{
    public class Protect
    {
        public int Id { get; set; }
        public RaceTypeEnum Type { get; set; }
        public short Level { get; set; }
        public short DPv { get; set; }
        public short MPv { get; set; }
        public short RPv { get; set; }
        public short DDv { get; set; }
        public short MDv { get; set; }
        public short RDv { get; set; }
    }
}
