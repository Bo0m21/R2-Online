using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Action;

namespace Packets.Server.Game.Parsers.Receive.Attack
{
    /// <summary>
    ///     Parser for attack req
    /// </summary>
    [ParserReceive]
    public class AbnormalCancelReq
    {
        [ParserAction(PacketType.AbnormalRemoveReq)]
        public AbnormalRemoveReqModel Parsing(byte[] data)
        {
            AbnormalRemoveReqModel abnormalCancelReqModel = new AbnormalRemoveReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            abnormalCancelReqModel.Type = formationPackage.ReadInteger();

            return abnormalCancelReqModel;
        }
    }
}