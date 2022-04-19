using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Action
{
    /// <summary>
    ///     Model abnormal character
    /// </summary>
    [Model(PacketType.AbnormalAck)]
    public class AbnormalAckModel
    {
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public int BuffId { get; set; }
        public uint EndTick { get; set; }
        public Vector3 Position { get; set; }
    }
}