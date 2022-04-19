using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Inventory
{
    /// <summary>
    ///     Model for item drop req
    /// </summary>
    [Model(PacketType.ItemDropReq)]
    public class ItemDropReqModel
    {
        public ulong SerialNumber { get; set; }
        public uint Stack { get; set; }
    }
}
