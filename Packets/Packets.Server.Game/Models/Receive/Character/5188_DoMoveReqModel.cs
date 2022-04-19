using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Character
{
    /// <summary>
    ///     Model for do move req
    /// </summary>
    [Model(PacketType.DoMoveReq)]
    public class DoMoveReqModel
    {
        public DoMoveReqModel()
        {
            Position = new Vector3();
        }

        public Vector3 Position { get; set; }
        public float Direction { get; set; }
        public uint Action { get; set; }
        public byte Flag { get; set; }
    }
}