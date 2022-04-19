using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Inventory
{
    /// <summary>
    ///     Model for reinforce req
    /// </summary>
    [Model(PacketType.ReinforceReq)]
    public class ReinforceReqModel
    {
        public ulong SerialNumber { get; set; }
        public ulong SerialNumber0 { get; set; }
        public ulong SerialNumber1 { get; set; }
        public ulong SerialNumber2 { get; set; }
        public int Count { get; set; }
    }
}