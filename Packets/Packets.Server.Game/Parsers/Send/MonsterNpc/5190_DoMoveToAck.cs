using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.MonsterNpc;

namespace Packets.Server.Game.Parsers.Send.MonsterNpc
{
    /// <summary>
    ///     Parser for do move to ack
    /// </summary>
    [ParserSend]
    public class MovedToPoint
    {
        [ParserAction(PacketType.DoMoveToAck)]
        public byte[] Parse(DoMoveToAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            model.Position.Write(formationPackage);
            model.PointPosition.Write(formationPackage);
            formationPackage.AddByte(model.Flag);
            formationPackage.AddFloat(model.Velocity);

            return formationPackage.GetBytes();
        }
    }
}
