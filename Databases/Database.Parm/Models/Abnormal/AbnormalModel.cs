using Database.DataModel.Enums;

namespace Database.Parm.Models
{
    public partial class AbnormalModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public byte Level { get; set; }
        public byte Percent { get; set; }
        public int Time { get; set; }
        public byte Grade { get; set; }
        public string Desc { get; set; }
    }
}
