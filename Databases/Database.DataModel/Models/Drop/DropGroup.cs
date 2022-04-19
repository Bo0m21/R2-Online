using System.Collections.Generic;

namespace Database.DataModel.Models
{
    public class DropGroup
    {
        public DropGroup()
        {
            Items = new List<DropGroupItem>();
        }
        public int DropGroupId { get; set; }
        public List<DropGroupItem> Items { get; set; }
    }
}
