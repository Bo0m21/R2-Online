using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Chat
{
    /// <summary>
    ///     Model for chat req
    /// </summary>
    [Model(PacketType.ChatReq)]
    public class ChatReqModel
    {
        public byte Type { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}