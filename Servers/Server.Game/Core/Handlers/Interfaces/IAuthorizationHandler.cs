using Packets.Server.Game.Models.Receive;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IAuthorizationHandler
    {
        void Authorization(GameSession client, LoginUserReqModel model);

        void EnterWorld(GameSession client, ChoosePcReqModel model);
    }
}