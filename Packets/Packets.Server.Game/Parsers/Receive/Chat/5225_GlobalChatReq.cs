using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Chat;

namespace Packets.Server.Game.Parsers.Receive.Chat
{
    /// <summary>
    ///     Parser global chat req
    /// </summary>
    [ParserReceive]
    public class GlobalChatReq
    {
        [ParserAction(PacketType.GlobalChatReq)]
        public GlobalChatReqModel Parsing(byte[] data)
        {
            GlobalChatReqModel globalchatReqModel = new GlobalChatReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            globalchatReqModel.Message = FormationPackageUtility.GetText(formationPackage.ReadBytes(101), 0);

            return globalchatReqModel;
        }
    }
}