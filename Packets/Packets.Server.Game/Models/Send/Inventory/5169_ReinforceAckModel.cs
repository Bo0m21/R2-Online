using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for reinforce ack
    /// </summary>
    [Model(PacketType.ReinforceAck)]
    public class ReinforceAckModel
    {
        public ulong SerialNumber { get; set; }
        public int ItemId { get; set; }
        public byte IsConfirm { get; set; }
    }
}
