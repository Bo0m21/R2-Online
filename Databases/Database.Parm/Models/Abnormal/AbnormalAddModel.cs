using Database.DataModel.Enums;

namespace Database.Parm.Models
{
    public partial class AbnormalAddModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public byte Level { get; set; }
        public byte Percent { get; set; }
    }
}
