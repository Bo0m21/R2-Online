using System.Linq;
using Database.Interfaces;
using Database.Models;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Login.Models.Receive;
using Packets.Server.Login.Models.Send;
using Server.Login.Core.Factories.Interfaces;
using Server.Login.Core.Handlers.Interfaces;
using Server.Login.Models.Login;
using Server.Login.Network;

namespace Server.Login.Core.Handlers
{
    /// <inheritdoc />
    [Handler]
    public class AuthorizationHandler : IAuthorizationHandler
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
        public AuthorizationHandler(IDatabaseContext databaseContext, IAuthorizationFactory authorizationFactory, IServersFactory serversFactory)
        {
            _databaseContext = databaseContext;
            _authorizationFactory = authorizationFactory;
            _serversFactory = serversFactory;
        }

        /// <inheritdoc />
        [HandlerAction(PacketType.AuthorizationLogin)]
        public void AuthorizationLoginHandle(LoginSession loginSession, AuthorizationLoginModel authorizationLoginModel)
        {
            AccountModel account = _databaseContext.Accounts.FirstOrDefault(a => a.Login == authorizationLoginModel.Login);

            if (account == null)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.NoUser);
                return;
            }

            if (account.Password != authorizationLoginModel.Password)
            {
                _authorizationFactory.SendError(loginSession, ServerErrorType.PasswordWrong);
                return;
            }

            SessionModel session = _databaseContext.Sessions.FirstOrDefault(c => c.AccountId == account.Id);

            if (session == null)
            {
                session = _databaseContext.Sessions.Add(new SessionModel { AccountId = account.Id }).Entity;
                _databaseContext.SaveChanges();
            }

            // TODO
            //if (session.InGame)
            //{
            //    _authorizationFactory.SendError(loginSession, ServerErrorType.NoUserLoginAnother);
            //    return;
            //}

            loginSession.SessionLogin = new SessionLoginModel();
            loginSession.SessionLogin.AccountId = account.Id;
            loginSession.SessionLogin.SessionId = session.Id;
            loginSession.SessionLogin.InGame = session.InGame;

            _serversFactory.SendServers(loginSession);
        }
    }
}