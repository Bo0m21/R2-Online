using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Npc;

namespace Packets.Server.Game.Parsers.Receive.Npc
{
    /// <summary>
    ///     Parser chat req
    /// </summary>
    [ParserReceive]
    public class ChatReq
    {
        [ParserAction(PacketType.ScriptReq)]
        public ScriptReqModel Parsing(byte[] data)
        {
            ScriptReqModel scriptReqModel = new ScriptReqModel();

            FormationPackage formationPackage = new FormationPackage(data);

            scriptReqModel.UniqueIdentifier.Read(formationPackage);
            scriptReqModel.Param = formationPackage.ReadInteger();
            formationPackage.ReadBytes(101);

            return scriptReqModel;
        }
    }
}