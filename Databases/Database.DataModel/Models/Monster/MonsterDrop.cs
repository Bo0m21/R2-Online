using System.Collections.Generic;

namespace Database.DataModel.Models
{
    public class MonsterDrop
    {
        public int MonsterId { get; set; }
        public int DropGroupId { get; set; }
        public byte Percent { get; set; }
        public DropGroup DropGroup { get; set; }
    }
}
