using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Action;

namespace Packets.Server.Game.Parsers.Send.Action
{
    /// <summary>
    ///     Parser for item cooldown ack
    /// </summary>
    [ParserSend]
    public class ItemCooldownAck
    {
        [ParserAction(PacketType.ItemCooldown)]
        public byte[] Parsing(ItemCooldownAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.ItemId);

            return formationPackage.GetBytes();
        }
    }
}