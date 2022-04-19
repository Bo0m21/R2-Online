using System.Linq;
using Microsoft.Extensions.Options;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive;
using Packets.Server.Game.Models.Send;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Server.Game.Models.Settings;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Dataabse;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly IAuthorizationFactory _authorizationFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IErrorFactory _commonFactory;
        private readonly DatabaseService _databaseService;
        private readonly DatabaseBalanceService _databaseBalanceService;
        private readonly IdentificationService _identificationService;
        private readonly GameSetting _gameSetting;

        public AuthorizationHandler(IAuthorizationFactory authorizationFactory, ICharacterFactory characterFactory, ICharacteristicFactory characteristicFactory, IErrorFactory commonFactory, DatabaseService databaseService, DatabaseBalanceService databaseBalanceService, IdentificationService identificationService, IOptions<GameSetting> gameSetting)
        {
            _authorizationFactory = authorizationFactory;
            _characterFactory = characterFactory;
            _characteristicFactory = characteristicFactory;
            _commonFactory = commonFactory;
            _databaseService = databaseService;
            _databaseBalanceService = databaseBalanceService;
            _identificationService = identificationService;
            _gameSetting = gameSetting.Value;
        }

        [HandlerAction(PacketType.LoginUserReq)]
        public void Authorization(GameSession client, LoginUserReqModel model)
        {
            SessionGameModel sessionGame = _databaseService.GetSessionById(model.SessionId);

            if (sessionGame == null || sessionGame.AccountId != model.AccountId) // TODO || session.InGame)
            {
                _commonFactory.SendServerError(client, PacketType.LoginUserReq, GameServerErrorType.NoUserNotLogin, true);
                return;
            }

            if (sessionGame.ServerId != _gameSetting.Id)
            {
                _commonFactory.SendServerError(client, PacketType.LoginUserReq, GameServerErrorType.NoSvrInvalidNo, true);
                return;
            }

            // Update session status
            _databaseService.UpdateSessionStatus(sessionGame.Id, true);

            // Set session and character to client
            client.SessionGame = sessionGame;
            client.Characters = _databaseService.GetCharactersById(sessionGame.AccountId);

            _authorizationFactory.SendServerTime(client);
            _authorizationFactory.SendGameConfiguration(client);
            _characterFactory.SendInformationCharacters(client);
        }

        [HandlerAction(PacketType.ChoosePcReq)]
        public void EnterWorld(GameSession client, ChoosePcReqModel model)
        {
            CharacterGameModel characterGame = client.Characters.FirstOrDefault(c => c.Id == model.CharacterId);

            if (characterGame == null)
            {
                _commonFactory.SendServerError(client, PacketType.ChoosePcReq, GameServerErrorType.NoCharInvalidNo, true);
                return;
            }

            // Set game character and register session
            client.CharacterGame = characterGame;
            _identificationService.AddConnection(client);

            // Get exp by level TODO
            ExpGameModel expGame = _databaseBalanceService.GetExpByLvl(client.CharacterGame.Level);

            _authorizationFactory.SendCompleteEnterWorld(client);
            _characteristicFactory.SendInformationAbilityCharacteristics(client);
            _characteristicFactory.SendHealthPointCharacteristics(client);
            _characteristicFactory.SendSpeedCharacteristics(client, client);
            _characteristicFactory.SendInfoWeight(client);
            _characteristicFactory.SendInfoExp(client, expGame);
        }

        [HandlerAction(PacketType.LogoutPcReq)]
        public void Logout(GameSession client, LogoutPcReqModel model)
        {
            // TODO Logout
        }
    }
}