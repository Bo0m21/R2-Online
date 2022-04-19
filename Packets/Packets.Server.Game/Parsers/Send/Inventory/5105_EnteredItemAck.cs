using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for entered item ack
    /// </summary>
    [ParserSend]
    public class EnteredItem
    {
        [ParserAction(Core.Enums.PacketType.EnteredItemAck)]
        public byte[] Parsing(EnteredItemAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.Item.Write(formationPackage);

            return formationPackage.GetBytes();
        }
    }
}