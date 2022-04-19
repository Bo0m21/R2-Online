using Database.DataModel.Enums;

namespace Database.DataModel.Models
{
    public class DropItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public short Count { get; set; }
        public ItemStatusEnum Status { get; set; }
        public bool IsEvent { get; set; }
        public Item Item { get; set; }
    }
}
