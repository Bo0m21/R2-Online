using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета конца прыжка
    /// </summary>
    [ParserSend]
    public class JumpEndCharacters
    {
        [ParserAction(Core.Enums.PacketType.JumpEndCharacter)]
        public byte[] Parsing(JumpEndCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            formationPackage.AddUInteger(model.Action);
            formationPackage.AddFloat(model.DirectionSight);

            return formationPackage.GetBytes();
        }
    }
}