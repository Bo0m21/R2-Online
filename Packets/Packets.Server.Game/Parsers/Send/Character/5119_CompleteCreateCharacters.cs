using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета подтверждения создания персонажа
    /// </summary>
    [ParserSend]
    public class CompleteCreateCharacters
    {
        [ParserAction(Core.Enums.PacketType.CompleteCreateCharacter)]
        public byte[] Parsing(CompleteCreateCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            // Отпарвка характеристик персонажа
            formationPackage.AddInteger(model.CharacterId);
            formationPackage.AddInteger(model.Str);
            formationPackage.AddInteger(model.Dex);
            formationPackage.AddInteger(model.Int);

            return formationPackage.GetBytes();
        }
    }
}