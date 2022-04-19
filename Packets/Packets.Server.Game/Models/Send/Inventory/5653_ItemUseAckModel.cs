using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model displayed character
    /// </summary>
    [Model(PacketType.ItemUseAck)]
    public class ItemUseAckModel
    {
        public int ItemId { get; set; }
    }
}
