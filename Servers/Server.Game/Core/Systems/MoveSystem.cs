using Server.Game.Core.Factories.Interfaces;

namespace Server.Game.Core.Systems
{
    public class MoveSystem
    {
        private readonly IMonsterActionFactory _monsterActionFactory;

        public MoveSystem(IMonsterActionFactory monsterActionFactory)
        {
            _monsterActionFactory = monsterActionFactory;
        }

        public void MoveUnit()
        {
            //int movingTime = 1000;

            //// Get a Vector between object A and B
            //double _nx = defender.CharacterGame.Position.X - attacker.Position.X;
            //double _ny = defender.CharacterGame.Position.Y - attacker.Position.Y;
            //double _nz = defender.CharacterGame.Position.Z - attacker.Position.Z;

            //// Get distance
            //double _distance = Math.Sqrt((_nx * _nx) + (_ny * _ny) + (_nz * _nz));

            //// Get speed
            //double speed = attacker.MoveRate;

            //// Check distance attack and speed
            //if (_distance - attacker.DistanceAttack <= speed)
            //{
            //    speed = _distance - attacker.DistanceAttack;

            //    if (speed < 1)
            //    {
            //        speed = _distance - attacker.DistanceAttack + (attacker.DistanceAttack / 100 * 25);
            //    }
            //}

            //// Normalize vector (make it length of 1.0)
            //double _vx = _nx / _distance;
            //double _vy = _ny / _distance;
            //double _vz = _nz / _distance;

            //// Move object based on vector and speed
            //float newX = (float)_vx * (float)speed;
            //float newY = (float)_vy * (float)speed;
            //float newZ = (float)_vz * (float)speed;

            //// Change moving time if speed
            //movingTime = (int)(1000 / attacker.MoveRate * speed);

            //// Create new positions and send
            //var newPosition = new Vector3(attacker.Position.X + newX, attacker.Position.Y + newY, attacker.Position.Z + newZ);
            //_monsterActionFactory.SendMoveToPoint(client, attacker.UniqueIdentifier, attacker.Position, newPosition, 1, attacker.MoveRate); // TODO flag 1

            //// Install new position and wait
            //attacker.Position = newPosition;
            //Thread.Sleep(movingTime);
        }
    }
}
