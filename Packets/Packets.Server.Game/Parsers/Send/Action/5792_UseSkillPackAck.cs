using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Action;

namespace Packets.Server.Game.Parsers.Send.Action
{
    /// <summary>
    ///     Parser for use skill pack ack
    /// </summary>
    [ParserSend]
    public class UseSkillPackAck
    {
        [ParserAction(PacketType.UseSkillPackAck)]
        public byte[] Parsing(UseSkillPackAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.SkillId);

            return formationPackage.GetBytes();
        }
    }
}