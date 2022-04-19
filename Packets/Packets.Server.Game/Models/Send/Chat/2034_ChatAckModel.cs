using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Chat
{
    /// <summary>
    ///     Model for chat ack
    /// </summary>
    [Model(PacketType.ChatAck)]
    public class ChatAckModel
    {
        public byte Type { get; set; }
        public UniqueId SessionGameId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}