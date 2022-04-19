using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for un equip ack all
    /// </summary>
    [Model(PacketType.UnEquipAckAll)]
    public class UnEquipAckAllModel
    {
        public ItemPositionType Position { get; set; }
        public UniqueId SessionGameId { get; set; }
    }
}
