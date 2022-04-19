namespace Database.Game.Models
{
    public partial class PcTeleport
    {
        public int No { get; set; }
        public int PcNo { get; set; }
        public string Name { get; set; }
        public int MapNo { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public string OrgName { get; set; }

        public virtual Pc PcNoNavigation { get; set; }
    }
}
