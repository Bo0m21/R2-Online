using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive;

namespace Packets.Server.Game.Parsers.Receive
{
    /// <summary>
    ///     Parser for logout pc req
    /// </summary>
    [ParserReceive]
    public class LogoutPcReq
    {
        [ParserAction(PacketType.LogoutPcReq)]
        public LogoutPcReqModel Parsing(byte[] data)
        {
            return new LogoutPcReqModel();
        }
    }
}