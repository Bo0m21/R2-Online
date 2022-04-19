using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Attack;

namespace Packets.Server.Game.Parsers.Send.Attack
{
    /// <summary>
    ///     Parser for dead ack
    /// </summary>
    [ParserSend]
    public class DeadAck
    {
        [ParserAction(PacketType.DeadAck)]
        public byte[] Parse(DeadAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.DefenseSessionGameId.Write(formationPackage);
            model.OffenseSessionGameId.Write(formationPackage);
            formationPackage.AddZeroBytes(4);
            formationPackage.AddInteger(model.Chaotic);
            formationPackage.AddInteger((int)model.ChaoticStatus);

            return formationPackage.GetBytes();
        }
    }
}
