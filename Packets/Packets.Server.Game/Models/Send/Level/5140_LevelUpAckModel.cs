using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Level
{
    /// <summary>
    ///     Model for level up ack
    /// </summary>
    [Model(PacketType.LevelUpAck)]
    public class LevelUpAckModel
    {
        public LevelUpAckModel()
        {
            SessionGameId = new UniqueIdentifier(UniqueIdentifierType.Player);
        }

        public UniqueIdentifier SessionGameId { get; set; }
        public short Hp { get; set; }
        public short Mp { get; set; }
    }
}