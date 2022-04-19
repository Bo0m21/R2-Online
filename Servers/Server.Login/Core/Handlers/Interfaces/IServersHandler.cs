using Packets.Server.Login.Models.Receive;
using Server.Login.Network;

namespace Server.Login.Core.Handlers.Interfaces
{
    /// <summary>
    ///     Servers handler
    /// </summary>
    public interface IServersHandler
    {
        /// <summary>
        ///     Select server handle
        /// </summary>
        /// <param name="loginSession"></param>
        /// <param name="selectServerModel"></param>
        void SelectServerHandle(LoginSession loginSession, SelectServerModel selectServerModel);

        /// <summary>
        ///     Refresh servers handle
        /// </summary>
        /// <param name="loginSession"></param>
        /// <param name="refreshServersModel"></param>
        void RefreshServersHandle(LoginSession loginSession, RefreshServersModel refreshServersModel);
    }
}
