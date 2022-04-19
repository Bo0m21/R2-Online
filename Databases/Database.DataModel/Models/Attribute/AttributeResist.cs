namespace Database.DataModel.Models
{
    public class AttributeResist
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public byte Level { get; set; }
        public short Damage { get; set; }
        public string DiceDamage { get; set; }
    }
}
