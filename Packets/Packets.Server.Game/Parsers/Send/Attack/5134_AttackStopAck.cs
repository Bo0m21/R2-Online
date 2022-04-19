using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Attack;

namespace Packets.Server.Game.Parsers.Send.Attack
{
    /// <summary>
    ///     Parser for attack stop ack
    /// </summary>
    [ParserSend]
    public class AttackStopAck
    {
        [ParserAction(Core.Enums.PacketType.AttackStopAck)]
        public byte[] Parsing(AttackStopAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.OffenceSesionGameId.Write(formationPackage);
            formationPackage.AddZeroBytes(4);

            return formationPackage.GetBytes();
        }
    }
}
