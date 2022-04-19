using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Character
{
    /// <summary>
    ///     Model for char jump req
    /// </summary>
    [Model(PacketType.CharJumpReq)]
    public class CharJumpReqModel
    {
        public uint Action { get; set; }
        public float MoveDirection { get; set; }
    }
}