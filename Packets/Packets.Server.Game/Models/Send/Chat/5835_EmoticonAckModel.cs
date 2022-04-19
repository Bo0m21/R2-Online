using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Chat
{
    /// <summary>
    ///     Model for emoji ack
    /// </summary>
    [Model(PacketType.EmoticonAck)]
    public class EmoticonAckModel
    {
        public int Type { get; set; }
        public UniqueId SessionGameId { get; set; }
        public string Name { get; set; }
    }
}