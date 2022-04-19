using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Character
{
    /// <summary>
    ///     Model for char dir req
    /// </summary>
    [Model(PacketType.CharDirReq)]
    public class CharDirectionReqModel
    {
        public float Direction { get; set; }
    }
}
