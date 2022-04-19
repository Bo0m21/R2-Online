using Database.Balance.Enums;
using Database.Balance.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive.Chat;
using Packets.Server.Game.Models.Send.Action;
using Packets.Server.Game.Models.Send.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.GameServices;
using System;
using System.Linq;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class ChatHandler : IChatHandler
    {
        private readonly IChatFactory _chatFactory;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IInventarFactory _inventarFactory;
        private readonly DatabaseBalanceService _databaseBalanceService;
        private readonly IdentificationService _identificationService;
        private readonly CharacterSystem _characterSystem;
        private readonly SerialNumberService _serialNumberService;
        private readonly UnitSystem _unitSystem;

        public ChatHandler(IInventarFactory inventarFactory, IChatFactory chatFactory, ICharacteristicFactory characteristicFactory, DatabaseBalanceService databaseBalanceService, IdentificationService identificationService, CharacterSystem characterSystem, SerialNumberService serialNumberService, UnitSystem unitSystem)
        {
            _inventarFactory = inventarFactory;
            _chatFactory = chatFactory;
            _characteristicFactory = characteristicFactory;
            _databaseBalanceService = databaseBalanceService;
            _identificationService = identificationService;
            _characterSystem = characterSystem;
            _serialNumberService = serialNumberService;
            _unitSystem = unitSystem;
        }

        [HandlerAction(PacketType.ChatReq)]
        public void ReceiveMessageHandle(GameSession client, ChatReqModel model)
        {
            // TODO Сделать нормально и несколько чатов

            // Default chat
            if (model.Type == 0)
            {
                foreach (GameSession visible in client.CharacterGame.VisibleCharacterGames)
                {
                    _chatFactory.SendMessage(client, visible, model);
                }

                _chatFactory.SendMessage(client, client, model);
            }

            // Private chat
            if (model.Type == 2)
            {
                var connection = _identificationService.GetConnectionByCharacterName(model.Name);

                if (connection != null)
                {
                    _chatFactory.SendMessage(client, connection, model);
                }
                else
                {
                    Console.WriteLine("Character not found!"); // TODO error character not found!
                }
            }

            // Shop chat
            if (model.Type == 6)
            {
                foreach (var connection in _identificationService.GetAllConnections())
                {
                    _chatFactory.SendMessage(client, connection, model);
                }
            }

            #region Admin functions
            // TODO Admin functions
            if (model.Message.Split(" ")[0] == "lvlup")
            {
                short lvl = 1;
                if (model.Message.Split(" ").Length > 1 && model.Message.Split(" ")[1] != "")
                {
                    short.TryParse(model.Message.Split(" ")[1], out lvl);
                }
                if(lvl < 0 || lvl > 200)
                {
                    model.Message = "[Wrong level]";
                    model.Type = 4;
                    _chatFactory.SendMessage(client, client, model);
                    return;
                }

                ExpGameModel expGameModel = _databaseBalanceService.GetExpByLvl(lvl);
                client.CharacterGame.Level = lvl;
                client.CharacterGame.Exp = 0;
                _characterSystem.RecalculateCharacter(client.CharacterGame);
                client.CharacterGame.Hp = client.CharacterGame.HpMax;
                client.CharacterGame.Mp = client.CharacterGame.MpMax;

                _characteristicFactory.SendInformationAbilityCharacteristics(client);
                _characteristicFactory.SendHealthPointCharacteristics(client);
                _characteristicFactory.SendSpeedCharacteristics(client, client);
                _characteristicFactory.SendInfoWeight(client);
                _characteristicFactory.SendInfoExp(client, expGameModel);
                _characteristicFactory.SendLevelUp(client, client);
            }

            if (model.Message.Split(" ")[0] == "item")
            {
                int count = 1;
                int itemId;
                if (model.Message.Split(" ").Length > 1 && model.Message.Split(" ")[1] != "")
                {
                    itemId = int.Parse(model.Message.Split(" ")[1]);
                }
                else
                {
                    model.Message = "[Wrong item]";
                    model.Type = 4;
                    _chatFactory.SendMessage(client, client, model);
                    return;
                }
                if (model.Message.Split(" ").Length > 2 && model.Message.Split(" ")[2] != "")
                {
                    int.TryParse(model.Message.Split(" ")[2], out count);
                }

                ItemGameModel itemGame = _databaseBalanceService.GetItemById(itemId);
                ItemGameModel characterItemGame = client.CharacterGame.Items.FirstOrDefault(i => i.ItemId == itemId);

                if (itemGame.IsStack)
                {
                    PublicItemGameModel gameItemModel = new PublicItemGameModel()
                    {
                        UniqueIdentifier = new Packets.Server.Game.Structures.UniqueIdentifier(Packets.Server.Game.Enums.UniqueIdentifierType.Item) {Id = _identificationService.GetUniqueIdentifier() },
                        Item = new ItemGameModel(itemGame) 
                        {
                            Buffs = _databaseBalanceService.GetBuffsById(itemGame.ItemId),
                            Flag = 1,
                            Count = count,
                            ItemStatus = ItemStatusType.Normal
                        },
                        DateCreate = DateTime.Now
                    };

                    if (characterItemGame != null && characterItemGame.Count + count <= 2000000000)
                    {
                        characterItemGame.Count += count;
                        gameItemModel.Item.SerialNumber = (ulong)characterItemGame.Id;
                        gameItemModel.Item.Id = (int)gameItemModel.Item.SerialNumber;

                    }
                    else
                    {
                        gameItemModel.Item.SerialNumber = _serialNumberService.GetSerialNumberIdentifier();
                        gameItemModel.Item.Id = (int)gameItemModel.Item.SerialNumber;
                        client.CharacterGame.Items.Add(gameItemModel.Item);
                    }

                    _inventarFactory.SendItemAdd(client, gameItemModel, Packets.Server.Game.Enums.Reason.CreatedByAdmin);
                    return;
                }

                for (int i = 0; i < count; i++)
                {
                    ItemGameModel itemGameNew = new ItemGameModel(itemGame);

                    itemGameNew.SerialNumber = _serialNumberService.GetSerialNumberIdentifier();
                    itemGameNew.Id = (int)itemGameNew.SerialNumber;
                    itemGameNew.Flag = 1;
                    itemGameNew.Count = 1;
                    itemGameNew.ItemStatus = ItemStatusType.Normal;
                    itemGameNew.Buffs = _databaseBalanceService.GetBuffsById(itemGame.ItemId);

                    PublicItemGameModel gameItemModel = new PublicItemGameModel()
                    {
                        UniqueIdentifier = new Packets.Server.Game.Structures.UniqueIdentifier(Packets.Server.Game.Enums.UniqueIdentifierType.Item) {Id = _identificationService.GetUniqueIdentifier() },
                        Item = itemGameNew,
                        DateCreate = DateTime.Now,
                    };

                    client.CharacterGame.Items.Add(gameItemModel.Item);
                    _inventarFactory.SendItemAdd(client, gameItemModel, Packets.Server.Game.Enums.Reason.CreatedByAdmin);
                }

            }

            if (model.Message.Split(" ")[0] == "mob")
            {
                int unitId = int.Parse(model.Message.Split(" ")[1]);
                int respawn = int.Parse(model.Message.Split(" ")[2]);

                var check = _databaseBalanceService.GetUnitModelById(unitId);

                if (check == null)
                {
                    model.Message = "Mob not found";
                    _chatFactory.SendMessage(client, client, model);
                    return;
                }

                UnitPositionModel unitPositionModel = new UnitPositionModel()
                {
                    UnitId = unitId,
                    Unit = check,
                    X = client.CharacterGame.Position.X,
                    Y = client.CharacterGame.Position.Y,
                    Z = client.CharacterGame.Position.Z,
                    DirectionSight = client.CharacterGame.DirectionSight,
                    Respawn = respawn * 1000
                };

                _databaseBalanceService.AddUnitPosition(unitPositionModel);
                _identificationService.AddUnit(_unitSystem.AddUnit(unitId, unitPositionModel));

                _chatFactory.SendMessage(client, client, model);
            }

            if (model.Message == "position")
            {
                model.Message = client.CharacterGame.Position.ToString();
                _chatFactory.SendMessage(client, client, model);
            }

            if (model.Message == "tp")
            {
                client.CharacterGame.Position.X = 312802;
                client.CharacterGame.Position.Y = 1035041;
                client.CharacterGame.Position.Z = 16359;

                // TODO add teleport

                client.CharacterGame.IsVsibleFirst = true;
            }

            if (model.Message.Split(" ")[0] == "morf")
            {
                int morfId = 83;
                if (model.Message.Split(" ").Length > 1 && model.Message.Split(" ")[1] != "")
                {
                    morfId = int.Parse(model.Message.Split(" ")[1]);
                }

                TransformAckModel abnormalModel = new TransformAckModel()
                {
                    UniqueIdentifier = client.CharacterGame.UniqueIdentifier,
                    MonsterId = morfId
                };

                client.Send(abnormalModel);

                foreach (var visible in client.CharacterGame.VisibleCharacterGames)
                {
                    visible.Send(abnormalModel);
                }
            }

            #endregion
        }

        [HandlerAction(PacketType.GlobalChatReq)]
        public void ReceiveMessageGChatHandle(GameSession client, GlobalChatReqModel model)
        {
            foreach (var connection in _identificationService.GetAllConnections())
            {
                _chatFactory.SendMessageToGlobalChat(client, connection, model);
            }
        }

        [HandlerAction(PacketType.EmoticonReq)]
        public void ReceiveEmoticon(GameSession client, EmoticonReqModel model)
        {
            _chatFactory.SendEmoticon(client, client, model);

            foreach (GameSession visible in client.CharacterGame.VisibleCharacterGames)
            {
                _chatFactory.SendEmoticon(client, visible, model);
            }
        }
    }
}
