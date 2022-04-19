using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for info weight ack
    /// </summary>
    [Model(PacketType.InfoWeightAck)]
    public class InfoWeightAckModel
    {
        public int MaxWeight { get; set; }
        public int Weight { get; set; }
        public byte WeightStatus { get; set; }
    }
}
