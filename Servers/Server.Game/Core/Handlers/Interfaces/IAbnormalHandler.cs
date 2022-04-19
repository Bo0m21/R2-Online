using Packets.Server.Game.Models.Receive.Action;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IAbnormalHandler
    {
        void AbnormalRemove(GameSession client, AbnormalRemoveReqModel model);
    }
}