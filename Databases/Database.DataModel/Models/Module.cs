using Database.DataModel.Enums;

namespace Database.DataModel.Models
{
    public class Module
    {
        public int Id { get; set; }
        public ModuleTypeEnum Type { get; set; }
        public short Level { get; set; }
        public int AParam { get; set; }
        public int BParam { get; set; }
        public int CParam { get; set; }
    }
}
