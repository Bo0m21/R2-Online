using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Packets.Server.Login.Models.Send;
using Packets.Server.Login.Models.Send.Models;
using Server.Login.Core.Factories.Interfaces;
using Server.Login.Network;

namespace Server.Login.Core.Factories
{
    /// <inheritdoc/>
    public class ServersFactory : IServersFactory
    {
        private readonly IDatabaseContext _databaseContext;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        /// <param name="databaseContext"></param>
        public ServersFactory(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <inheritdoc/>
        public void SendServers(LoginSession loginSession)
        {
            SendServersModel sendServersModel = new SendServersModel
            {
                AccountId = loginSession.SessionLogin.AccountId,
                SessionId = loginSession.SessionLogin.SessionId,
                Servers = GetServers()
            };

            loginSession.Send(sendServersModel);
        }

        /// <inheritdoc/>
        public void SendRefreshedServers(LoginSession loginSession)
        {
            RefreshedServersModel refreshedServersModel = new RefreshedServersModel()
            {
                Servers = GetServers()
            };

            loginSession.Send(refreshedServersModel);
        }

        /// <inheritdoc/>
        public void SendSelectedServer(LoginSession loginSession)
        {
            SelectedServerModel selectedServerModel = new SelectedServerModel();

            loginSession.Send(selectedServerModel);
        }

        /// <summary>
        ///     Write all servers in the packet
        /// </summary>
        /// <returns></returns>
        private List<ServerModel> GetServers()
        {
            List<ServerModel> serverModels = new List<ServerModel>();
            List<Database.Models.ServerModel> servers = _databaseContext.Servers.ToList();

            foreach (Database.Models.ServerModel server in servers)
            {
                ServerModel serverModel = new ServerModel
                {
                    Id = (short)server.ServerId,
                    Congestion = (CongestionType)server.Congestion,
                    Hidden = server.Hidden,
                    Name = server.Name,
                    ServerIp = server.ServerIp,
                    ServerPort = (short)server.ServerPort,
                    Status = server.Status,
                    Type = (ServerType)server.Type
                };

                serverModels.Add(serverModel);
            }

            return serverModels;
        }
    }
}