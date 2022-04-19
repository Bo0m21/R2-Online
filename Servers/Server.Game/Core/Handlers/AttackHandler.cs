using Packets.Server.Game.Models.Receive.Attack;
using Packets.Server.Game.Models.Send.Attack;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Packets.Server.Game.Structures;
using Packets.Server.Game.Enums;
using Server.Game.Core.Systems;
using Packets.Core.Attributes;
using System.Threading.Tasks;
using Server.Game.Services;
using Server.Game.Network;
using Packets.Core.Enums;
using System.Threading;
using System.Linq;
using System;
using Database.DataModel.Enums;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class AttackHandler : IAttackHandler
    {
        private readonly IAttackFactory _attackFactory;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly AttackSystem _attackSystem;
        private readonly IdentificationService _identificationService;
        private readonly IMonsterActionFactory _monsterActionFactory;
        private readonly ExpSystem _expSystem;
        private readonly IVisibleFactory _visibleFactory;
        private readonly UnitDropSystem _unitDropSystem;
        

        public AttackHandler(UnitDropSystem unitDropSystem, IVisibleFactory visibleFactory, ExpSystem expSystem, IMonsterActionFactory monsterActionFactory, AttackSystem attackSystem, IdentificationService identificationService, IAttackFactory attackFactory, ICharacteristicFactory characteristicFactory)
        {
            _attackSystem = attackSystem;
            _identificationService = identificationService;
            _attackFactory = attackFactory;
            _characteristicFactory = characteristicFactory;
            _monsterActionFactory = monsterActionFactory;
            _expSystem = expSystem;
            _visibleFactory = visibleFactory;
            _unitDropSystem = unitDropSystem;
        }

        [HandlerAction(PacketType.AttackReq)]
        public void BeginAttack(GameSession client, AttackReqModel model)
        {
            //if (client.CharacterGame.AttackedUniqueIdentifier != null)
            //{
                return;
            //}

            //var checkConnectionOrUnit = _identificationService.CheckConnectionOrUnitByUniqueIdentifier(model.TargetSessionGameId);

            //if (checkConnectionOrUnit == false)
            //{
            //    return;
            //}

            //client.CharacterGame.TargetUniqueId = model.TargetSessionGameId;
            //client.CharacterGame.AttackType = model.AttackType;
            //client.CharacterGame.AttackPosition = model.AttackPosition;
            //client.CharacterGame.AttackFlag = model.AttackFlag;

            
            //client.CharacterGame.AttackedUniqueIdentifier = model.TargetSessionGameId;
            //client.CharacterGame.checkAttack = true;

            //if (model.TargetSessionGameId.Class == (uint)UniqueIdentifierType.Player)
            //{
            //    // Attack character to character
            //    Task.Run(() =>
            //    {
            //        // Define attacker character and defender character
            //        var attacker = client;
            //        var defender = _identificationService.GetConnectionByUniqueIdentifier(attacker.CharacterGame.AttackedUniqueIdentifier);

            //        while (attacker.IsConnected == true && defender.IsConnected == true && attacker.CharacterGame.AttackedUniqueIdentifier != null)
            //        {
            //            // Check is visible connection
            //            if (attacker.CharacterGame.VisibleCharacterGames.FirstOrDefault(c => c == defender) == null)
            //            {
            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            // Check attack distance
            //            if (attacker.CharacterGame.CurrentPosition.Distance(defender.CharacterGame.CurrentPosition) > attacker.CharacterGame.DistanceAttack)
            //            {
            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            var typeHit = _attackSystem.AttackCharacterToCharacter(attacker.CharacterGame, defender.CharacterGame);

            //            _attackFactory.SendAttacked(client, attacker.CharacterGame.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, typeHit, attacker.CharacterGame.CurrentPosition, -1);

            //            foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
            //            {
            //                _attackFactory.SendAttacked(visible, attacker.CharacterGame.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, typeHit, attacker.CharacterGame.CurrentPosition, -1);
            //            }

            //            // Check hp and dead
            //            if (defender.CharacterGame.Hp <= 0)
            //            {
            //                defender.CharacterGame.Hp = 0;
            //                defender.CharacterGame.DeadTime = DateTime.Now;

            //                _characteristicFactory.SendHealthPointCharacteristics(defender);


            //                _attackFactory.SendDeadAttack(client, attacker.CharacterGame.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, attacker.CharacterGame.Reputation, ChaoticStatusType.Normal);

            //                foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
            //                {
            //                    _attackFactory.SendDeadAttack(visible, attacker.CharacterGame.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, attacker.CharacterGame.Reputation, ChaoticStatusType.Normal);
            //                }

            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                defender.CharacterGame.AttackedUniqueIdentifier = null;

            //                // TODO Вычитаем репутацию - 3000
            //            }
            //            else
            //            {
            //                _characteristicFactory.SendHealthPointCharacteristics(defender);
            //            }

            //            // Check dead attacker and defender
            //            if (attacker.CharacterGame.DeadTime != null || defender.CharacterGame.DeadTime != null)
            //            {
            //                break;
            //            }

            //            Thread.Sleep(attacker.CharacterGame.AttackRate);
            //        }

            //        _attackFactory.SendEndAttack(client, attacker.CharacterGame.UniqueIdentifier);

            //        foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
            //        {
            //            _attackFactory.SendEndAttack(visible, attacker.CharacterGame.UniqueIdentifier);
            //        }
            //    });
            //}
            //else if (model.TargetSessionGameId.Class == (uint)UniqueIdentifierType.Npc || model.TargetSessionGameId.Class == (uint)UniqueIdentifierType.Monster)
            //{
            //    // Attack character to unit
            //    Task.Run(() =>
            //    {
            //        // Define attacker character and defender unit
            //        var attacker = client;
            //        var defender = _identificationService.GetUnitByUniqueIdentifier(model.TargetSessionGameId);

            //        while (attacker.IsConnected == true && defender != null && attacker.CharacterGame.AttackedUniqueIdentifier != null)
            //        {
            //            // Check dead attacker and defender
            //            if (attacker.CharacterGame.DeadTime != null || defender.DeadTime != null)
            //            {
            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            // Check is visible unit
            //            if (attacker.CharacterGame.VisibleUnitGames.FirstOrDefault(c => c == defender) == null)
            //            {
            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            // Check attack distance
            //            if (attacker.CharacterGame.CurrentPosition.Distance(defender.Position) > attacker.CharacterGame.DistanceAttack)
            //            {
            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            var typeHit = _attackSystem.AttackCharacterToUnit(attacker.CharacterGame, defender);

            //            _attackFactory.SendAttacked(client, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, typeHit, attacker.CharacterGame.CurrentPosition, defender.Hp);

            //            foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
            //            {
            //                _attackFactory.SendAttacked(visible, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, typeHit, attacker.CharacterGame.CurrentPosition, defender.Hp);
            //            }

            //            // Check hp and dead
            //            if (defender.Hp <= 0)
            //            {
            //                defender.Hp = 0;
            //                defender.DeadTime = DateTime.Now;

            //                _attackFactory.SendDeadAttack(client, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, attacker.CharacterGame.Reputation, ChaoticStatusType.Normal);

            //                foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
            //                {
            //                    _attackFactory.SendDeadAttack(visible, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, attacker.CharacterGame.Reputation, ChaoticStatusType.Normal);
            //                }

            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                defender.AttackedUniqueIdentifier = null;

            //                // Check level or update
            //                _expSystem.KillUnit(attacker, defender);

            //                // Send drop from unit
            //                _unitDropSystem.SendUnitDrop(defender);
            //            }
            //            else
            //            {
            //                // Nothing
            //            }

            //            // Check dead attacker and defender
            //            if (attacker.CharacterGame.DeadTime != null || defender.DeadTime != null)
            //            {
            //                attacker.CharacterGame.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            Thread.Sleep(attacker.CharacterGame.AttackRate);
            //        }

            //        _attackFactory.SendEndAttack(client, attacker.CharacterGame.UniqueIdentifier);

            //        foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
            //        {
            //            _attackFactory.SendEndAttack(visible, attacker.CharacterGame.UniqueIdentifier);
            //        }
            //    });

            //    // Attack unit to character
            //    Task.Run(() =>
            //    {
            //        // Define attacker unit and defender character
            //        var attacker = _identificationService.GetUnitByUniqueIdentifier(model.TargetSessionGameId);
            //        var defender = client;
            //        if (attacker.Type == UnitTypeEnum.Npc)
            //        {
            //            return;
            //        }
            //        if (attacker.AttackedUniqueIdentifier != null)
            //        {
            //            return;
            //        }

            //        attacker.AttackedUniqueIdentifier = client.CharacterGame.UniqueIdentifier;

            //        while (attacker != null && defender.IsConnected == true && attacker.AttackedUniqueIdentifier != null)
            //        {
            //            // Check dead attacker and defender
            //            if (attacker.DeadTime != null || defender.CharacterGame.DeadTime != null)
            //            {
            //                attacker.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            // Check is visible connection
            //            if (attacker.VisibleCharacterGames.FirstOrDefault(c => c == defender) == null)
            //            {
            //                attacker.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            // Check distance move
            //            if (attacker.Position.Distance(attacker.PositionDefault) > attacker.MoveRange)
            //            {
            //                // Teleport to default position
            //                foreach (var visibleCharacter in attacker.VisibleCharacterGames)
            //                {
            //                    _visibleFactory.SendExitMap(visibleCharacter, attacker.UniqueIdentifier, ExitMapWhy.Teleport);
            //                }

            //                // Set default position
            //                attacker.DirectionSight = attacker.DirectionSight;
            //                attacker.Position = new Vector3(attacker.PositionDefault.X, attacker.PositionDefault.Y, attacker.PositionDefault.Z);

            //                attacker.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            // Check attack distance
            //            if (attacker.Position.Distance(defender.CharacterGame.CurrentPosition) > attacker.AttackRange)
            //            {
            //                int movingTime = 1000;

            //                // Get a Vector between object A and B
            //                double _nx = defender.CharacterGame.CurrentPosition.X - attacker.Position.X;
            //                double _ny = defender.CharacterGame.CurrentPosition.Y - attacker.Position.Y;
            //                double _nz = defender.CharacterGame.CurrentPosition.Z - attacker.Position.Z;

            //                // Get distance
            //                double _distance = Math.Sqrt((_nx * _nx) + (_ny * _ny) + (_nz * _nz));

            //                // Get speed
            //                double speed = attacker.MoveRateOrg;

            //                // Check distance attack and speed
            //                if (_distance - attacker.AttackRange <= speed)
            //                {
            //                    speed = _distance - attacker.AttackRange;

            //                    if (speed < 1)
            //                    {
            //                        speed = _distance - attacker.AttackRange + (attacker.AttackRange / 100 * 25);
            //                    }
            //                }

            //                // Normalize vector (make it length of 1.0)
            //                double _vx = _nx / _distance;
            //                double _vy = _ny / _distance;
            //                double _vz = _nz / _distance;

            //                // Move object based on vector and speed
            //                float newX = (float)_vx * (float)speed;
            //                float newY = (float)_vy * (float)speed;
            //                float newZ = (float)_vz * (float)speed;

            //                // Change moving time if speed
            //                movingTime = (int)(1000 / attacker.MoveRateOrg * speed);

            //                // Create new positions and send
            //                var newPosition = new Vector3(attacker.Position.X + newX, attacker.Position.Y + newY, attacker.Position.Z + newZ);
            //                _monsterActionFactory.SendMoveToPoint(client, attacker.UniqueIdentifier, attacker.Position, newPosition, 1, attacker.MoveRateOrg); // TODO flag 1

            //                // Install new position and wait
            //                attacker.Position = newPosition;
            //                Thread.Sleep(movingTime);

            //                continue;
            //            }

            //            var typeHit = _attackSystem.AttackUnitToCharacter(attacker, defender.CharacterGame);

            //            _attackFactory.SendAttacked(client, attacker.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, typeHit, attacker.Position, -1);

            //            foreach (GameSession visible in attacker.VisibleCharacterGames)
            //            {
            //                _attackFactory.SendAttacked(visible, attacker.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, typeHit, attacker.Position, -1);
            //            }

            //            // Check hp and dead
            //            if (defender.CharacterGame.Hp <= 0)
            //            {
            //                defender.CharacterGame.Hp = 0;
            //                defender.CharacterGame.DeadTime = DateTime.Now;

            //                _characteristicFactory.SendHealthPointCharacteristics(defender);

            //                // TODO Оставляем репутацию
            //                // TODO Отнимаем 2 процента

            //                _attackFactory.SendDeadAttack(client, attacker.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, 0, ChaoticStatusType.Normal);

            //                foreach (GameSession visible in attacker.VisibleCharacterGames)
            //                {
            //                    _attackFactory.SendDeadAttack(visible, attacker.UniqueIdentifier, defender.CharacterGame.UniqueIdentifier, 0, ChaoticStatusType.Normal);
            //                }

            //                attacker.AttackedUniqueIdentifier = null;
            //                defender.CharacterGame.AttackedUniqueIdentifier = null;

            //                // Check level or update
            //                _expSystem.KillConnection(attacker, defender);
            //            }
            //            else
            //            {
            //                _characteristicFactory.SendHealthPointCharacteristics(defender);
            //            }

            //            // Check dead attacker and defender
            //            if (attacker.DeadTime != null || defender.CharacterGame.DeadTime != null)
            //            {
            //                attacker.AttackedUniqueIdentifier = null;
            //                break;
            //            }

            //            Thread.Sleep(attacker.AttackRateOrg);
            //        }

            //        foreach (GameSession visible in attacker.VisibleCharacterGames)
            //        {
            //            _attackFactory.SendEndAttack(visible, attacker.UniqueIdentifier);
            //        }
            //    });
            //}
        }
    }
}
