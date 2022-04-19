using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Npc
{
    /// <summary>
    ///     Model for merchant buy
    /// </summary>
    [Model(PacketType.MerchantBuyReq)]
    public class MerchantBuyReqModel
    {
        public MerchantBuyReqModel()
        {
            UniqueIdentifier = new UniqueIdentifier(UniqueIdentifierType.Npc);
        }
        /// <summary>
        ///     Unique Npc
        /// </summary>
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public int ParmA { get; set; }
        public int ParmB { get; set; }
        public int SortKey { get; set; }
    }
}
