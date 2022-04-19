using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive
{
    /// <summary>
    ///     Model for choose pc req
    /// </summary>
    [Model(PacketType.ChoosePcReq)]
    public class ChoosePcReqModel
    {
        public uint CharacterId { get; set; }
    }
}