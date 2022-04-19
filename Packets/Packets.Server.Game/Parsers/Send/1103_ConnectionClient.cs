using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Send;

namespace Packets.Server.Game.Parsers.Send
{
    /// <summary>
    ///     Parser connection client
    /// </summary>
    [ParserSend]
    public class ConnectionClient
    {
        [ParserAction(PacketType.ConnectionClient)]
        public byte[] Parsing(ConnectionClientModel model)
        {
            return model.DecryptKey;
        }
    }
}