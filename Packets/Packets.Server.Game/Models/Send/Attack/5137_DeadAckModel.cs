using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Attack
{
    /// <summary>
    ///     Model for dead ack
    /// </summary>
    [Model(PacketType.DeadAck)]
    public class DeadAckModel
    {
        public UniqueIdentifier DefenseSessionGameId { get; set; }
        public UniqueIdentifier OffenseSessionGameId { get; set; }
        public int Chaotic { get; set; }
        public ChaoticStatusType ChaoticStatus { get; set; }
    }

    /// <summary>
    ///     Chaotic status type
    /// </summary>
    public enum ChaoticStatusType : int
    {
        Chaotic3 = 0x0,
        Chaotic2 = 0x1,
        Chaotic1 = 0x2,
        Normal = 0x3,
        Low1 = 0x4,
        Low2 = 0x5,
        Low3 = 0x6,
        Cnt = 0x7,
    }
}
