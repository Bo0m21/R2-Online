using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Action;

namespace Packets.Server.Game.Parsers.Send.Action
{
    /// <summary>
    ///     Parser for abnormal ack
    /// </summary>
    [ParserSend]
    public class AbnormalAck
    {
        [ParserAction(PacketType.AbnormalAck)]
        public byte[] Parsing(AbnormalAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.UniqueIdentifier.Write(formationPackage);
            formationPackage.AddInteger(model.BuffId);
            formationPackage.AddUInteger(model.EndTick);
            model.Position.Write(formationPackage);

            return formationPackage.GetBytes();
        }
    }
}