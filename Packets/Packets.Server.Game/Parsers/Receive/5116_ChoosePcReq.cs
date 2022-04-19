using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive;

namespace Packets.Server.Game.Parsers.Receive
{
    /// <summary>
    ///     Parser for choose pc req
    /// </summary>
    [ParserReceive]
    public class ChoosePcReq
    {
        [ParserAction(PacketType.ChoosePcReq)]
        public ChoosePcReqModel Parsing(byte[] data)
        {
            ChoosePcReqModel choosePcReqModel = new ChoosePcReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            choosePcReqModel.PcNo = formationPackage.ReadUInteger();

            return choosePcReqModel;
        }
    }
}