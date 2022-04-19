namespace Database.Parm.Models
{
    public partial class MonsterSpotModel
    {
        public int GroupId { get; set; }
        public int MonsterId { get; set; }
        public int Cnt { get; set; }
        public int Tick { get; set; }
        public double Dir { get; set; }
        public int VarRespawnTick { get; set; }
    }
}
