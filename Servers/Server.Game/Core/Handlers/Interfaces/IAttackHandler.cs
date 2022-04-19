using Packets.Server.Game.Models.Receive.Attack;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface IAttackHandler
    {
        void BeginAttack(GameSession client, AttackReqModel model);
    }
}
