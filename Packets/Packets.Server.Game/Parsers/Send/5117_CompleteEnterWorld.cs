using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send;
using System.Linq;

namespace Packets.Server.Game.Parsers.Send
{
    /// <summary>
    ///     Парсер пакета подтверждения входа в мир(инвентарь)
    /// </summary>
    [ParserSend]
    public class CompleteEnterWorld
    {
        [ParserAction(Core.Enums.PacketType.CompleteEnterWorld)]
        public byte[] Parsing(CompleteEnterWorldModel model)
        {
            FormationPackage formationPackage = new FormationPackage();


            formationPackage.AddBytes(new byte[] { 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0xFF, 0x00 }); // Не расшифрованные байты - отображение всех локаций в клиенте

            model.SessionGameId.Write(formationPackage);         // Ид сессии клиента
            formationPackage.AddZeroBytes(4);                    // Не расшифрованные байты
            model.Position.Write(formationPackage);
            formationPackage.AddZeroBytes(18);                   // Не расшифрованные байты
            formationPackage.AddShort(model.AttackRate);
            formationPackage.AddShort(model.MoveRate);
            formationPackage.AddZeroBytes(2);                    // Не расшифрованные байты
            model.Position.Write(formationPackage);
            formationPackage.AddZeroBytes(4);                    // Не расшифрованные байты
            formationPackage.AddInteger(model.Reputation);       // Репутация
            formationPackage.AddZeroBytes(28);                   // Не расшифрованные байты

            formationPackage.AddShort((short)model.Items.Count);// Количество вещей в инвентаре
            formationPackage.AddZeroBytes(6);                    // Не расшифрованные байты

            // Вещи в инвентаре
            for (int i = 0; i < 240; i++)
            {
                var item = model.Items.ElementAtOrDefault(i);

                if (item != null)
                {
                    item.Write(formationPackage);
                }
                else
                {
                    formationPackage.AddZeroBytes(56);
                }
            }

            formationPackage.AddZeroBytes(5);
            return formationPackage.GetBytes();
        }
    }
}