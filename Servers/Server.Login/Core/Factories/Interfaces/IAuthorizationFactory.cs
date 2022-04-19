using Packets.Server.Login.Models.Send;
using Server.Login.Network;

namespace Server.Login.Core.Factories.Interfaces
{
    /// <summary>
    ///     Factory of auth packets
    /// </summary>
    public interface IAuthorizationFactory
    {
        /// <summary>
        ///     Sends welcome packet
        /// </summary>
        /// <param name="loginSession"></param>
        void SendWelcome(LoginSession loginSession);

        /// <summary>
        ///     Sends error packet
        /// </summary>
        /// <param name="loginSession"></param>
        /// <param name="serverErrorType"></param>
        void SendError(LoginSession loginSession, ServerErrorType serverErrorType);
    }
}