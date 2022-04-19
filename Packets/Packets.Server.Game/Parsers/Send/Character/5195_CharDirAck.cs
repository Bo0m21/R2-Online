using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета конца прыжка
    /// </summary>
    [ParserSend]
    public class CharDirAck
    {
        [ParserAction(Core.Enums.PacketType.CharDirAck)]
        public byte[] Parsing(CharDirectionModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            formationPackage.AddFloat(model.DirectionSight);

            return formationPackage.GetBytes();
        }
    }
}