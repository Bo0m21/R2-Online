using Packets.Server.Game.Models.Receive.Npc;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface INpcActionHandler
    {
        void Script(GameSession client, ScriptReqModel model);
        void ScriptProc(GameSession client, ScriptProcReqModel model);
        void MerchantBuy(GameSession client, MerchantBuyReqModel model);

    }
}
