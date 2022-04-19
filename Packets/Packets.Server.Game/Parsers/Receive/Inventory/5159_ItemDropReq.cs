using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Inventory;

namespace Packets.Server.Game.Parsers.Receive.Inventory
{
    /// <summary>
    ///     Parser for item drop req
    /// </summary>
    [ParserReceive]
    public class ItemDropReq
    {
        [ParserAction(PacketType.ItemDropReq)]
        public ItemDropReqModel Parsing(byte[] data)
        {
            ItemDropReqModel itemDropReqModel = new ItemDropReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            itemDropReqModel.SerialNumber = formationPackage.ReadULong();
            itemDropReqModel.Stack = formationPackage.ReadUInteger();

            return itemDropReqModel;
        }
    }
}
