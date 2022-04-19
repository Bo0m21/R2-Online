using Core.Network;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;
using Packets.Core.Interfaces;
using Server.Game.Core.Factories.Interfaces;
using Microsoft.Extensions.Options;
using Server.Game.Models.Settings;
using Server.Game.Services;

namespace Server.Game.Network
{
    /// <summary>
    ///     Network game server
    /// </summary>
    public class GameServer : NetworkServer
    {
        private readonly ILogger<GameServer> _logger;
        private readonly ILogger<GameSession> _loggerSession;
        private readonly IAuthorizationFactory _authorizationFactory;
        private readonly IRegisterHandlerService _registerHandlerService;
        private readonly IdentificationService _identificationService;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="loggerSession"></param>
        /// <param name="authorizationFactory"></param>
        /// <param name="registerHandlerService"></param>
        /// <param name="identificationService"></param>
        /// <param name="gameSetting"></param>
        public GameServer(ILogger<GameServer> logger, ILogger<GameSession> loggerSession, IAuthorizationFactory authorizationFactory, IRegisterHandlerService registerHandlerService, IdentificationService identificationService, IOptions<GameSetting> gameSetting) : base(IPAddress.Parse(gameSetting.Value.ServerIp), gameSetting.Value.ServerPort)
        {
            _logger = logger;
            _loggerSession = loggerSession;
            _authorizationFactory = authorizationFactory;
            _registerHandlerService = registerHandlerService;
            _identificationService = identificationService;
        }

        /// <summary>
        ///     Create new session for game server
        /// </summary>
        /// <returns></returns>
        protected override NetworkSession CreateSession()
        {
            GameSession gameSession = new GameSession(this);
            gameSession.InicializeServices(_loggerSession, _authorizationFactory, _registerHandlerService, _identificationService);

            return gameSession;
        }

        /// <summary>
        ///     Handle error exception
        /// </summary>
        /// <param name="error"></param>
        protected override void OnError(SocketError error)
        {
            _logger.LogInformation($"Have error at game server. ErrorType with code {error}");
        }
    }
}
