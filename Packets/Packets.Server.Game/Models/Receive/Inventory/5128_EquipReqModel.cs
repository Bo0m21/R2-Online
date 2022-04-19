using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Inventory
{
    /// <summary>
    ///     Model for equip req
    /// </summary>
    [Model(PacketType.EquipReq)]
    public class EquipReqModel
    {
        public ulong SerialNumber { get; set; }
        public uint Index { get; set; }
    }
}
