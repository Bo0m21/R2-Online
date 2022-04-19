using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;
using System.Collections.Generic;

namespace Packets.Server.Game.Models.Send.Npc
{
    /// <summary>
    ///     Model for merchant list ack
    /// </summary>
    [Model(PacketType.MerchantListAck)]
    public class MerchantListAckModel
    {
        /// <summary>
        ///     Unique Npc
        /// </summary>
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public int MerchantId { get; set; }
        public int ParmA { get; set; }
        public int ParmB { get; set; }
        public int CountBuy { get; set; }
        public int CountSell { get; set; }
        public int CountCharge { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<Item> ItemList { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public int Price { get; set; }
        public int Flag { get; set; }
        public int SortKey { get; set; }
    }
}
