using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Character;

namespace Packets.Server.Game.Parsers.Receive.Character
{
    /// <summary>
    ///     Parser for delete pc
    /// </summary>
    [ParserReceive]
    public class DeletePcReq
    {
        [ParserAction(PacketType.DeletePcReq)]
        public DeletePcReqModel Parsing(byte[] data)
        {
            DeletePcReqModel deletePcReqModel = new DeletePcReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            deletePcReqModel.PcNo = formationPackage.ReadUInteger();
            deletePcReqModel.Slot = formationPackage.ReadByte();

            return deletePcReqModel;
        }
    }
}