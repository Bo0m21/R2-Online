using Packets.Server.Game.Models.Send.Attack;
using Packets.Server.Game.Structures;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IAttackFactory
    {
        void SendAttacked(GameSession client, UniqueId offenceId, UniqueId defenseId, TypeHit typeHit, Vector3 position, short hpAttacked);
        
        void SendEndAttack(GameSession client, UniqueId offenceId);

        void SendDeadAttack(GameSession client, UniqueId offenceId, UniqueId defenseId, int chaotic, ChaoticStatusType chaoticStatus);
    }
}
