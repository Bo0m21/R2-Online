using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Login.Models.Receive;

namespace Packets.Server.Login.Parsers.Receive
{
    /// <summary>
    ///     Parser refresh servers packet
    /// </summary>
    [ParserReceive]
    public class RefreshServers
    {
        [ParserAction(PacketType.RefreshServers)]
        public RefreshServersModel Parsing(byte[] data)
        {
            return new RefreshServersModel();
        }
    }
}