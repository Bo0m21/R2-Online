using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Inventory;

namespace Packets.Server.Game.Parsers.Receive.Inventory
{
    /// <summary>
    ///     Parser for item pick up req
    /// </summary>
    [ParserReceive]
    public class ItemPickupReq
    {
        [ParserAction(PacketType.ItemPickupReq)]
        public ItemPickupReqModel Parser(byte[] data)
        {
            ItemPickupReqModel itemPickupReqModel = new ItemPickupReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            itemPickupReqModel.UniqueIdentifierItem.Read(formationPackage);

            return itemPickupReqModel;
        }
    }
}
