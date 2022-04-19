using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета отображенного персонажа
    /// </summary>
    [ParserSend]
    public class DisplayedCharacters
    {
        [ParserAction(Core.Enums.PacketType.DisplayedCharacter)]
        public byte[] Parsing(DisplayedCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.Character.Write(formationPackage);

            formationPackage.AddByte(model.IsTeleport ? (byte)1 : (byte)0);

            formationPackage.AddZeroBytes(9);

            return formationPackage.GetBytes();
        }
    }
}