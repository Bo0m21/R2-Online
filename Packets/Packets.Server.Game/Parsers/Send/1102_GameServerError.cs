using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send;

namespace Packets.Server.Game.Parsers.Send
{
    /// <summary>
    ///     Парсер ошибки сервера
    /// </summary>
    [ParserSend]
    public class GameServerError
    {
        [ParserAction(Core.Enums.PacketType.GameServerError)]
        public byte[] Parsing(GameServerErrorModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            // Отправляем номер ошибки
            formationPackage.AddShort((short)model.PacketType);
            formationPackage.AddUInteger((uint) model.ErrorType);
            formationPackage.AddZeroBytes(8);
            formationPackage.AddByte(model.IsMsgBox ? (byte)1 : (byte)0);
            

            return formationPackage.GetBytes();
        }
    }
}