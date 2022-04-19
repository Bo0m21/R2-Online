using System.Linq;
using Microsoft.Extensions.Options;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive;
using Packets.Server.Game.Models.Send;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Models.Settings;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Database;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly IAuthorizationFactory _authorizationFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IErrorFactory _commonFactory;
        private readonly GameRepository _gameRepository;
        private readonly ParmRepository _parmRepository;
        private readonly IdentificationService _identificationService;
        private readonly GameSetting _gameSetting;

        public AuthorizationHandler(IAuthorizationFactory authorizationFactory, ICharacterFactory characterFactory, ICharacteristicFactory characteristicFactory, IErrorFactory commonFactory, GameRepository gameRepository, ParmRepository parmRepository, IdentificationService identificationService, IOptions<GameSetting> gameSetting)
        {
            _authorizationFactory = authorizationFactory;
            _characterFactory = characterFactory;
            _characteristicFactory = characteristicFactory;
            _commonFactory = commonFactory;
            _gameRepository = gameRepository;
            _parmRepository = parmRepository;
            _identificationService = identificationService;
            _gameSetting = gameSetting.Value;
        }

        [HandlerAction(PacketType.LoginUserReq)]
        public void Authorization(GameSession client, LoginUserReqModel model)
        {
            GSession sessionGame = _gameRepository.GetSessionById(model.SessionId);

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
            _gameRepository.UpdateSessionStatus(sessionGame.Id, true);

            // Set session and character to client
            client.Sessions = sessionGame;
            client.Pcs = _gameRepository.GetPcsByAccountId(sessionGame.AccountId);

            _authorizationFactory.SendServerTime(client);
            _authorizationFactory.SendGameConfiguration(client);
            _characterFactory.SendInformationCharacters(client);
        }

        [HandlerAction(PacketType.ChoosePcReq)]
        public void EnterWorld(GameSession client, ChoosePcReqModel model)
        {
            GPc characterGame = client.Pcs.FirstOrDefault(c => c.Simple.PcNo == model.PcNo);

            if (characterGame == null)
            {
                _commonFactory.SendServerError(client, PacketType.ChoosePcReq, GameServerErrorType.NoCharInvalidNo, true);
                return;
            }

            // Set game character and register session
            client.Pc = characterGame;
            _identificationService.AddConnection(client);

            // Get exp by level TODO
            GExp expGame = _parmRepository.GetExpByLvl(client.Pc.Simple.Level);

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