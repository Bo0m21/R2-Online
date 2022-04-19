using Packets.Server.Game.Models.Receive.Inventory;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IReinforceHandler
    {
        void ItemReinforce(GameSession client, ReinforceReqModel model);
    }
}
