namespace Database.DataModel.Models
{
    public class DropGroupItem
    {
        public int DropItemId { get; set; }
        public float Percent { get; set; }
        public DropItem DropItem { get; set; }
    }
}
