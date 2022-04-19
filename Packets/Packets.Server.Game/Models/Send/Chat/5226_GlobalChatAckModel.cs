using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Chat
{
    /// <summary>
    ///     Model for global chat ack
    /// </summary>
    [Model(PacketType.GlobalChatAck)]
    public class GlobalChatAckModel
    {
        public UniqueIdentifier SessionGameId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}