using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Character
{
    /// <summary>
    ///     Model for delete pc
    /// </summary>
    [Model(PacketType.DeletePcReq)]
    public class DeletePcReqModel
    {
        public uint CharacterId { get; set; }
        public byte Slot { get; set; }
    }
}