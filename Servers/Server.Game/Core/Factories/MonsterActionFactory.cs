using Packets.Server.Game.Models.Send.MonsterNpc;
using Packets.Server.Game.Structures;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class MonsterActionFactory : IMonsterActionFactory
    {
        public void SendMoveToPoint(GameSession clientTo, UniqueId SessionGameId, Vector3 Position, Vector3 PointPosition, byte Flag, float Velocity)
        {
            DoMoveToAckModel movedCharactersModel = new DoMoveToAckModel
            {
                SessionGameId = SessionGameId,
                Position = Position,
                PointPosition = PointPosition,
                Flag = Flag,
                Velocity = Velocity
            };

            clientTo.Send(movedCharactersModel);
        }
    }
}
