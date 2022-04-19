using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character.Characteristics;

namespace Packets.Server.Game.Parsers.Send.Character.Characteristics
{
    /// <summary>
    ///     Парсер пакета характеристик скорости
    /// </summary>
    [ParserSend]
    public class SpeedCharacteristics
    {
        [ParserAction(Core.Enums.PacketType.SpeedCharacteristic)]
        public byte[] Parsing(SpeedCharacteristicModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddShort(model.AttackRate);
            formationPackage.AddShort(model.MoveRate);
            model.SessionGameId.Write(formationPackage);

            return formationPackage.GetBytes();
        }
    }
}