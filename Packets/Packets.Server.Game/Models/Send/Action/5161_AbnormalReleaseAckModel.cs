using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Action
{
    /// <summary>
    ///     Model abnormal character
    /// </summary>
    [Model(PacketType.AbnormaleReleaseAck)]
    public class AbnormalReleaseAckModel
    {
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public int Type { get; set; }
    }
}