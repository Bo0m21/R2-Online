using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for equip ack all
    /// </summary>
    [ParserSend]
    public class EquipAckAll
    {
        [ParserAction(PacketType.EquipAckAll)]
        public byte[] Parsing(EquipAckAllModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            formationPackage.AddInteger(model.ItemId);
            formationPackage.AddULong(model.SerialNumber);
            formationPackage.AddByte((byte)model.Position);

            return formationPackage.GetBytes();
        }
    }
}
