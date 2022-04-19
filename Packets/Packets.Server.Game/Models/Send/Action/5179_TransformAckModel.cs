using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Action
{
    /// <summary>
    ///     Model displayed character
    /// </summary>
    [Model(PacketType.TransformAck)]
    public class TransformAckModel
    {
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public int MonsterId { get; set; }
    }
}