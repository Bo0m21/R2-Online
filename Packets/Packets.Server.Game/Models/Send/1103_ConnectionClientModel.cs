using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send
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