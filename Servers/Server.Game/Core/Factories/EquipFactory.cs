using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.GameModels;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class EquipFactory : IEquipFactory
    {
        public void SendEquip(GameSession clientFrom, GameSession clientTo, ItemGameModel itemGameModel)
        {
            EquipAckAllModel wearEquipAckModel = new EquipAckAllModel
            {
                ItemId = itemGameModel.ItemId,
                Position = (ItemPositionType)itemGameModel.Position,
                SerialNumber = (ulong)itemGameModel.Id,
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier
            };

            clientTo.Send(wearEquipAckModel);
        }

        public void SendUnEquip(GameSession clientFrom, GameSession clientTo, ItemPositionType position)
        {
            UnEquipAckAllModel unEquipAckModel = new UnEquipAckAllModel
            {
                Position = position,
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier
            };

            clientTo.Send(unEquipAckModel);
        }
    }
}
