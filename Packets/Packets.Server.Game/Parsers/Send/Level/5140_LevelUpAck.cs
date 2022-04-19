using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Level;

namespace Packets.Server.Game.Parsers.Send.Level
{
    /// <summary>
    ///     Parser for level up ack
    /// </summary>
    [ParserSend]
    public class LevelUpAck
    {
        [ParserAction(PacketType.LevelUpAck)]
        public byte[] Parsing(LevelUpAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            formationPackage.AddShort(model.Hp);
            formationPackage.AddShort(model.Mp);

            return formationPackage.GetBytes();
        }
    }
}