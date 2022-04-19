using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Attack
{
    /// <summary>
    ///     Attack req model
    /// </summary>
    [Model(PacketType.AttackReq)]
    public class AttackReqModel
    {
        public AttackReqModel()
        {
            TargetSessionGameId = new UniqueIdentifier(UniqueIdentifierType.Player);
            AttackPosition = new Vector3();
        }

        public UniqueIdentifier TargetSessionGameId { get; set; }
        public ushort AttackType { get; set; }
        public Vector3 AttackPosition { get; set; }
        public byte AttackFlag { get; set; }
    }
}