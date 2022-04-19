using Packets.Server.Game.Models.Receive.Chat;
using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Core.Enums;

namespace Packets.Server.Game.Parsers.Receive.Chat
{
    /// <summary>
    ///     Parser emoji req
    /// </summary>
    [ParserReceive]
    public class EmoticonReq
    {
        [ParserAction(PacketType.EmoticonReq)]
        public EmoticonReqModel Parsing(byte[] data)
        {
            EmoticonReqModel emoticonReqModel = new EmoticonReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            emoticonReqModel.Type = formationPackage.ReadInteger();

            return emoticonReqModel;
        }
    }
}