using Packets.Server.Game.Models.Send.Attack;
using Packets.Server.Game.Structures;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IAttackFactory
    {
        void SendAttacked(GameSession client, UniqueIdentifier offenceId, UniqueIdentifier defenseId, TypeHit typeHit, Vector3 position, short hpAttacked);
        
        void SendEndAttack(GameSession client, UniqueIdentifier offenceId);

        void SendDeadAttack(GameSession client, UniqueIdentifier offenceId, UniqueIdentifier defenseId, int chaotic, ChaoticStatusType chaoticStatus);
    }
}
