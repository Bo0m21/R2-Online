using System.Collections.Generic;

namespace Database.DataModel.Models
{
    public class MonsterSpot
    {
        public MonsterSpot()
        {
            SpotGroup = new List<MonsterSpotGroup>();
        }
        public int GroupId { get; set; }
        public int MonsterId { get; set; }
        public int Cnt { get; set; }
        public int Tick { get; set; }
        public double Dir { get; set; }
        public int VarRespawnTick { get; set; }
        public List<MonsterSpotGroup> SpotGroup { get; set; }
    }
}
