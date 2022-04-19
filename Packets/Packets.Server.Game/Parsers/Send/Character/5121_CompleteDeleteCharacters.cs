using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета подтверждения удаления персонажа
    /// </summary>
    [ParserSend]
    public class CompleteDeleteCharacters
    {
        [ParserAction(Core.Enums.PacketType.CompleteDeleteCharacter)]
        public byte[] Parsing(CompleteDeleteCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            // Отправляется пустой пакет

            return formationPackage.GetBytes();
        }
    }
}