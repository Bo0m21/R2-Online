using System.Linq;
using Database.Interfaces;
using Database.Models;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Login.Models.Receive;
using Packets.Server.Login.Models.Send;
using Server.Login.Core.Factories.Interfaces;
using Server.Login.Core.Handlers.Interfaces;
using Server.Login.Network;

namespace Server.Login.Core.Handlers
{
    /// <inheritdoc />
    [Handler]
    public class ServersHandler : IServersHandler
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationFactory _authorizationFactory;
        private readonly IServersFactory _serversFactory;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        /// <param name="databaseContext"></param>
        /// <param name="authorizationFactory"></param>
        /// <param name="serversFactory"></param>
        public ServersHandler(IDatabaseContext databaseContext, IAuthorizationFactory authorizationFactory, IServersFactory serversFactory)
        {
            _databaseContext = databaseContext;
            _authorizationFactory = authorizationFactory;
            _serversFactory = serversFactory;
        }

        /// <inheritdoc />
        [HandlerAction(PacketType.SelectServer)]
        public void SelectServerHandle(LoginSession loginSession, SelectServerModel selectServerModel)
        {
            AccountModel account = _databaseContext.Accounts.FirstOrDefault(a => a.Id == selectServerModel.AccountId);

            if (account == null || account.Login != selectServerModel.Login)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.NoUser);
                return;
            }

            ServerModel server = _databaseContext.Servers.FirstOrDefault(s => s.ServerId == selectServerModel.ServerId);

            if (server == null)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.IncorrectServer);
                return;
            }

            SessionModel session = _databaseContext.Sessions.FirstOrDefault(s => s.Id == loginSession.SessionLogin.SessionId);

            if (session == null || session.AccountId != selectServerModel.AccountId) // TODO || session.InGame)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.NoUserLoginAnother);
                return;
            }

            session.ServerId = selectServerModel.ServerId;
            _databaseContext.SaveChanges();

            _serversFactory.SendSelectedServer(loginSession);
        }

        /// <inheritdoc />
        [HandlerAction(PacketType.RefreshServers)]
        public void RefreshServersHandle(LoginSession loginSession, RefreshServersModel refreshServersModel)
        {
            _serversFactory.SendRefreshedServers(loginSession);
        }
    }
}