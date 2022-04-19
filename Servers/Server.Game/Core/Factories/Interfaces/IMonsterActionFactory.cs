using Packets.Server.Game.Structures;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IMonsterActionFactory
    {
        void SendMoveToPoint(GameSession clientTo, UniqueIdentifier SessionGameId, Vector3 Position, Vector3 PointPosition, byte Flag, float Velocity);
    }
}
