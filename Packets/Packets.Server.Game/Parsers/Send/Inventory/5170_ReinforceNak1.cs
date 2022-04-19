using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for reinforce nak
    /// </summary>
    [ParserSend]
    public class ReinforceNak1
    {
        [ParserAction(PacketType.ReinforceNak1)]
        public byte[] Parsing(ReinforceNak1Model model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddByte(model.IsDestroy);
            formationPackage.AddULong(model.SerialNumber);

            return formationPackage.GetBytes();
        }
    }
}
