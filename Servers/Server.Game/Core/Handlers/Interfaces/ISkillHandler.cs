using Packets.Server.Game.Models.Receive.Action;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface ISkillHandler
    {
        void SkillPackReq(GameSession client, UseSkillPackReqModel model);
    }
}
