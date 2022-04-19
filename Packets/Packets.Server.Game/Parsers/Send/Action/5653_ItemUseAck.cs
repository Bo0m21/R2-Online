using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Action
{
    /// <summary>
    ///     Parser for attack ack
    /// </summary>
    [ParserSend]
    public class ItemUseAck
    {
        [ParserAction(PacketType.ItemUseAck)]
        public byte[] Parsing(ItemUseAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.ItemId);

            return formationPackage.GetBytes();
        }
    }
}