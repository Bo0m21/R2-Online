using Packets.Server.Game.Models.Send.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Game.Core.Factories
{
    class InfoStomachFactory : IInfoStomachFactory
    {
        public void SendInfoStomach(GameSession clientFrom, InfoStomachModel model)
        {
            InfoStomachModel infoStomachModel = new InfoStomachModel
            {
                Stomach = model.Stomach,
                StomachStatus = model.StomachStatus

            };
            clientFrom.Send(infoStomachModel);
        }
    }
}
