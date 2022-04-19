using Microsoft.Extensions.Hosting;
using Packets.Server.Game.Models.Send.Attack;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Network;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.Game
{
    public class AttackGameService : IHostedService
    {


        private readonly IAttackFactory _attackFactory;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly AttackSystem _attackSystem;
        private readonly IdentificationService _identificationService;
        private readonly IMonsterActionFactory _monsterActionFactory;
        private readonly ExpSystem _expSystem;
        private readonly IVisibleFactory _visibleFactory;
        private readonly UnitDropSystem _unitDropSystem;


        public AttackGameService(UnitDropSystem unitDropSystem, IVisibleFactory visibleFactory, ExpSystem expSystem, IMonsterActionFactory monsterActionFactory, AttackSystem attackSystem, IdentificationService identificationService, IAttackFactory attackFactory, ICharacteristicFactory characteristicFactory)
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


        public Task StartAsync(CancellationToken cancellationToken)
        {
            BeginAttack();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        private void BeginAttack()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var connections = _identificationService.GetAllConnections().Where(c => c.CharacterGame != null && c.CharacterGame.checkAttack);
                        foreach (var conection in connections)
                        {

                            // Attack character to unit

                            // Define attacker character and defender unit
                            var attacker = conection;
                            var defender = _identificationService.GetUnitByUniqueIdentifier(conection.CharacterGame.TargetSessionGameId);

                            if (attacker.IsConnected == true && defender != null && attacker.CharacterGame.AttackedUniqueIdentifier != null && attacker.CharacterGame.AttackDateTime < DateTime.Now)
                            {
                                // Check dead attacker and defender
                                if (attacker.CharacterGame.DeadTime != null || defender.DeadTime != null)
                                {
                                    attacker.CharacterGame.AttackedUniqueIdentifier = null;
                                    break;
                                }

                                // Check is visible unit
                                if (attacker.CharacterGame.VisibleUnitGames.FirstOrDefault(c => c == defender) == null)
                                {
                                    attacker.CharacterGame.AttackedUniqueIdentifier = null;
                                    break;
                                }

                                // Check attack distance
                                if (attacker.CharacterGame.Position.Distance(defender.Position) > attacker.CharacterGame.DistanceAttack)
                                {
                                    attacker.CharacterGame.AttackedUniqueIdentifier = null;
                                    break;
                                }

                                var typeHit = _attackSystem.AttackCharacterToUnit(attacker.CharacterGame, defender);

                                _attackFactory.SendAttacked(attacker, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, typeHit, attacker.CharacterGame.Position, defender.Hp);

                                foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
                                {
                                    _attackFactory.SendAttacked(visible, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, typeHit, attacker.CharacterGame.Position, defender.Hp);
                                }

                                // Check hp and dead
                                if (defender.Hp <= 0)
                                {
                                    defender.Hp = 0;
                                    defender.DeadTime = DateTime.Now;

                                    _attackFactory.SendDeadAttack(attacker, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, attacker.CharacterGame.Reputation, ChaoticStatusType.Normal);

                                    foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
                                    {
                                        _attackFactory.SendDeadAttack(visible, attacker.CharacterGame.UniqueIdentifier, defender.UniqueIdentifier, attacker.CharacterGame.Reputation, ChaoticStatusType.Normal);
                                    }

                                    attacker.CharacterGame.AttackedUniqueIdentifier = null;
                                    defender.AttackedUniqueIdentifier = null;

                                    // Check level or update
                                    _expSystem.KillUnit(attacker, defender);

                                    // Send drop from unit
                                    _unitDropSystem.SendUnitDrop(defender);
                                }
                                else
                                {
                                    // Nothing
                                }

                                // Check dead attacker and defender
                                if (attacker.CharacterGame.DeadTime != null || defender.DeadTime != null)
                                {
                                    conection.CharacterGame.checkAttack = false;
                                    attacker.CharacterGame.AttackedUniqueIdentifier = null;
                                    _attackFactory.SendEndAttack(conection, attacker.CharacterGame.UniqueIdentifier);

                                    foreach (GameSession visible in attacker.CharacterGame.VisibleCharacterGames)
                                    {
                                        _attackFactory.SendEndAttack(visible, attacker.CharacterGame.UniqueIdentifier);
                                    }
                                    break;
                                }

                                //Thread.Sleep(attacker.CharacterGame.AttackRate);
                                attacker.CharacterGame.AttackDateTime = DateTime.Now.AddMilliseconds(attacker.CharacterGame.AttackRate);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(1);
                }
            });

        }

    }
}
