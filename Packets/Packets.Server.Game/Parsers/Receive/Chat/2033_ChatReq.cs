using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Chat;

namespace Packets.Server.Game.Parsers.Receive.Chat
{
    /// <summary>
    ///     Parser chat req
    /// </summary>
    [ParserReceive]
    public class ChatReq
    {
        [ParserAction(PacketType.ChatReq)]
        public ChatReqModel Parsing(byte[] data)
        {
            ChatReqModel chatReqModel = new ChatReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            chatReqModel.Type = formationPackage.ReadByte();
            chatReqModel.Message = FormationPackageUtility.GetText(formationPackage.ReadBytes(101), 0);
            chatReqModel.Name = FormationPackageUtility.GetText(formationPackage.ReadBytes(15), 0);

            return chatReqModel;
        }
    }
}