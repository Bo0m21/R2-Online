using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;

namespace Packets.Server.Game.Models.Receive.Inventory
{
    /// <summary>
    ///     Model for un equip req
    /// </summary>
    [Model(PacketType.UnEquipReq)]
    public class UnEquipReqModel
    {
        public ItemPositionType Position { get; set; }
    }
}
