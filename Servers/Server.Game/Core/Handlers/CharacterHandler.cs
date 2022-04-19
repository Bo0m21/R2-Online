using Database.Interfaces;
using Packets.Server.Game.Models.Receive.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using System;
using System.Linq;
using Server.Game.Network;
using Database.Models;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Send;
using Server.Game.Services;
using Database.Balance.Enums;
using Server.Game.Core.Systems;
using Server.Game.Models.GameModels;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class CharacterHandler : ICharacterHandler
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly ICharacterFactory _characterFactory;
        private readonly IErrorFactory _errorFactory;
        private readonly CharacterSystem _characterSystem;
        private readonly DatabaseBalanceService _databaseBalanceService;

        public CharacterHandler(IDatabaseContext databaseContext, ICharacterFactory characterFactory, IErrorFactory errorFactory, CharacterSystem characterSystem, DatabaseBalanceService databaseBalanceService)
        {
            _databaseContext = databaseContext;
            _characterFactory = characterFactory;
            _errorFactory = errorFactory;
            _characterSystem = characterSystem;
            _databaseBalanceService = databaseBalanceService;
        }

        [HandlerAction(PacketType.CreatePcReq)]
        public void CreateCharactersHandle(GameSession client, CreatePcReqModel model)
        {
            // Check if character more 3
            if (client.Characters.Count() >= 3)
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoCharInvalidSlot, true);
                return;
            }

            // Check if slot not empty
            if (client.Characters.Any(c => c.SlotNumber == model.Slot))
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoUserCharSlotBusy, true);
                return;
            }

            // Check if name exist
            if (_databaseContext.Characters.Any(c => c.Name == model.Name))
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoCharAlreadyExistNm, true);
                return;
            }

            // Get character information from balance
            var characterBalance = _databaseBalanceService.GetCharacterByLevelClass(1, (CharacterType)model.Class);
            var characterPositionBalance = _databaseBalanceService.GetCharacterPositionByClass((CharacterType)model.Class);

            // Create character
            CharacterModel character = new CharacterModel
            {
                AccountId = client.SessionGame.AccountId,
                Name = model.Name,
                SlotNumber = model.Slot,
                Class = (CharacterType)model.Class,
                Gender = model.Sex,
                Head = model.Head,
                Face = model.Face,
                Level = 1,
                Hp = characterBalance.HpMax,
                Mp = characterBalance.MpMax,
                Position = characterPositionBalance.Position,
                CreateDate = DateTime.Now
            };

            // Save character
            _databaseContext.Characters.Add(character);
            _databaseContext.SaveChanges();

            // Add character for client
            CharacterGameModel characterGame = _characterSystem.GetCharacterGame(character);
            client.Characters.Add(characterGame);

            _characterFactory.SendCompleteCreateCharacters(client, characterGame);
        }

        [HandlerAction(PacketType.DeletePcReq)]
        public void DeleteCharactersHandle(GameSession client, DeletePcReqModel model)
        {
            CharacterModel character = _databaseContext.Characters.FirstOrDefault(c => c.Id == model.CharacterId);

            if (character == null)
            {
                _errorFactory.SendServerError(client, PacketType.CreatePcReq, GameServerErrorType.NoCharCannotDel, true);
            }

            // Delete character
            character.DeleteDate = DateTime.Now;
            character.IsDeleted = true;

            // Save results
            _databaseContext.SaveChanges();

            // Delete character from client
            CharacterGameModel characterGame = client.Characters.FirstOrDefault(c => c.Id == character.Id);
            client.Characters.Remove(characterGame);

            _characterFactory.SendCompleteDeleteCharacters(client, characterGame);
        }
    }
}
