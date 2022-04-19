using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for item change ack
    /// </summary>
    [Model(PacketType.ItemChangeAck)]
    public class ItemChangeAckModel
    {
        public ulong SerialNumber { get; set; }
        public int ItemId { get; set; }
        public byte Reason { get; set; }
        public int IsCreate { get; set; }
    }
}