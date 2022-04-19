using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Character
{
    /// <summary>
    ///     Model for creating pc
    /// </summary>
    [Model(PacketType.CreatePcReq)]
    public class CreatePcReqModel
    {
        public byte Slot { get; set; }
        public byte Class { get; set; }
        public byte Sex { get; set; }
        public byte Head { get; set; }
        public byte Face { get; set; }
        public byte TypeBody { get; set; }
        public string Name { get; set; }
    }
}