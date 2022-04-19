using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;
using Packets.Server.Game.Enums;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for exit map gbj ack model
    /// </summary>
    [Model(PacketType.ExitMapGbjAck)]
    public class ExitMapGbjAckModel
    {
        public UniqueIdentifier UniqueItemDrop { get; set; }
        public ExitMapWhy Why { get; set; }
    }
}
