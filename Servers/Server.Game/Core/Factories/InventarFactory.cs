using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Action;
using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class InventarFactory : IInventarFactory
    {
        public void SendItemAdd(GameSession client, PublicItemGameModel publicItemGameModel, Reason reason)
        {
            ItemAddAckModel itemAddModel = new ItemAddAckModel()
            {
                Item = new Packets.Server.Game.Structures.Item()
                {
                    Flag = publicItemGameModel.Item.Flag,
                    SerialNumber = publicItemGameModel.Item.SerialNumber,
                    ItemId = publicItemGameModel.Item.ItemId,
                    Count = publicItemGameModel.Item.Count,
                    EndTick = publicItemGameModel.Item.EndTick,
                    ItemStatus = (byte)publicItemGameModel.Item.ItemStatus,
                    UseCount = publicItemGameModel.Item.UseCount,
                    EatTime = publicItemGameModel.Item.EatTime,
                    TermOfEffectivity = publicItemGameModel.Item.TermOfEffectivity,
                    ItemBind = (byte)publicItemGameModel.Item.ItemBind,
                    Restore = publicItemGameModel.Item.Restore,
                    Hole = publicItemGameModel.Item.Hole
                },
                SessionGameId = publicItemGameModel.UniqueIdentifier,
                Reason = (byte)reason
            };

            client.Send(itemAddModel);
        }

        public void SendItemRemove(GameSession client, ItemGameModel gameItemModel, Reason reason)
        {
            ItemRemoveAckModel itemRemoveModel = new ItemRemoveAckModel()
            {
                Count = gameItemModel.Count,
                SerialNumber = gameItemModel.SerialNumber,
                SessionGameId = client.CharacterGame.UniqueIdentifier,
                Reason = (byte)reason
            };

            client.Send(itemRemoveModel);
        }

        public void SendItemChangeTDODChangeAck(GameSession client, ItemChangeAckModel itemChangeAckModel)
        {
            ItemChangeAckModel itemChangeModel = new ItemChangeAckModel
            {
                SerialNumber = itemChangeAckModel.SerialNumber,
                ItemId = itemChangeAckModel.ItemId,
                IsCreate = itemChangeAckModel.IsCreate,
                Reason = itemChangeAckModel.Reason
            };

            client.Send(itemChangeModel);
        }
        
        public void SendItemUseAck(GameSession client, int ItemId)
        {
            ItemUseAckModel itemUseModel = new ItemUseAckModel
            {
                ItemId = ItemId
            };

            client.Send(itemUseModel);
        }

        public void SendCooldown(GameSession client, int ItemId)
        {
            ItemCooldownAckModel itemCooldownAckModel = new ItemCooldownAckModel()
            {
                ItemId = ItemId
            };
            client.Send(itemCooldownAckModel);
        }
    }
}
