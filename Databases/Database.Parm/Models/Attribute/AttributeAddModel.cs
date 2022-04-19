namespace Database.Parm.Models
{
    public partial class AttributeAddModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public byte Level { get; set; }
        public string DiceDamage { get; set; }
        public short Damage { get; set; }
    }
}
