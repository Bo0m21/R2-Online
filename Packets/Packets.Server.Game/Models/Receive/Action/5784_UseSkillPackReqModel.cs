using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Action
{
    /// <summary>
    ///     Model for use skill pack req
    /// </summary>
    [Model(PacketType.UseSkillPackReq)]
    public class UseSkillPackReqModel
    {
        public UseSkillPackReqModel()
        {
            TargetUniqueId = new UniqueIdentifier(UniqueIdentifierType.Player);
        }

        public int SkillId { get; set; }
        public UniqueIdentifier TargetUniqueId { get; set; }
        public byte IsTeam { get; set; }

    }
}
