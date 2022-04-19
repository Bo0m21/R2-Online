using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Login.Models.Send
{
    /// <summary>
    ///     Connection client model send DecryptKey
    /// </summary>
    [Model(PacketType.ConnectionClient)]
    public class ConnectionClientModel
    {
        public byte[] DecryptKey { get; set; }
    }
}