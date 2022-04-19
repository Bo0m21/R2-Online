using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for item change ack
    /// </summary>
    [ParserSend]
    public class ItemChangeAck
    {
        [ParserAction(PacketType.ItemChangeAck)]
        public byte[] Parsing(ItemChangeAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddULong(model.SerialNumber);
            formationPackage.AddInteger(model.ItemId);
            formationPackage.AddByte(model.Reason);
            formationPackage.AddInteger(model.IsCreate);
            
            return formationPackage.GetBytes();
        }
    }
}