using Packets.Core.Attributes;
using Packets.Server.Game.Models.Send.Settings;

namespace Packets.Server.Game.Parsers.Send.Settings
{
    /// <summary>
    ///     Парсер пакета настроек клиента
    /// </summary>
    [ParserSend]
    public class SettingClient
    {
        [ParserAction(Core.Enums.PacketType.CheckNeedMoney)]
        public byte[] Parsing(CheckNeedMoneyModel model)
        {

            return new byte[123];
        }
    }
}