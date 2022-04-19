using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for item add ack
    /// </summary>
    [Model(PacketType.ItemAddAck)]
    public class ItemAddAckModel
    {
        public ItemAddAckModel()
        {
            Item = new Item();
        }

        public Item Item { get; set; }
        public UniqueIdentifier SessionGameId { get; set; }
        public byte Reason { get; set; }
    }
}