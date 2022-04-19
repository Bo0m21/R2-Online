//using Packets.Core.Attributes;
//using Packets.Core.Utilities;
//using Packets.Server.Game.Models.Send.Settings;

//namespace Packets.Server.Game.Parsers.Send.Settings
//{
//    /// <summary>
//    ///     Парсер времени сервера
//    /// </summary>
//    [ParserSend]
//    public class StoreCount
//    {
//        [ParserAction(Core.Enums.PacketType.ServerTime)]
//        public byte[] Parsing(ServerTimeModel model)
//        {
//            FormationPackage formationPackage = new FormationPackage();

//            // Понять для чего этот пакет и переделать

//            // Не расшифрованные байты
//            formationPackage.AddZeroBytes(4);

//            // Время сервера
//            formationPackage.AddShort(model.Year);
//            formationPackage.AddShort(model.Month);
//            formationPackage.AddShort(model.DayOfWeek);
//            formationPackage.AddShort(model.Day);
//            formationPackage.AddShort(model.Hour);
//            formationPackage.AddShort(model.Minute);
//            formationPackage.AddShort(model.Second);
//            formationPackage.AddShort(model.Millisecond);

//            return formationPackage.GetBytes();
//        }
//    }
//}