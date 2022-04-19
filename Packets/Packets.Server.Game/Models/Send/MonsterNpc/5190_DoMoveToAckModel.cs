using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.MonsterNpc
{
    /// <summary>
    ///     Model for do move to ack
    /// </summary>
    [Model(PacketType.DoMoveToAck)]
    public class DoMoveToAckModel
    {
        public DoMoveToAckModel()
        {
            Position = new Vector3();
            PointPosition = new Vector3();
        }

        public UniqueId SessionGameId { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 PointPosition { get; set; }
        public byte Flag { get; set; }
        public float Velocity { get; set; }
    }
}
