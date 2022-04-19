using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Chat
{
    /// <summary>
    ///     Model for chat ack
    /// </summary>
    [Model(PacketType.GossipAck)]
    public class GossipAckModel
    {
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Message { get; set; }

    }
}
