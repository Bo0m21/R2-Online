using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for item remove ack
    /// </summary>
    [ParserSend]
    public class ItemRemoveAck
    {
        [ParserAction(PacketType.ItemRemoveAck)]
        public byte[] Parsing(ItemRemoveAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddULong(model.SerialNumber);
            formationPackage.AddInteger(model.Count);
            model.SessionGameId.Write(formationPackage);
            formationPackage.AddByte(model.Reason);
            formationPackage.AddZeroBytes(1);

            return formationPackage.GetBytes();
        }
    }
}
