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
    public class EquipReq
    {
        [ParserAction(PacketType.EquipReq)]
        public EquipReqModel Parsing(byte[] data)
        {
            EquipReqModel equipReqModel = new EquipReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            equipReqModel.SerialNumber = formationPackage.ReadULong();
            equipReqModel.Index = formationPackage.ReadUInteger();

            return equipReqModel;
        }
    }
}
