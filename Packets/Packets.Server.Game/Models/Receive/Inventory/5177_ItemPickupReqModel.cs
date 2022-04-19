using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Inventory
{
    /// <summary>
    ///     Model for item pick up req
    /// </summary>
    [Model(PacketType.ItemPickupReq)]
    public class ItemPickupReqModel
    {
        public ItemPickupReqModel()
        {
            UniqueIdentifierItem = new UniqueId(UniqueIdentifierType.Item);
        }

        public UniqueId UniqueIdentifierItem { get; set; }
    }
}
