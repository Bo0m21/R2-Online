using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Receive.Inventory;

namespace Packets.Server.Game.Parsers.Receive.Inventory
{
    /// <summary>
    ///     Parser for un equip req
    /// </summary>
    [ParserReceive]
    public class UnEquipReq
    {
        [ParserAction(PacketType.UnEquipReq)]
        public UnEquipReqModel Parse(byte[] data)
        {
            UnEquipReqModel unEquipReqModel = new UnEquipReqModel();
            
            FormationPackage formationPackage = new FormationPackage(data);
            unEquipReqModel.Position = (ItemPositionType)formationPackage.ReadByte();

            return unEquipReqModel;
        }
    }
}
