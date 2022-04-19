using Database.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game.Models.Game
{
    public class GPcInventory
    {
        public GPcInventory()
        {
            Items = new List<GItem>();
        }
        public List<GItem> Items { get; set; }
        public uint Money { get; set; }
        public ulong MoneySerialNo { get; set; }
        public uint ChaosSilver { get; set; }
        public ulong ChaosSilverSerialNo { get; set; }
        public int Weight { get; set; }
        public int MaxWeight { get; set; }
        public WeightStatusEnum WeightStatus { get; set; }

        public void SetMaxWeight(int maxWeight)
        {
            if (MaxWeight != maxWeight)
            {
                MaxWeight = maxWeight;
                if (Weight >= MaxWeight * 0.7)
                    WeightStatus = Weight >= MaxWeight ? WeightStatusEnum.Over : WeightStatusEnum.Heavy;
                else
                    WeightStatus = WeightStatusEnum.Normal;
            }
        }
    }
}
