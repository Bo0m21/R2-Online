using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character.Characteristics;

namespace Packets.Server.Game.Parsers.Send.Character.Characteristics
{
    /// <summary>
    ///     Парсер пакета файктического здоровья и маны
    /// </summary>
    [ParserSend]
    public class HealthPointCharacteristic
    {
        [ParserAction(Core.Enums.PacketType.HealthPointCharacteristic)]
        public byte[] Parsing(HealthPointCharacteristicModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.Hp);
            formationPackage.AddInteger(model.Mp);

            return formationPackage.GetBytes();
        }
    }
}