using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for entered item ack
    /// </summary>
    [Model(PacketType.EnteredItemAck)]
    public class EnteredItemAckModel
    {
        public EnteredItemAckModel()
        {
            Item = new PublicItem();
        }

        public PublicItem Item { get; set; }
    }
}