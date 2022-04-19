using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Chat;

namespace Packets.Server.Game.Parsers.Send.Chat
{
    /// <summary>
    ///     Parser for global chat ack
    /// </summary>
    [ParserSend]
    public class GlobalChatAck
    {
        [ParserAction(Core.Enums.PacketType.GlobalChatAck)]
        public byte[] Parsing(GlobalChatAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            formationPackage.AddZeroBytes(8);
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.Name, 15));
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.Message, 101));

            return formationPackage.GetBytes();
        }
    }
}