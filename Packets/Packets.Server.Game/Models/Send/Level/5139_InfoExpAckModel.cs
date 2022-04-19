using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Level
{
    /// <summary>
    ///     Model for info exp ack
    /// </summary>
    [Model(PacketType.InfoExpAck)]
    public class InfoExpAckModel
    {
        public short Level { get; set; }
        public long Exp { get; set; }
        public long ExpAim { get; set; }
    }
}