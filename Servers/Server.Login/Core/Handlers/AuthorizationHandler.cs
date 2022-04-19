using System.Linq;
using Database.Account.Interfaces;
using Database.Account.Models;
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
        private readonly IAccountContext _accountContext;
        private readonly IAuthorizationFactory _authorizationFactory;
        private readonly IServersFactory _serversFactory;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        /// <param name="databaseContext"></param>
        /// <param name="authorizationFactory"></param>
        /// <param name="serversFactory"></param>
        public AuthorizationHandler(IAccountContext accountContext, IAuthorizationFactory authorizationFactory, IServersFactory serversFactory)
        {
            _accountContext = accountContext;
            _authorizationFactory = authorizationFactory;
            _serversFactory = serversFactory;
        }

        /// <inheritdoc />
        [HandlerAction(PacketType.AuthorizationLogin)]
        public void AuthorizationLoginHandle(LoginSession loginSession, AuthorizationLoginModel authorizationLoginModel)
        {
            authorizationLoginModel.Login = "admin";
            authorizationLoginModel.Password = "test";
            AccountModel account = _accountContext.Accounts.FirstOrDefault(a => a.Login == authorizationLoginModel.Login);

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

            SessionModel session = _accountContext.Sessions.FirstOrDefault(c => c.AccountId == account.Id);

            if (session == null)
            {
                session = _accountContext.Sessions.Add(new SessionModel { AccountId = account.Id }).Entity;
                _accountContext.SaveChanges();
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