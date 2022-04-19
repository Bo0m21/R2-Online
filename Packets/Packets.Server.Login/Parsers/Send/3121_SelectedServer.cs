using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Login.Models.Send;

namespace Packets.Server.Login.Parsers.Send
{
    /// <summary>
    ///     Parser selected server
    /// </summary>
    [ParserSend]
    public class SelectedServer
    {
        [ParserAction(PacketType.SelectedServer)]
        public byte[] Parsing(SelectedServerModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            // Не расшифрованные байты
            formationPackage.AddZeroBytes(4);

            return formationPackage.GetBytes();
        }
    }
}