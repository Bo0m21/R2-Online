using Database.Balance.Enums;
using Microsoft.Extensions.Options;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive.Inventory;
using Packets.Server.Game.Models.Send;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Server.Game.Models.Settings;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Dataabse;
using System;
using System.Linq;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class InventarHandler : IInventarHandler
    {
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IInventarFactory _inventarFactory;
        private readonly DatabaseBalanceService _databaseBalanceService;
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
                                InventarSystem inventarSystem, ICharacteristicFactory characteristicFactory, IInventarFactory inventarFactory, 
                                DatabaseBalanceService databaseBalanceService, IdentificationService identificationService, IOptions<GameSetting> settings, 
                                IErrorFactory errorFactory, AbnormalSystem abnormalSystem, ItemUseSystem itemUseSystem, IInfoStomachFactory infoStomachFactory)
        {
            _databaseQueueService = databaseQueueService;
            _errorFactory = errorFactory;
            _characteristicFactory = characteristicFactory;
            _databaseBalanceService = databaseBalanceService;
            _identificationService = identificationService;
            _inventarFactory = inventarFactory;
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
            PublicItemGameModel itemGameDropped = _identificationService.GetItemByUniqueIdentifier(itemPickUpModel.UniqueIdentifierItem);

            if (itemGameDropped == null)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.ItemInvalid, false);
                return;
            }
            //Check disance to item
            if (itemGameDropped.Position.Distance(client.CharacterGame.Position) > _settings.Value.ItemPickUpDistance)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.HackerDetected, false);
                return;
            }
            //Check inventory slots
            if (client.CharacterGame.Items.Count() >= 240)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.NoBeadHoleFull, false);
                return;
            }

            ItemGameModel itemGameBalance = _databaseBalanceService.GetItemById(itemGameDropped.Item.ItemId);

            //Check inventory weight
            if (client.CharacterGame.Weight + (itemGameDropped.Item.Count * itemGameBalance.Weight) > client.CharacterGame.WeightMax)
            {
                _errorFactory.SendServerError(client, PacketType.ItemPickupReq, GameServerErrorType.NoItemTooHeavy, false);
                return;
            }

            ItemGameModel itemGame = client.CharacterGame.Items.FirstOrDefault(i => i.ItemId == itemGameDropped.Item.ItemId);

            if (itemGame != null && itemGame.IsStack && itemGame.Count + itemGameDropped.Item.Count <= 2000000000)
            {
                itemGame.Count += itemGameDropped.Item.Count;
                itemGameDropped.Item.SerialNumber = (ulong)itemGame.Id;
                //Переписать тут
            }
            else
            {
                //TODO Переписать тут
                ItemGameModel itemGameNew = _databaseBalanceService.GetItemById(itemGameDropped.Item.ItemId);

                itemGameNew.Id = (int)_serialNumberService.GetSerialNumberIdentifier();
                itemGameNew.Position = null;
                itemGameNew.Count = itemGameDropped.Item.Count;
                itemGameNew.Flag = itemGameDropped.Item.Flag;
                itemGameNew.EndTick = itemGameDropped.Item.EndTick;
                itemGameNew.ItemStatus = itemGameDropped.Item.ItemStatus;
                itemGameNew.UseCount = itemGameDropped.Item.UseCount;
                itemGameNew.EatTime = itemGameDropped.Item.EatTime;
                itemGameNew.TermOfEffectivity = itemGameDropped.Item.TermOfEffectivity;
                itemGameNew.ItemBind = itemGameDropped.Item.ItemBind;
                itemGameNew.Restore = itemGameDropped.Item.Restore;
                itemGameNew.Hole = itemGameDropped.Item.Hole;
                itemGameNew.Buffs = _databaseBalanceService.GetBuffsById(itemGameNew.ItemId).ToList();

                itemGameDropped.Item.SerialNumber = (ulong)itemGameNew.Id;

                client.CharacterGame.Items.Add(itemGameNew);
            }

            _identificationService.RemoveItem(itemGameDropped);
            _inventarFactory.SendItemAdd(client, itemGameDropped, Packets.Server.Game.Enums.Reason.Pickup);
            _inventarSystem.RecalculateWeight(client.CharacterGame);
            _characteristicFactory.SendInfoWeight(client);
        }

        [HandlerAction(PacketType.ItemDropReq)]
        public void ItemDrop(GameSession client, ItemDropReqModel itemDropModel)
        {
            ItemGameModel itemGame = client.CharacterGame.Items.FirstOrDefault(i => (ulong)i.Id == itemDropModel.SerialNumber);

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
                client.CharacterGame.Items.Remove(itemGame);
            }

            //Переписать тут TODO
            ItemGameModel itemGameNew = _databaseBalanceService.GetItemById(itemGame.ItemId);

            itemGameNew.SerialNumber = (ulong)itemGame.Id;
            itemGameNew.Count = (int)itemDropModel.Stack;
            itemGameNew.Flag = itemGame.Flag;
            itemGameNew.EndTick = itemGame.EndTick;
            itemGameNew.ItemStatus = itemGame.ItemStatus;
            itemGameNew.UseCount = itemGame.UseCount;
            itemGameNew.EatTime = itemGame.EatTime;
            itemGameNew.TermOfEffectivity = itemGame.TermOfEffectivity;
            itemGameNew.ItemBind = itemGame.ItemBind;
            itemGameNew.Restore = itemGame.Restore;
            itemGameNew.Hole = itemGame.Hole;

            PublicItemGameModel gameItemModel = new PublicItemGameModel()
            {
                Item = itemGameNew,
                Position = client.CharacterGame.Position,
                IsVsibleFirst = true,
                DateCreate = DateTime.Now
            };

            _identificationService.AddItem(gameItemModel);
            _inventarFactory.SendItemRemove(client, itemGameNew, Packets.Server.Game.Enums.Reason.Drop);
            _inventarSystem.RecalculateWeight(client.CharacterGame);
            _characteristicFactory.SendInfoWeight(client);
        }

        [HandlerAction(PacketType.ItemUseReq)]
        public void ItemUse(GameSession client, ItemUseReqModel itemUseModel)
        {
            ItemGameModel item = client.CharacterGame.Items.FirstOrDefault(i => (ulong)i.Id == itemUseModel.SerialNumber);

            if (item == null)
            {
                _errorFactory.SendServerError(client, PacketType.ItemUseReq, GameServerErrorType.ItemInvalid, false);
                return;
            }
            if (client.CharacterGame.DeadTime != null)
            {
                _errorFactory.SendServerError(client, PacketType.ItemUseReq, GameServerErrorType.HackerDetected, false);
                return;
            }

            if (item.Count - 1 > 0)
            {
                item.Count = item.Count - 1;
            }
            else
            {
                client.CharacterGame.Items.Remove(item);
            }

            _itemUseSystem.ItemUse(client.CharacterGame, item);

            if (item.Type == ItemType.Potion)
            {
                ItemGameModel itemGameNew1 = _databaseBalanceService.GetItemById(item.ItemId);
                //TODO Переписать тут 
                itemGameNew1.SerialNumber = (ulong)item.Id;
                itemGameNew1.Count = 1;

                _inventarFactory.SendItemRemove(client, itemGameNew1, Packets.Server.Game.Enums.Reason.RmUse);

                if (item.Buffs != null)
                {
                    foreach (BuffGameModel buff in item.Buffs)
                    {
                        var buffGame = client.CharacterGame.Buffs.FirstOrDefault(b => b.Type == buff.Type);

                        buff.EndTick = (uint)Environment.TickCount + buff.Time;

                        _abnormalSystem.AbnormalAdd(client.CharacterGame, buff);

                        _characteristicFactory.SendAbnormalAdd(client, client, buff);

                        foreach (var visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                        {
                            _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
                        }
                    }
                }

                _inventarSystem.RecalculateWeight(client.CharacterGame);

                _inventarFactory.SendCooldown(client, item.ItemId);
                _characteristicFactory.SendHealthPointCharacteristics(client);
                _characteristicFactory.SendInfoWeight(client);
                _inventarFactory.SendItemUseAck(client, item.ItemId);

                foreach (var visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                {
                    _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
                }

                return;
            }


            if (item.Type == ItemType.Premium)
            {
                if (item.Buffs.Count > 0)
                {
                    ItemGameModel itemGameNew = _databaseBalanceService.GetItemById(item.ItemId);
                    //TODO Переписать тут 
                    itemGameNew.SerialNumber = (ulong)item.Id;
                    itemGameNew.Count = 1;


                    foreach (BuffGameModel buff in item.Buffs)
                    {
                        var buffGame = client.CharacterGame.Buffs.FirstOrDefault(b => b.Type == buff.Type);

                        buff.EndTick = (uint)Environment.TickCount + buff.Time;

                        if (buffGame != null && buff.Level >= buffGame.Level)
                        {
                            client.CharacterGame.Buffs.Remove(buffGame);
                            _abnormalSystem.AbnormalRemove(client.CharacterGame, buffGame);

                            client.CharacterGame.Buffs.Add(buff);
                            _abnormalSystem.AbnormalAdd(client.CharacterGame, buff);

                            _characteristicFactory.SendAbnormalAdd(client, client, buff);

                            foreach (var visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                            {
                                _characteristicFactory.SendAbnormalRemove(client, visibleCharacter, buff.Type);
                                _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
                            }
                        }
                        else if (buffGame == null)
                        {
                            client.CharacterGame.Buffs.Add(buff);
                            _abnormalSystem.AbnormalAdd(client.CharacterGame, buff);

                            _characteristicFactory.SendAbnormalAdd(client, client, buff);

                            foreach (var visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                            {
                                _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
                            }
                        }
                    }

                    _inventarFactory.SendItemRemove(client, itemGameNew, Packets.Server.Game.Enums.Reason.RmUse);
                    _inventarSystem.RecalculateWeight(client.CharacterGame);
                    _characteristicFactory.SendInfoWeight(client);
                    _characteristicFactory.SendSpeedCharacteristics(client, client);
                    _characteristicFactory.SendHealthPointCharacteristics(client);
                    _characteristicFactory.SendInformationAbilityCharacteristics(client);
                    _inventarFactory.SendItemUseAck(client, item.ItemId);

                    foreach (var visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                    {
                        _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
                    }
                }

                return;
            }

            if (item.Type == ItemType.Food)
            {
                ItemGameModel itemGameNew = _databaseBalanceService.GetItemById(item.ItemId);

                itemGameNew.SerialNumber = (ulong)item.Id;
                itemGameNew.Count = 1;


                _inventarFactory.SendItemRemove(client, itemGameNew, Packets.Server.Game.Enums.Reason.RmUse);
                _inventarSystem.RecalculateWeight(client.CharacterGame);
                _characteristicFactory.SendInfoWeight(client);
                _infoStomachFactory.SendInfoStomach(client, null); // заглушка
                
                // TODO: Food system
            }
        }
    }
}
