using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Login.Models.Send.Models;

namespace Packets.Server.Login.Models.Send
{
    /// <summary>
    ///     Refreshed server model
    /// </summary>
    [Model(PacketType.RefreshedServers)]
    public class RefreshedServersModel
    {
        public RefreshedServersModel()
        {
            Servers = new List<ServerModel>();
        }

        public List<ServerModel> Servers { get; set; }
    }
}