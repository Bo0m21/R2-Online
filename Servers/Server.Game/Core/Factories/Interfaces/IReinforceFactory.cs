using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IReinforceFactory
    {
        void SendReinforceTODOAck(GameSession client, ReinforceAckModel model);

        void SendReinforceFailTODOAck(GameSession client, ReinforceNak1Model model);
    }
}
