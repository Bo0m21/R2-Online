using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for item add ack
    /// </summary>
    [ParserSend]
    public class ItemAddAck
    {
        [ParserAction(PacketType.ItemAddAck)]
        public byte[] Parsing(ItemAddAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.Item.Write(formationPackage);
            formationPackage.AddZeroBytes(60);
            model.SessionGameId.Write(formationPackage);
            formationPackage.AddByte(model.Reason);

            return formationPackage.GetBytes();
        }
    }
}