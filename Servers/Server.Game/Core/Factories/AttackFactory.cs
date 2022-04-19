using Packets.Server.Game.Models.Send.Attack;
using Packets.Server.Game.Structures;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class AttackFactory : IAttackFactory
    {
        public void SendAttacked(GameSession client, UniqueId offenceId, UniqueId defenseId, TypeHit typeHit, Vector3 position, short hpAttacked)
        {
            AttackAckModel attackModel = new AttackAckModel
            {
                OffenseSessionGameId = offenceId,
                DefenseSessionGameId = defenseId,
                TypeHit = typeHit,
                OffensePosition = position,
                HpAttacked = hpAttacked
            };

            client.Send(attackModel);
        }

        public void SendEndAttack(GameSession client, UniqueId offenceId)
        {
            AttackStopAckModel endAttackModel = new AttackStopAckModel
            {
                OffenceSesionGameId = offenceId
            };

            client.Send(endAttackModel);
        }

        public void SendDeadAttack(GameSession client, UniqueId offenceId, UniqueId defenseId, int chaotic, ChaoticStatusType chaoticStatus)
        {
            DeadAckModel deadAckModel = new DeadAckModel
            {
                OffenseSessionGameId = offenceId,
                DefenseSessionGameId = defenseId,
                Chaotic = chaotic,
                ChaoticStatus = chaoticStatus,
            };

            client.Send(deadAckModel);
        }
    }
}
