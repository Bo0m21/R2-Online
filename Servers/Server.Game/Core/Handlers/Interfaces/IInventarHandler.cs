using Packets.Server.Game.Models.Receive.Inventory;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IInventarHandler
    {
        void ItemPickUp(GameSession client, ItemPickupReqModel itemPickUpModel);

        void ItemDrop(GameSession client, ItemDropReqModel itemDropModel);

        void ItemUse(GameSession client, ItemUseReqModel itemUseModel);
    }
}
