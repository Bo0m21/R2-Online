using Packets.Server.Game.Enums;
using System;
using Server.Game.Models.Game;
using Database.DataModel.Enums;

namespace Server.Game.Core.Systems
{
    public class ReinforceSystem
    {
        //public ReinforceResultType ReinforceItem(GItemReinforce itemReinforceModel, GItem material, ItemStatusEnum itemStatus)
        //{
        //    if (itemReinforceModel.Item1Id == material.Id)
        //    {
        //        double chance = 0;
        //        if (itemStatus == ItemStatusEnum.Curse) chance -= 15;
        //        if (itemStatus == ItemStatusEnum.Bless) chance += 5;
        //        if (itemReinforceModel.ItemNewId == null)
        //        {
        //            return ReinforceResultType.MaxReinforce;
        //        }
        //        //сделать проверку на оружие доспех и т.д. и т.п.
        //        Random rnd = new Random();

        //        chance += (itemReinforceModel.Percent + material.Percent) / 100;
        //        double Ch = rnd.NextDouble();

        //        if (chance > Ch)
        //        {
        //            return ReinforceResultType.Success;
        //        }

        //        return ReinforceResultType.Fail;
        //    }

        //    return ReinforceResultType.Error;
        //}
    }
}
