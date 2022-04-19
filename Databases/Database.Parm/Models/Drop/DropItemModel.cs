namespace Database.Parm.Models
{
    public partial class DropItemModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public short Count { get; set; }
        public byte Status { get; set; }
        public bool IsEvent { get; set; }
    }
}
