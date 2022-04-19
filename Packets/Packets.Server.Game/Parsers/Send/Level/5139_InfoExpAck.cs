using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Level;

namespace Packets.Server.Game.Parsers.Send.Level
{
    /// <summary>
    ///     Parser for info exp ack
    /// </summary>
    [ParserSend]
    public class InfoExpAck
    {
        [ParserAction(PacketType.InfoExpAck)]
        public byte[] Parsing(InfoExpAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddShort(model.Level);
            formationPackage.AddLong(model.Exp);
            formationPackage.AddLong(model.ExpAim);

            return formationPackage.GetBytes();
        }
    }
}