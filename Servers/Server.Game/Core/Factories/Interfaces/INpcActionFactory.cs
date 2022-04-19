using Packets.Server.Game.Models.Send.Npc;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface INpcActionFactory
    {
        void SendDialog(GameSession clientTo, ScrDialogNoMsg2AckModel model);
        void SendMerchantList(GameSession clientTo, MerchantListAckModel model);
    }
}
