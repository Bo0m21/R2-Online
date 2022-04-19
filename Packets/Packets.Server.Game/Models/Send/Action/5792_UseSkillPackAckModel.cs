using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Action
{
    /// <summary>
    ///     Model for use skill pack ack
    /// </summary>
    [Model(PacketType.UseSkillPackAck)]
    public class UseSkillPackAckModel
    {
        public int SkillId { get; set; }
    }
}
