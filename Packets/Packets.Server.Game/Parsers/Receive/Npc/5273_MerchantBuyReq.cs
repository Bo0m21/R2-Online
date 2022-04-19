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
    public class MerchantBuyReq
    {
        [ParserAction(PacketType.MerchantBuyReq)]
        public MerchantBuyReqModel Parsing(byte[] data)
        {
            MerchantBuyReqModel merchantBuyReqModel = new MerchantBuyReqModel();

            FormationPackage formationPackage = new FormationPackage(data);

            merchantBuyReqModel.UniqueIdentifier.Read(formationPackage);
            merchantBuyReqModel.ItemId = formationPackage.ReadInteger();
            merchantBuyReqModel.Count = formationPackage.ReadInteger();
            merchantBuyReqModel.ParmA = formationPackage.ReadInteger();
            merchantBuyReqModel.ParmB = formationPackage.ReadInteger();
            merchantBuyReqModel.SortKey = formationPackage.ReadInteger();
            formationPackage.ReadBytes(28);

            return merchantBuyReqModel;
        }
    }
}