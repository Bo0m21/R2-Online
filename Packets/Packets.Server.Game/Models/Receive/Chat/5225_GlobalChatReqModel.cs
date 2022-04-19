using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Chat
{
    /// <summary>
    ///     Model for global chat req
    /// </summary>
    [Model(PacketType.GlobalChatReq)]
    public class GlobalChatReqModel
    {
        public string Message { get; set; }
    }
}