using Packets.Server.Game.Models.Send.Chat;
using Packets.Core.Attributes;
using Packets.Core.Utilities;

namespace Packets.Server.Game.Parsers.Send.Chat
{
    /// <summary>
    ///     Parser for chat ack
    /// </summary>
    [ParserSend]
    public class EmoticonAck
    {
        [ParserAction(Core.Enums.PacketType.EmoticonAck)]
        public byte[] Parsing(EmoticonAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.Type);
            model.SessionGameId.Write(formationPackage);
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.Name, 15));

            return formationPackage.GetBytes();
        }
    }
}