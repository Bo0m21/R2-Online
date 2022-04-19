using Packets.Server.Game.Models.Receive.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Packets.Core.Attributes;
using Server.Game.Services;
using Server.Game.Network;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using System.Linq;
using Server.Game.Models.Game;
using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Models.Send;
using Server.Game.Services.Database;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class ReinforceHandler : IReinforceHandler
    {
        private readonly IReinforceFactory _reinforceFactory;
        private readonly IInventoryFactory _inventoryFactory;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly ReinforceSystem _reinforceSystem;
        private readonly ParmRepository _databaseBalanceService;
        private readonly GameRepository _databaseService;
        private readonly CharacterSystem _characterSystem;
        private readonly InventarSystem _inventarSystem;
        private readonly IErrorFactory _errorFactory;

        public ReinforceHandler(ICharacteristicFactory characteristicFactory,InventarSystem inventarSystem, CharacterSystem characterSystem, IReinforceFactory reinforceFactory, ReinforceSystem reinforceSystem, ParmRepository databaseBalanceService, IInventoryFactory inventarFactory, GameRepository databaseService, IErrorFactory errorFactory)
        {
            _characterSystem = characterSystem;
            _databaseService = databaseService;
            _inventoryFactory = inventarFactory;
            _characteristicFactory = characteristicFactory;
            _databaseBalanceService = databaseBalanceService;
            _reinforceFactory = reinforceFactory;
            _reinforceSystem = reinforceSystem;
            _reinforceSystem = reinforceSystem;
            _inventarSystem = inventarSystem;
            _errorFactory = errorFactory;
        }

        [HandlerAction(PacketType.ReinforceReq)]
        public void ItemReinforce(GameSession client, ReinforceReqModel model)
        {
            //TODO сделать сохранение в базу

            //ItemGameModel itemGameModel = client.CharacterGame.Items.FirstOrDefault(i => (ulong)i.Id == model.SerialNumber);
            //ItemGameModel materialModel = client.CharacterGame.Items.FirstOrDefault(i => (ulong)i.Id == model.SerialNumber0);

            //var itemReinforceModel = _databaseBalanceService.GetItemReinforceById(itemGameModel.Id);
            //var material = _databaseBalanceService.GetItemById(materialModel.Id);

            //// TODO ItemGameModel material = _databaseBalanceService.GetItemById(materialModel.ItemId, materialModel.ItemStatus);

            //if (itemReinforceModel == null)
            //{
                _errorFactory.SendServerError(client, PacketType.ReinforceReq, GameServerErrorType.ItemInvalid, false);
                return;
            //}

            //if (material == null)
            //{
            //    _errorFactory.SendServerError(client, PacketType.ReinforceReq, GameServerErrorType.ItemInvalid, false);
            //    return;
            //}

            //var resultType = _reinforceSystem.ReinforceItem(itemReinforceModel, material, materialModel.Status);

            //if (resultType == ReinforceResultType.Error)
            //{
            //    _errorFactory.SendServerError(client, PacketType.ReinforceReq, GameServerErrorType.ItemInvalid, false);
            //    return;
            //}
            //if (resultType == ReinforceResultType.MaxReinforce)
            //{
            //    _errorFactory.SendServerError(client, PacketType.ReinforceReq, GameServerErrorType.NoReinforce, false);
            //    return;
            //}
            //else if (resultType == ReinforceResultType.Success)
            //{
            //    // TODO исправлени

            //    ReinforceAckModel reinforceAckModel = new ReinforceAckModel
            //    {
            //        SerialNumber = model.SerialNumber,
            //        ItemId = (int)itemReinforceModel.ItemNewId,
            //        IsConfirm = (byte)resultType
            //    };

            //    ItemChangeAckModel itemChangeAckModel = new ItemChangeAckModel
            //    {
            //        SerialNumber = model.SerialNumber,
            //        ItemId = (int)itemReinforceModel.ItemNewId
            //    };

            //    PublicItemGameModel publicItemGameModel = new PublicItemGameModel()
            //    {
            //        Item = new ItemGameModel()
            //        {
            //            SerialNumber = model.SerialNumber0,
            //            Count = 1
            //        }
            //    };

            //    ItemModel itemModel = new ItemModel()
            //    {
            //        CharacterId = client.CharacterGame.Id,
            //        Id = (int)model.SerialNumber,
            //        ItemId = (int)itemReinforceModel.ItemNewId,
            //        Position = null,
            //        Count = publicItemGameModel.Item.Count,
            //        Flag = itemGameModel.IsConfirm,
            //        EndTick = itemGameModel.EndTick,
            //        ItemStatus = itemGameModel.Status,
            //        UseCount = itemGameModel.UseCount,
            //        EatTime = itemGameModel.EatTime,
            //        TermOfEffectivity = itemGameModel.TermOfValidity,
            //        ItemBind = itemGameModel.ItemBind,
            //        Restore = itemGameModel.Restore,
            //        Hole = itemGameModel.Hole
            //    };
            //    client.CharacterGame.Items.FirstOrDefault(i => i.Id == itemGameModel.Id).Id = (int)itemReinforceModel.ItemNewId;


            //    _inventoryFactory.SendItemRemove(client, publicItemGameModel.Item, Reason.Reinforce);
            //    _inventarSystem.UpdateItem(client.CharacterGame, itemModel); // TODO
            //    _inventoryFactory.SendItemChangeTDODChangeAck(client, itemChangeAckModel);
            //    _reinforceFactory.SendReinforceTODOAck(client, reinforceAckModel);

            //}
            //else if (resultType == ReinforceResultType.Fail)
            //{
            //    ReinforceNak1Model reinforceNak1Model = new ReinforceNak1Model
            //    {
            //        SerialNumber = model.SerialNumber,
            //        IsDestroy = 1
            //    };

            //    PublicItemGameModel itemModel = new PublicItemGameModel()
            //    {
            //        Item = new ItemGameModel()
            //        {
            //            SerialNumber = model.SerialNumber,
            //            Count = 1
            //        }
            //    };

            //    PublicItemGameModel itemMaterialModel = new PublicItemGameModel()
            //    {
            //        Item = new ItemGameModel()
            //        {
            //            SerialNumber = model.SerialNumber0,
            //            Count = 1
            //        }
            //    };
            //    var item = client.CharacterGame.Items.FirstOrDefault(i => i.Id == itemGameModel.Id);
            //    client.CharacterGame.Items.Remove(item);

            //    _inventoryFactory.SendItemRemove(client, itemMaterialModel.Item,Reason.ReinforceFail);
            //    _inventoryFactory.SendItemRemove(client, itemModel.Item, Reason.ReinforceFail);
            //    _reinforceFactory.SendReinforceFailTODOAck(client, reinforceNak1Model);
            //}
            //_inventarSystem.RecalculateWeight(client.CharacterGame);
            //_characteristicFactory.SendInfoWeight(client);
        }
    }
}
