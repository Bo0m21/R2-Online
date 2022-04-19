using Packets.Server.Login.Models.Receive;
using Server.Login.Network;

namespace Server.Login.Core.Handlers.Interfaces
{
    /// <summary>
    ///     Authorization handler
    /// </summary>
    public interface IAuthorizationHandler
    {
        /// <summary>
        ///     Authorization login handle
        /// </summary>
        /// <param name="loginSession"></param>
        /// <param name="authorizationLoginModel"></param>
        void AuthorizationLoginHandle(LoginSession loginSession, AuthorizationLoginModel authorizationLoginModel);
    }
}
