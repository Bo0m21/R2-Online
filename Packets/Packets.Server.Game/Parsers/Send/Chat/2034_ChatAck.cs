using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Chat;

namespace Packets.Server.Game.Parsers.Send.Chat
{
    /// <summary>
    ///     Parser for chat ack
    /// </summary>
    [ParserSend]
    public class ChatAck
    {
        [ParserAction(Core.Enums.PacketType.ChatAck)]
        public byte[] Parsing(ChatAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddByte(model.Type);
            model.SessionGameId.Write(formationPackage);
            formationPackage.AddZeroBytes(14);
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.Name, 15));
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.Message, 101));

            return formationPackage.GetBytes();
        }
    }
}