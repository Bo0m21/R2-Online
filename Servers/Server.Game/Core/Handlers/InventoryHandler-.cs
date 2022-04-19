using Database.DataModel.Enums;
using Microsoft.Extensions.Options;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive.Inventory;
using Packets.Server.Game.Models.Send;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Models.Settings;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Database;
using System;
using System.Linq;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class InventarHandler : IInventarHandler
    {
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IInventoryFactory _inventoryFactory;
        private readonly ParmRepository _databaseBalanceService;
        private readonly IdentificationService _identificationService;
        private readonly IOptions<GameSetting> _settings;
        private readonly IErrorFactory _errorFactory;
        private readonly InventarSystem _inventarSystem;
        private readonly DatabaseQueueService _databaseQueueService;
        private readonly SerialNumberService _serialNumberService;
        private readonly AbnormalSystem _abnormalSystem;
        private readonly ItemUseSystem _itemUseSystem;
        private readonly IInfoStomachFactory _infoStomachFactory;

        public InventarHandler(SerialNumberService serialNumberService, DatabaseQueueService databaseQueueService, 
                                InventarSystem inventarSystem, ICharacteristicFactory characteristicFactory, IInventoryFactory inventarFactory, 
                                ParmRepository databaseBalanceService, IdentificationService identificationService, IOptions<GameSetting> settings, 
                                IErrorFactory errorFactory, AbnormalSystem abnormalSystem, ItemUseSystem itemUseSystem, IInfoStomachFactory infoStomachFactory)
        {
            _databaseQueueService = databaseQueueService;
            _errorFactory = errorFactory;
            _characteristicFactory = characteristicFactory;
            _databaseBalanceService = databaseBalanceService;
            _identificationService = identificationService;
            _inventoryFactory = inventarFactory;
            _settings = settings;
            _inventarSystem = inventarSystem;
            _serialNumberService = serialNumberService;
            _abnormalSystem = abnormalSystem;
            _itemUseSystem = itemUseSystem;
            _infoStomachFactory = infoStomachFactory;
        }

        [HandlerAction(PacketType.ItemPickupReq)]
        public void ItemPickUp(GameSession client, ItemPickupReqModel itemPickUpModel)
        {
            GPublicItem itemGameDropped = _identificationService.GetItemByUniqueIdentifier(itemPickUpModel.UniqueIdentifierItem);

            if (itemGameDropped == null)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.ItemInvalid, false);
                return;
            }
            //Check disance to item
            if (itemGameDropped.Position.Distance(client.Pc.PositionCur) > _settings.Value.ItemPickUpDistance)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.HackerDetected, false);
                return;
            }
            //Check inventory slots
            if (client.Pc.Inventory.Items.Count() >= 240)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.NoBeadHoleFull, false);
                return;
            }

            GItem itemGameBalance = _databaseBalanceService.GetGItemById(itemGameDropped.Item.Id);

            //Check inventory weight
            if (client.Pc.Inventory.Weight + (itemGameDropped.Item.Count * itemGameBalance.Weight) > client.Pc.Inventory.MaxWeight)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.NoItemTooHeavy, false);
                return;
            }

            GItem itemGame = client.Pc.Inventory.Items.FirstOrDefault(i => i.Id == itemGameDropped.Item.Id);
            if (itemGame != null && itemGame.MaxStack > 0 && itemGame.Count + itemGameDropped.Item.Count <= 2000000000)
            {
                itemGame.Count += itemGameDropped.Item.Count;
                itemGameDropped.Item.SerialNumber = (ulong)itemGame.Id;
                //Переписать тут
            }
            else
            {
                //TODO Переписать тут
                GItem itemGameNew = _databaseBalanceService.GetGItemById(itemGameDropped.Item.Id);

                itemGameNew.Id = (int)_serialNumberService.GetSerialNumberIdentifier();
                itemGameNew.EquipPos = null;
                itemGameNew.Count = itemGameDropped.Item.Count;
                itemGameNew.IsConfirm = itemGameDropped.Item.IsConfirm;
                itemGameNew.EndTick = itemGameDropped.Item.EndTick;
                itemGameNew.Status = itemGameDropped.Item.Status;
                itemGameNew.UseCount = itemGameDropped.Item.UseCount;
                itemGameNew.EatTime = itemGameDropped.Item.EatTime;
                itemGameNew.TermOfValidity = itemGameDropped.Item.TermOfValidity;
                itemGameNew.ItemBind = itemGameDropped.Item.ItemBind;
                itemGameNew.Restore = itemGameDropped.Item.Restore;
                itemGameNew.Hole = itemGameDropped.Item.Hole;
                //itemGameNew.Buffs = _databaseBalanceService.GetBuffsById(itemGameNew.Id).ToList();

                itemGameDropped.Item.SerialNumber = (ulong)itemGameNew.Id;

                client.Pc.Inventory.Items.Add(itemGameNew);
            }

            _identificationService.RemoveItem(itemGameDropped);
            _inventoryFactory.SendItemAdd(client, itemGameDropped, Packets.Server.Game.Enums.Reason.Pickup);
            _inventarSystem.RecalculateWeight(client.Pc);
            _characteristicFactory.SendInfoWeight(client);
        }

        [HandlerAction(PacketType.ItemDropReq)]
        public void ItemDrop(GameSession client, ItemDropReqModel itemDropModel)
        {
            GItem itemGame = client.Pc.Inventory.Items.FirstOrDefault(i => (ulong)i.Id == itemDropModel.SerialNumber);

            if (itemGame == null)
            {
                return;
            }
            //TODO
            if (itemGame.Count - itemDropModel.Stack > 0)
            {
                itemGame.Count = itemGame.Count - (int)itemDropModel.Stack;
            }
            else
            {
                client.Pc.Inventory.Items.Remove(itemGame);
            }

            //Переписать тут TODO
            GItem itemGameNew = _databaseBalanceService.GetGItemById(itemGame.Id);

            itemGameNew.SerialNumber = (ulong)itemGame.Id;
            itemGameNew.Count = (int)itemDropModel.Stack;
            itemGameNew.IsConfirm = itemGame.IsConfirm;
            itemGameNew.EndTick = itemGame.EndTick;
            itemGameNew.Status = itemGame.Status;
            itemGameNew.UseCount = itemGame.UseCount;
            itemGameNew.EatTime = itemGame.EatTime;
            itemGameNew.TermOfValidity = itemGame.TermOfValidity;
            itemGameNew.ItemBind = itemGame.ItemBind;
            itemGameNew.Restore = itemGame.Restore;
            itemGameNew.Hole = itemGame.Hole;

            GPublicItem gameItemModel = new GPublicItem()
            {
                Item = itemGameNew,
                Position = client.Pc.PositionCur,
                IsVsibleFirst = true,
                DateCreate = DateTime.Now
            };

            _identificationService.AddItem(gameItemModel);
            _inventoryFactory.SendItemRemove(client, itemGameNew, Packets.Server.Game.Enums.Reason.Drop);
            _inventarSystem.RecalculateWeight(client.Pc);
            _characteristicFactory.SendInfoWeight(client);
        }

        [HandlerAction(PacketType.ItemUseReq)]
        public void ItemUse(GameSession client, ItemUseReqModel itemUseModel)
        {
            //GItem item = client.Pc.Inventory.Items.FirstOrDefault(i => (ulong)i.Id == itemUseModel.SerialNumber);

            //if (item == null)
            //{
                _errorFactory.SendServerError(client, PacketType.ItemUseReq, GameServerErrorType.ItemInvalid, false);
                return;
            //}
            //if (client.Pc.DeadTime != null)
            //{
            //    _errorFactory.SendServerError(client, PacketType.ItemUseReq, GameServerErrorType.HackerDetected, false);
            //    return;
            //}

            //if (item.Count - 1 > 0)
            //{
            //    item.Count = item.Count - 1;
            //}
            //else
            //{
            //    client.Pc.Inventory.Items.Remove(item);
            //}

            //_itemUseSystem.ItemUse(client.Pc, item);

            //if (item.Type == ItemTypeEnum.Potion)
            //{
            //    GItem itemGameNew1 = _databaseBalanceService.GetItemById(item.Id);
            //    //TODO Переписать тут 
            //    itemGameNew1.SerialNumber = (ulong)item.Id;
            //    itemGameNew1.Count = 1;

            //    _inventoryFactory.SendItemRemove(client, itemGameNew1, Packets.Server.Game.Enums.Reason.RmUse);

            //    if (item.Buffs != null)
            //    {
            //        foreach (GBuff buff in item.Buffs)
            //        {
            //            var buffGame = client.Pc.Buffs.FirstOrDefault(b => b.Type == buff.Type);

            //            buff.EndTick = (uint)Environment.TickCount + buff.Time;

            //            _abnormalSystem.AbnormalAdd(client.Pc, buff);

            //            _characteristicFactory.SendAbnormalAdd(client, client, buff);

            //            foreach (var visibleCharacter in client.Pc.VisibleCharacterGames)
            //            {
            //                _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
            //            }
            //        }
            //    }

            //    _inventarSystem.RecalculateWeight(client.Pc);

            //    _inventoryFactory.SendCooldown(client, item.Id);
            //    _characteristicFactory.SendHealthPointCharacteristics(client);
            //    _characteristicFactory.SendInfoWeight(client);
            //    _inventoryFactory.SendItemUseAck(client, item.Id);

            //    foreach (var visibleCharacter in client.Pc.VisibleCharacterGames)
            //    {
            //        _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
            //    }

            //    return;
            //}


            //if (item.Type == ItemTypeEnum.Premium)
            //{
            //    if (item.Buffs.Count > 0)
            //    {
            //        GItem itemGameNew = _databaseBalanceService.GetItemById(item.Id);
            //        //TODO Переписать тут 
            //        itemGameNew.SerialNumber = (ulong)item.Id;
            //        itemGameNew.Count = 1;


            //        foreach (GBuff buff in item.Buffs)
            //        {
            //            var buffGame = client.Pc.Buffs.FirstOrDefault(b => b.Type == buff.Type);

            //            buff.EndTick = (uint)Environment.TickCount + buff.Time;

            //            if (buffGame != null && buff.Level >= buffGame.Level)
            //            {
            //                client.Pc.Buffs.Remove(buffGame);
            //                _abnormalSystem.AbnormalRemove(client.Pc, buffGame);

            //                client.Pc.Buffs.Add(buff);
            //                _abnormalSystem.AbnormalAdd(client.Pc, buff);

            //                _characteristicFactory.SendAbnormalAdd(client, client, buff);

            //                foreach (var visibleCharacter in client.Pc.VisibleCharacterGames)
            //                {
            //                    _characteristicFactory.SendAbnormalRemove(client, visibleCharacter, buff.Type);
            //                    _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
            //                }
            //            }
            //            else if (buffGame == null)
            //            {
            //                client.Pc.Buffs.Add(buff);
            //                _abnormalSystem.AbnormalAdd(client.Pc, buff);

            //                _characteristicFactory.SendAbnormalAdd(client, client, buff);

            //                foreach (var visibleCharacter in client.Pc.VisibleCharacterGames)
            //                {
            //                    _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
            //                }
            //            }
            //        }

            //        _inventoryFactory.SendItemRemove(client, itemGameNew, Packets.Server.Game.Enums.Reason.RmUse);
            //        _inventarSystem.RecalculateWeight(client.Pc);
            //        _characteristicFactory.SendInfoWeight(client);
            //        _characteristicFactory.SendSpeedCharacteristics(client, client);
            //        _characteristicFactory.SendHealthPointCharacteristics(client);
            //        _characteristicFactory.SendInformationAbilityCharacteristics(client);
            //        _inventoryFactory.SendItemUseAck(client, item.Id);

            //        foreach (var visibleCharacter in client.Pc.VisibleCharacterGames)
            //        {
            //            _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
            //        }
            //    }

            //    return;
            //}

            //if (item.Type == ItemTypeEnum.Food)
            //{
            //    GItem itemGameNew = _databaseBalanceService.GetItemById(item.Id);

            //    itemGameNew.SerialNumber = (ulong)item.Id;
            //    itemGameNew.Count = 1;


            //    _inventoryFactory.SendItemRemove(client, itemGameNew, Packets.Server.Game.Enums.Reason.RmUse);
            //    _inventarSystem.RecalculateWeight(client.Pc);
            //    _characteristicFactory.SendInfoWeight(client);
            //    _infoStomachFactory.SendInfoStomach(client, null); // заглушка
                
            //    // TODO: Food system
            //}
        }
    }
}
