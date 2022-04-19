using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Npc;

namespace Packets.Server.Game.Parsers.Send.Npc
{
    /// <summary>
    ///     Parser for merchant list ack
    /// </summary>
    [ParserSend]
    public class MerchantListAck
    {
        [ParserAction(PacketType.MerchantListAck)]
        public byte[] Parsing(MerchantListAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.UniqueIdentifier.Write(formationPackage);
            formationPackage.AddInteger(model.MerchantId);
            formationPackage.AddInteger(model.ParmA);
            formationPackage.AddInteger(model.ParmB);
            formationPackage.AddInteger(model.CountBuy);
            formationPackage.AddInteger(model.CountSell);
            formationPackage.AddInteger(model.CountCharge);
            formationPackage.AddInteger((int)model.PaymentType);

            foreach(var item in model.ItemList)
            {
                formationPackage.AddInteger(item.ItemId);
                formationPackage.AddInteger(item.Price);
                formationPackage.AddInteger(item.Flag);
                formationPackage.AddInteger(item.SortKey);
            }

            return formationPackage.GetBytes();
        }
    }
}
