using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Attack;

namespace Packets.Server.Game.Parsers.Send.Attack
{
    /// <summary>
    ///     Parser for attack ack
    /// </summary>
    [ParserSend]
    public class AttackAck
    {
        [ParserAction(PacketType.AttackAck)]
        public byte[] Parsing(AttackAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.OffenseSessionGameId.Write(formationPackage);
            model.DefenseSessionGameId.Write(formationPackage);
            formationPackage.AddByte((byte)model.TypeHit);
            formationPackage.AddZeroBytes(9);
            model.OffensePosition.Write(formationPackage);
            formationPackage.AddShort(model.HpAttacked);

            return formationPackage.GetBytes();
        }
    }
}