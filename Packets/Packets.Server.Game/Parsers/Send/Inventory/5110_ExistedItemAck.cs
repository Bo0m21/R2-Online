using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for existed item ack
    /// </summary>
    [ParserSend]
    public class DisplayedItem
    {
        [ParserAction(PacketType.ExistedItemAck)]
        public byte[] Parsing(ExistedItemAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddUShort((ushort)model.Items.Count);

            foreach (PublicItem item in model.Items)
            {
                item.Write(formationPackage);
            }

            return formationPackage.GetBytes();
        }
    }
}