using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Character
{
    /// <summary>
    ///     Model for respawn req
    /// </summary>
    [Model(PacketType.RespawnReq)]
    public class RespawnReqModel
    {
        public byte IsRespawn { get; set; }
    }
}