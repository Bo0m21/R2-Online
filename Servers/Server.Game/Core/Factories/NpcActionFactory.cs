using Packets.Server.Game.Models.Send.Npc;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class NpcActionFactory : INpcActionFactory
    {
        public void SendDialog(GameSession clientTo, ScrDialogNoMsg2AckModel model)
        {
            ScrDialogNoMsg2AckModel scrDialogNoMsg2AckModel = new ScrDialogNoMsg2AckModel
            {
                ScriptId = model.ScriptId,
                UniqueIdentifier = model.UniqueIdentifier,
                Param = model.Param
            };

            clientTo.Send(scrDialogNoMsg2AckModel);
        }
        public void SendMerchantList(GameSession clientTo, MerchantListAckModel model)
        {
            MerchantListAckModel merchantListAckModel = new MerchantListAckModel
            {
                UniqueIdentifier = model.UniqueIdentifier,
                MerchantId = model.MerchantId,
                ParmA = model.ParmA,
                ParmB = model.ParmB,
                CountBuy = model.CountBuy,
                CountSell = model.CountSell,
                CountCharge = model.CountCharge,
                PaymentType = model.PaymentType,
                ItemList = model.ItemList
            };

            clientTo.Send(merchantListAckModel);
        }
    }
}
