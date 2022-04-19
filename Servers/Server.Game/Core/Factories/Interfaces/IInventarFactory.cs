using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Enums;
using Server.Game.Models.Game;
using Server.Game.Network;
using Server.Game.Models.GameModels;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IInventarFactory
    {
        public void SendItemAdd(GameSession cleint, PublicItemGameModel publicItemGameModel, Reason reason);
        public void SendItemRemove(GameSession client, ItemGameModel temGameModel, Reason reason);
        public void SendItemChangeTDODChangeAck(GameSession client, ItemChangeAckModel itemChangeAckModel);
        public void SendItemUseAck(GameSession client, int ItemId);
        public void SendCooldown(GameSession client, int ItemId);
    }
}
