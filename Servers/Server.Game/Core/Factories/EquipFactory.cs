using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class EquipFactory : IEquipFactory
    {
        public void SendEquip(GameSession clientFrom, GameSession clientTo, GItem item)
        {
            EquipAckAllModel wearEquipAckModel = new EquipAckAllModel
            {
                ItemId = item.Id,
                Position = (ItemPositionType)item.EquipPos,
                SerialNumber = (ulong)item.Id,
                SessionGameId = clientFrom.Pc.UniqueId
            };

            clientTo.Send(wearEquipAckModel);
        }

        public void SendUnEquip(GameSession clientFrom, GameSession clientTo, ItemPositionType position)
        {
            UnEquipAckAllModel unEquipAckModel = new UnEquipAckAllModel
            {
                Position = position,
                SessionGameId = clientFrom.Pc.UniqueId
            };

            clientTo.Send(unEquipAckModel);
        }
    }
}
