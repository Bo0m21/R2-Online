using Database.DataModel.Enums;
using Database.Game.Interfaces;
using Microsoft.EntityFrameworkCore;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Receive.Npc;
using Packets.Server.Game.Models.Send;
using Packets.Server.Game.Models.Send.Npc;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class NpcActionHandler : INpcActionHandler
    {
        private readonly INpcActionFactory _npcActionFactory;
        private readonly IGameContext _gameContext;
        private readonly IErrorFactory _errorFactory;
        private readonly InventarSystem _inventarSystem;
        private readonly IInventoryFactory _inventoryFactory;
        private readonly IdentificationService _identificationService;
        private readonly ParmRepository _databaseBalanceService;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly SerialNumberService _serialNumberService;

        public NpcActionHandler(ICharacteristicFactory characteristicFactory, 
            IInventoryFactory inventarFactory, 
            ParmRepository databaseBalanceService, 
            INpcActionFactory npcActionFactory, 
            IGameContext gameContext, 
            IErrorFactory errorFactory, 
            InventarSystem inventarSystem, 
            IdentificationService identificationService, 
            SerialNumberService serialNumberService)
        {
            _characteristicFactory = characteristicFactory;
            _npcActionFactory = npcActionFactory;
            _gameContext = gameContext;
            _errorFactory = errorFactory;
            _inventarSystem = inventarSystem;
            _inventoryFactory = inventarFactory;
            _identificationService = identificationService;
            _databaseBalanceService = databaseBalanceService;
            _serialNumberService = serialNumberService;
        }

        [HandlerAction(PacketType.ScriptReq)]
        public void Script(GameSession client, ScriptReqModel model)
        {
            //var Unit = _identificationService.GetUnitByUniqueIdentifier(model.UniqueIdentifier);

            //if (model.UniqueIdentifier == null)
            //{
                _errorFactory.SendServerError(client, PacketType.ScriptReq, GameServerErrorType.UnknownError, false);
                return;
            //}

            //ScrDialogNoMsg2AckModel scrDialogNoMsg2AckModel = new ScrDialogNoMsg2AckModel
            //{
            //    ScriptId = Unit.Script,
            //    UniqueIdentifier = model.UniqueIdentifier,
            //    Param = model.Param
            //};

            //_npcActionFactory.SendDialog(client, scrDialogNoMsg2AckModel);
        }

        [HandlerAction(PacketType.ScriptProcReq)]
        public void ScriptProc(GameSession client, ScriptProcReqModel model)
        {
            //var Unit = _identificationService.GetUnitByUniqueIdentifier(model.UniqueIdentifier);

            //if (model.UniqueIdentifier == null)
            //{
                _errorFactory.SendServerError(client, PacketType.ScriptProcReq, GameServerErrorType.UnknownError, false);
                return;
            //}

            //if (model.ScriptAction == ScriptAction.OPENSHOP_BUY)
            //{
            //    var items = _databaseBalanceService.GetUnitPurchasesById(Unit.Id);

            //    List<Item> itemList = new List<Item>();

            //    foreach (var i in items)
            //    {
            //        Item item = new Item()
            //        {
            //            Flag = i.Flag,
            //            ItemId = i.ItemId,
            //            Price = i.Price,
            //            SortKey = i.SortKey
            //        };
            //        itemList.Add(item);
            //    }

            //    MerchantListAckModel merchantListAckModel = new MerchantListAckModel
            //    {
            //        UniqueIdentifier = model.UniqueIdentifier,
            //        MerchantId = 1,
            //        ParmA = 0,
            //        ParmB = 1,
            //        CountBuy = 0,
            //        CountSell = itemList.Count,
            //        CountCharge = 0,
            //        PaymentType = 0,
            //        ItemList = itemList
            //    };

            //    _npcActionFactory.SendMerchantList(client, merchantListAckModel);
            //}
        }

        [HandlerAction(PacketType.MerchantBuyReq)]
        public void MerchantBuy(GameSession client, MerchantBuyReqModel model)
        {
            //GItem itemSilver = client.Pc.Items.FirstOrDefault(i => i.Id == 409);

            //if (itemSilver == null)
            //{
                _errorFactory.SendServerError(client, PacketType.MerchantBuyReq, GameServerErrorType.UnknownError, false);
                return;
            //}

            //UnitPurchaseGameModel item = _databaseBalanceService.GetUnitPurchaseById(model.ItemId);
            //int price = item.Price * model.Count;

            //if (itemSilver.Count >= price)
            //{
            //    itemSilver.Count = itemSilver.Count - price;
            //    if (itemSilver.Count <= 0)
            //    {
            //        client.CharacterGame.Items.Remove(itemSilver);
            //    }

            //    ItemGameModel Item = new ItemGameModel()
            //    {
            //        SerialNumber = (ulong)itemSilver.Id,
            //        Count = price
            //    };

            //    _inventoryFactory.SendItemRemove(client, Item, Reason.RmBuy);
            //}
            //else
            //{
            //    _errorFactory.SendServerError(client, PacketType.MerchantBuyReq, GameServerErrorType.UnknownError, false);
            //    return;
            //}

            //ItemGameModel itemGame = _databaseBalanceService.GetItemById(item.ItemId);
            //ItemGameModel characterItemGame = client.CharacterGame.Items.FirstOrDefault(i => i.Id == model.ItemId);

            //if (itemGame.MaxStack)
            //{
            //    PublicItemGameModel gameItemModel = new PublicItemGameModel()
            //    {
            //        UniqueIdentifier = new Packets.Server.Game.Structures.UniqueIdentifier(Packets.Server.Game.Enums.UniqueIdentifierType.Item) { Id = _identificationService.GetUniqueIdentifier() },
            //        Item = new ItemGameModel(itemGame)
            //        {
            //            Buffs = _databaseBalanceService.GetBuffsById(itemGame.Id),
            //            IsConfirm = 1,
            //            Count = model.Count,
            //            Status = ItemStatusTypeEnum.Normal
            //        },
            //        DateCreate = DateTime.Now
            //    };

            //    if (characterItemGame != null && characterItemGame.Count + model.Count <= 2000000000)
            //    {
            //        characterItemGame.Count += model.Count;
            //        gameItemModel.Item.SerialNumber = (ulong)characterItemGame.Id;
            //        gameItemModel.Item.Id = (int)gameItemModel.Item.SerialNumber;

            //    }
            //    else
            //    {
            //        gameItemModel.Item.SerialNumber = _serialNumberService.GetSerialNumberIdentifier();
            //        gameItemModel.Item.Id = (int)gameItemModel.Item.SerialNumber;
            //        client.CharacterGame.Items.Add(gameItemModel.Item);
            //    }

            //    _inventoryFactory.SendItemAdd(client, gameItemModel, Reason.Buy);
            //    return;
            //}

            //for (int i = 0; i < model.Count; i++)
            //{
            //    ItemGameModel itemGameNew = new ItemGameModel(itemGame);

            //    itemGameNew.SerialNumber = _serialNumberService.GetSerialNumberIdentifier();
            //    itemGameNew.Id = (int)itemGameNew.SerialNumber;
            //    itemGameNew.IsConfirm = 1;
            //    itemGameNew.Count = 1;
            //    itemGameNew.Status = ItemStatusTypeEnum.Normal;
            //    itemGameNew.Buffs = _databaseBalanceService.GetBuffsById(itemGame.Id);

            //    PublicItemGameModel gameItemModel = new PublicItemGameModel()
            //    {
            //        UniqueIdentifier = new Packets.Server.Game.Structures.UniqueIdentifier(UniqueIdentifierType.Item) { Id = _identificationService.GetUniqueIdentifier() },
            //        Item = itemGameNew,
            //        DateCreate = DateTime.Now,
            //    };

            //    client.CharacterGame.Items.Add(gameItemModel.Item);
            //    _inventoryFactory.SendItemAdd(client, gameItemModel, Reason.Buy);
            //}

            ////TODO
            ////_databaseContext.Items.Add(newItem);
            ////_databaseContext.SaveChanges();
            //_characteristicFactory.SendInfoWeight(client);
        }
    }
}
