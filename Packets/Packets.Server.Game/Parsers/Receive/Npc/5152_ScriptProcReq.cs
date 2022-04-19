using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Receive.Npc;

namespace Packets.Server.Game.Parsers.Receive.Npc
{
    /// <summary>
    ///     Parser chat req
    /// </summary>
    [ParserReceive]
    public class ScriptProcReq
    {
        [ParserAction(PacketType.ScriptProcReq)]
        public ScriptProcReqModel Parsing(byte[] data)
        {
            ScriptProcReqModel scriptProcReqModel = new ScriptProcReqModel();

            FormationPackage formationPackage = new FormationPackage(data);

            scriptProcReqModel.UniqueIdentifier.Read(formationPackage);
            scriptProcReqModel.ScriptAction = (ScriptAction)formationPackage.ReadInteger();
            scriptProcReqModel.Param = formationPackage.ReadInteger();
            formationPackage.ReadBytes(101);

            return scriptProcReqModel;
        }
    }
}