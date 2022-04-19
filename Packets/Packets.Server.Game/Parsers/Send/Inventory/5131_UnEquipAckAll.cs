using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for un equip ack all
    /// </summary>
    [ParserSend]
    public class UnEquipAckAll
    {
        [ParserAction(PacketType.UnEquipAckAll)]
        public byte[] Parse(UnEquipAckAllModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddByte((byte)model.Position);
            formationPackage.AddZeroBytes(3);
            model.SessionGameId.Write(formationPackage);

            return formationPackage.GetBytes();
        }
    }
}
