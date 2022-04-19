using Packets.Server.Game.Enums;
using System;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Database.Balance.Enums;

namespace Server.Game.Core.Systems
{
    public class ReinforceSystem
    {
        public ReinforceResultType ReinforceItem(ItemReinforceGameModel itemReinforceModel, ItemGameModel material, ItemStatusType itemStatus)
        {
            if (itemReinforceModel.Item1Id == material.ItemId)
            {
                double chance = 0;
                if (itemStatus == ItemStatusType.Curse) chance -= 15;
                if (itemStatus == ItemStatusType.Bless) chance += 5;
                if (itemReinforceModel.ItemNewId == null)
                {
                    return ReinforceResultType.MaxReinforce;
                }
                //сделать проверку на оружие доспех и т.д. и т.п.
                Random rnd = new Random();

                chance += (itemReinforceModel.Percent + material.Percent) / 100;
                double Ch = rnd.NextDouble();

                if (chance > Ch)
                {
                    return ReinforceResultType.Success;
                }

                return ReinforceResultType.Fail;
            }

            return ReinforceResultType.Error;
        }
    }
}
