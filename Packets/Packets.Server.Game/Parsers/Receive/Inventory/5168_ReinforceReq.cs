using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Inventory;

namespace Packets.Server.Game.Parsers.Receive.Inventory
{
    /// <summary>
    ///     Parser for reinforce req
    /// </summary>
    [ParserReceive]
    public class ReinforceReq
    {
        [ParserAction(PacketType.ReinforceReq)]
        public ReinforceReqModel Parsing(byte[] data)
        {
            ReinforceReqModel reinforceReqModel = new ReinforceReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            reinforceReqModel.SerialNumber = formationPackage.ReadULong();
            reinforceReqModel.SerialNumber0 = formationPackage.ReadULong();
            reinforceReqModel.SerialNumber1 = formationPackage.ReadULong();
            reinforceReqModel.SerialNumber2 = formationPackage.ReadULong();
            reinforceReqModel.Count = formationPackage.ReadInteger();

            return reinforceReqModel;
        }
    }
}
