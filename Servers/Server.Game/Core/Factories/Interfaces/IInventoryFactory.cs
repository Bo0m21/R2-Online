using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Enums;
using Server.Game.Models.Game;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IInventoryFactory
    {
        public void SendItemAdd(GameSession cleint, GPublicItem publicItemGameModel, Reason reason);
        public void SendItemRemove(GameSession client, GItem temGameModel, Reason reason);
        public void SendItemChangeTODOChangeAck(GameSession client, ItemChangeAckModel itemChangeAckModel);
        public void SendItemUseAck(GameSession client, int ItemId);
        public void SendCooldown(GameSession client, int ItemId);
    }
}
