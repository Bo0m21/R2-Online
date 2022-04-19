using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for existed item ack
    /// </summary>
    [Model(PacketType.ExistedItemAck)]
    public class ExistedItemAckModel
    {
        public ExistedItemAckModel()
        {
            Items = new List<PublicItem>();
        }

        public List<PublicItem> Items { get; set; }
    }
}