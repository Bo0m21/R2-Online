using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Action;

namespace Packets.Server.Game.Parsers.Send.Action
{
    /// <summary>
    ///     Parser for attack ack
    /// </summary>
    [ParserSend]
    public class AbnormalReleaseAck
    {
        [ParserAction(PacketType.AbnormaleReleaseAck)]
        public byte[] Parsing(AbnormalReleaseAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.UniqueIdentifier.Write(formationPackage);
            formationPackage.AddInteger(model.Type);

            return formationPackage.GetBytes();
        }
    }
}