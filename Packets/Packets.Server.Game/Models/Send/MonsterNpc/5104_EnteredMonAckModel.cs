using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.MonsterNpc
{
    /// <summary>
    ///     Model for entered mon ack
    /// </summary>
    [Model(PacketType.EnteredMonAck)]
    public class EnteredMonAckModel
    {
        public Monster Monster { get; set; }
        public bool IsTeleport { get; set; }
        public byte CntAbn { get; set; }
    }
}