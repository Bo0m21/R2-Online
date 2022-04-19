using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета перемещенного персонажа
    /// </summary>
    [ParserSend]
    public class MovedCharacters
    {
        [ParserAction(Core.Enums.PacketType.MovedCharacter)]
        public byte[] Parsing(MovedCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            model.Position.Write(formationPackage);
            formationPackage.AddShort(model.MoveRate);
            formationPackage.AddByte(model.Flag);
            formationPackage.AddFloat(model.DirectionSight);
            formationPackage.AddUInteger(model.Action);

            return formationPackage.GetBytes();
        }
    }
}