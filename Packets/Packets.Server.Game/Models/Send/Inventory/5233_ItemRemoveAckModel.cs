using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for item remove ack
    /// </summary>
    [Model(PacketType.ItemRemoveAck)]
    public class ItemRemoveAckModel
    {
        public ulong SerialNumber { get; set; }
        public int Count { get; set; }
        public UniqueIdentifier SessionGameId { get; set; }
        public byte Reason { get; set; }
    }
}
