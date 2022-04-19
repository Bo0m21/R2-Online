using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class ReinforceFactory : IReinforceFactory
    {
        public void SendReinforceTODOAck(GameSession client, ReinforceAckModel model)
        {
            ReinforceAckModel reinforceAckModel = new ReinforceAckModel
            {
                SerialNumber = model.SerialNumber,
                ItemId = model.ItemId,
                IsConfirm = model.IsConfirm
            };

            client.Send(reinforceAckModel);
        }

        public void SendReinforceFailTODOAck(GameSession client, ReinforceNak1Model model)
        {
            ReinforceNak1Model reinforceNak1Model = new ReinforceNak1Model
            {
                SerialNumber = model.SerialNumber,
                IsDestroy = model.IsDestroy
            };

            client.Send(reinforceNak1Model);
        }
    }
}
