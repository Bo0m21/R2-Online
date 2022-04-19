using Server.Login.Network;

namespace Server.Login.Core.Factories.Interfaces
{
    /// <summary>
    ///     Factory of servers packets
    /// </summary>
    public interface IServersFactory
    {
        /// <summary>
        ///     Sends packet with servers
        /// </summary>
        /// <param name="loginSession"></param>
        void SendServers(LoginSession loginSession);

        /// <summary>
        ///     Sends refreshed packet with servers
        /// </summary>
        /// <param name="loginSession"></param>
        void SendRefreshedServers(LoginSession loginSession);

        /// <summary>
        ///     Sends confirm packet of connecting to server
        /// </summary>
        /// <param name="loginSession"></param>
        void SendSelectedServer(LoginSession loginSession);
    }
}