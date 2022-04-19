using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for equip ack all
    /// </summary>
    [Model(PacketType.EquipAckAll)]
    public class EquipAckAllModel
    {
        public UniqueId SessionGameId { get; set; }
        public int ItemId { get; set; }
        public ulong SerialNumber { get; set; }
        public ItemPositionType Position { get; set; }
    }
}
