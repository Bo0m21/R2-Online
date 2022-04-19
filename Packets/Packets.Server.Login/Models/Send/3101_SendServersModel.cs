using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Login.Models.Send.Models;

namespace Packets.Server.Login.Models.Send
{
    /// <summary>
    ///     Send server model
    /// </summary>
    [Model(PacketType.SendServers)]
    public class SendServersModel
    {
        public SendServersModel()
        {
            Servers = new List<ServerModel>();
        }

        public int AccountId { get; set; }
        public int SessionId { get; set; }

        public List<ServerModel> Servers { get; set; }
    }
}