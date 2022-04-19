using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model for respawn ack
    /// </summary>
    [Model(PacketType.RespawnAck)]
    public class RespawnAckModel
    {
        public UniqueIdentifier SessionGameId { get; set; }
        public Vector3 Position { get; set; }
    }
}
