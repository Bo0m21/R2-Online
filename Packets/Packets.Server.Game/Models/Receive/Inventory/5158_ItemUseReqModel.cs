using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Inventory
{
    /// <summary>
    ///     Model for un equip req
    /// </summary>
    [Model(PacketType.ItemUseReq)]
    public class ItemUseReqModel
    {
        public ItemUseReqModel()
        {
            UniqueIdentifier = new UniqueIdentifier(UniqueIdentifierType.Item);
        }

        public ulong SerialNumber { get; set; }
        public int ItemId { get; set; }

        /// <summary>
        ///     Unique target
        /// </summary>
        public UniqueIdentifier UniqueIdentifier { get; set; }
        /// <summary>
        ///     SerialNo target
        /// </summary>
        public ulong TargetSerialNumber { get; set; }
        public byte IsTeam { get; set; }

    }
}
