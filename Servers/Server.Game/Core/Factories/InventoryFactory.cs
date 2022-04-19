using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Action;
using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class InventoryFactory : IInventoryFactory
    {
        public void SendItemAdd(GameSession client, GPublicItem publicItem, Reason reason)
        {
            ItemAddAckModel itemAddModel = new ItemAddAckModel()
            {
                Item = new Packets.Server.Game.Structures.ItemApiModel()
                {
                    Flag = (byte)(publicItem.Item.IsConfirm ? 1 : 0),
                    SerialNumber = publicItem.Item.SerialNumber,
                    ItemId = publicItem.Item.Id,
                    Count = publicItem.Item.Count,
                    EndTick = publicItem.Item.EndTick,
                    ItemStatus = (byte)publicItem.Item.Status,
                    UseCount = publicItem.Item.UseCount,
                    EatTime = publicItem.Item.EatTime,
                    TermOfEffectivity = publicItem.Item.TermOfValidity,
                    ItemBind = (byte)publicItem.Item.ItemBind,
                    Restore = publicItem.Item.Restore,
                    Hole = publicItem.Item.Hole
                },
                SessionGameId = publicItem.UniqueId,
                Reason = (byte)reason
            };

            client.Send(itemAddModel);
        }

        public void SendItemRemove(GameSession client, GItem gameItemModel, Reason reason)
        {
            ItemRemoveAckModel itemRemoveModel = new ItemRemoveAckModel()
            {
                Count = gameItemModel.Count,
                SerialNumber = gameItemModel.SerialNumber,
                SessionGameId = client.Pc.UniqueId,
                Reason = (byte)reason
            };

            client.Send(itemRemoveModel);
        }

        public void SendItemChangeTODOChangeAck(GameSession client, ItemChangeAckModel itemChangeAckModel)
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
