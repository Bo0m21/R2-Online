using Packets.Server.Game.Models.Receive.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using System;
using System.Linq;
using Server.Game.Network;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Send;
using Server.Game.Services;
using Database.DataModel.Enums;
using Server.Game.Core.Systems;
using Database.Game.Interfaces;
using Database.Game.Models;
using Server.Game.Models.Game;
using Server.Game.Services.Database;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class CharacterHandler : ICharacterHandler
    {
        private readonly IGameContext _gameContext;
        private readonly ICharacterFactory _characterFactory;
        private readonly IErrorFactory _errorFactory;
        private readonly CharacterSystem _characterSystem;
        private readonly ParmRepository _databaseBalanceService;

        public CharacterHandler(IGameContext databaseContext, ICharacterFactory characterFactory, IErrorFactory errorFactory, CharacterSystem characterSystem, ParmRepository databaseBalanceService)
        {
            _gameContext = databaseContext;
            _characterFactory = characterFactory;
            _errorFactory = errorFactory;
            _characterSystem = characterSystem;
            _databaseBalanceService = databaseBalanceService;
        }

        [HandlerAction(PacketType.CreatePcReq)]
        public void CreateCharactersHandle(GameSession client, CreatePcReqModel model)
        {
            // Check if character more 3
            if (client.Pcs.Count() >= 3)
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoCharInvalidSlot, true);
                return;
            }

            // Check if slot not empty
            if (client.Pcs.Any(c => c.Simple.Slot == model.Slot)) // TODO проверка на удаленного персонажа
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoUserCharSlotBusy, true);
                return;
            }

            // Check if name exist
            if (_gameContext.Pcs.Any(c => c.NickName == model.Name))
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoCharAlreadyExistNm, true);
                return;
            }

            // TODO Вынести в настройку начальный уровень персонажа
            // Get character information from balance
            //var characterBalance = _databaseBalanceService.GetCharacterByLevelClass(1, (CharacterTypeEnum)model.Class);
            //var characterPositionBalance = _databaseBalanceService.GetCharacterPositionByClass((CharacterTypeEnum)model.Class);

            // Create character
            Pc pc = new Pc
            {
                RegDate = DateTime.Now,
                Owner = client.Sessions.AccountId,
                Slot = model.Slot,
                NickName = model.Name,
                Class = model.Class,
                Sex = model.Sex,
                Head = model.Head,
                Face = model.Face,
                HomePosX = 364000.2f,
                HomePosY = 313483.7f,
                HomePosZ = 12339.71f,
                State = new PcState
                {
                    Level = 1,
                    Hp = 93,
                    Mp = 51,
                    PosX = 364000.2f,
                    PosY = 313483.7f,
                    PosZ = 12339.71f,
                    Stomach = 100,
                }
            };

            // Save character
            _gameContext.Pcs.Add(pc);
            _gameContext.SaveChanges();

            // Add character for client
            GPc gamePc = _characterSystem.GetCharacterGame(pc);
            client.Pcs.Add(gamePc);

            _characterFactory.SendCompleteCreateCharacters(client, gamePc);
        }

        [HandlerAction(PacketType.DeletePcReq)]
        public void DeleteCharactersHandle(GameSession client, DeletePcReqModel model)
        {
            var pc = _gameContext.Pcs.FirstOrDefault(c => c.No == model.PcNo);

            if (pc == null)
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoCharCannotDel, true);
            }

            // Delete character
            pc.DelDate = DateTime.Now;
            //character.IsDeleted = true;

            // Save results
            _gameContext.SaveChanges();

            // Delete character from client
            GPc pcGame = client.Pcs.FirstOrDefault(c => c.Simple.PcNo == pc.No);
            client.Pcs.Remove(pcGame);

            _characterFactory.SendCompleteDeleteCharacters(client, pcGame);
        }
    }
}
