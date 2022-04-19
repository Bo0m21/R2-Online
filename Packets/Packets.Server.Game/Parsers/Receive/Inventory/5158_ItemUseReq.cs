using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Inventory;

namespace Packets.Server.Game.Parsers.Receive.Inventory
{
    /// <summary>
    ///     Parser for equip req
    /// </summary>
    [ParserReceive]
    public class ItemUseReq
    {
        [ParserAction(PacketType.ItemUseReq)]
        public ItemUseReqModel Parsing(byte[] data)
        {
            ItemUseReqModel itemUseReqModel = new ItemUseReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            itemUseReqModel.SerialNumber = formationPackage.ReadULong();
            itemUseReqModel.ItemId = formationPackage.ReadInteger();
            itemUseReqModel.UniqueIdentifier.Read(formationPackage);
            itemUseReqModel.TargetSerialNumber = formationPackage.ReadULong();
            itemUseReqModel.IsTeam = formationPackage.ReadByte();

            return itemUseReqModel;
        }
    }
}