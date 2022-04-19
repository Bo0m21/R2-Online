using System.Linq;
using Database.Account.Interfaces;
using Database.Account.Models;
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
        private readonly IAccountContext _accountContext;
        private readonly IAuthorizationFactory _authorizationFactory;
        private readonly IServersFactory _serversFactory;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        /// <param name="databaseContext"></param>
        /// <param name="authorizationFactory"></param>
        /// <param name="serversFactory"></param>
        public ServersHandler(IAccountContext accountContext, IAuthorizationFactory authorizationFactory, IServersFactory serversFactory)
        {
            _accountContext = accountContext;
            _authorizationFactory = authorizationFactory;
            _serversFactory = serversFactory;
        }

        /// <inheritdoc />
        [HandlerAction(PacketType.SelectServer)]
        public void SelectServerHandle(LoginSession loginSession, SelectServerModel selectServerModel)
        {
            selectServerModel.Login = "admin";
            AccountModel account = _accountContext.Accounts.FirstOrDefault(a => a.Id == selectServerModel.AccountId);

            if (account == null || account.Login != selectServerModel.Login)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.NoUser);
                return;
            }

            ServerModel server = _accountContext.Servers.FirstOrDefault(s => s.ServerId == selectServerModel.ServerId);

            if (server == null)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.IncorrectServer);
                return;
            }

            SessionModel session = _accountContext.Sessions.FirstOrDefault(s => s.Id == loginSession.SessionLogin.SessionId);

            if (session == null || session.AccountId != selectServerModel.AccountId) // TODO || session.InGame)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.NoUserLoginAnother);
                return;
            }

            session.ServerId = selectServerModel.ServerId;
            _accountContext.SaveChanges();

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