using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model for char direction ack
    /// </summary>
    [Model(PacketType.CharDirAck)]

    public class CharDirectionModel
    {
        public UniqueIdentifier SessionGameId { get; set; }
        public float DirectionSight { get; set; }
    }
}
