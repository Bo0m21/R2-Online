using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Parser for respawn ack
    /// </summary>
    [ParserSend]
    public class RespawnAck
    {
        [ParserAction(PacketType.RespawnAck)]
        public byte[] Parse(RespawnAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            model.Position.Write(formationPackage);
            formationPackage.AddZeroBytes(16);

            return formationPackage.GetBytes();
        }
    }
}
