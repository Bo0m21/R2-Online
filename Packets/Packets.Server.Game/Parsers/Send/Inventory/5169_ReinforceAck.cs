using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for reinforce ack
    /// </summary>
    [ParserSend]
    public class ReinforceAck
    {
        [ParserAction(PacketType.ReinforceAck)]
        public byte[] Parsing(ReinforceAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddULong(model.SerialNumber);
            formationPackage.AddInteger(model.ItemId);
            formationPackage.AddByte(model.IsConfirm);

            return formationPackage.GetBytes();
        }
    }
}