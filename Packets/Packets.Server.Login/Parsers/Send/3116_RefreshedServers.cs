using System;
using System.Linq;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Login.Models.Send;
using Packets.Server.Login.Models.Send.Models;

namespace Packets.Server.Login.Parsers.Send
{
    /// <summary>
    ///     Parser refreshed servers
    /// </summary>
    [ParserSend]
    public class RefreshedServers
    {
        [ParserAction(PacketType.RefreshedServers)]
        public byte[] Parsing(RefreshedServersModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            // Количество серверов
            formationPackage.AddByte((byte)model.Servers.Count);

            // Обработка всех серверов
            foreach (ServerModel server in model.Servers)
            {
                // Статус сервера
                formationPackage.AddByte((byte)(server.Status ? 0x01 : 0x00));

                // Ид сервера
                formationPackage.AddShort(server.Id);

                // Получаем название сервера и делаем размер 101 байт
                formationPackage.AddBytes(FormationPackageUtility.GetBytes(server.Name, 101));

                // Загруженность сервера
                formationPackage.AddByte((byte)server.Congestion);

                // Ип сервера
                int[] serverIp = server.ServerIp.Split('.').Select(n => Convert.ToInt32(n)).ToArray();
                foreach (int number in serverIp)
                {
                    formationPackage.AddByte((byte)number);
                }

                // Порт сервера
                formationPackage.AddShort(server.ServerPort, true);

                // Тип сервера - (01)Список серверов/(02)Список открытых серверов
                formationPackage.AddByte((byte)server.Type);

                // Скрыт или показан
                formationPackage.AddByte((byte)(server.Hidden ? 0x01 : 0x00));

                // Не расшифрованные байты
                formationPackage.AddZeroBytes(6);
            }

            return formationPackage.GetBytes();
        }
    }
}