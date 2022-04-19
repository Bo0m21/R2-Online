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
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            var connections = _identificationService.GetAllConnections().Where(c => c.Pc != null && c.Pc.checkAttack);
            //            foreach (var conection in connections)
            //            {

            //                // Attack character to unit

            //                // Define attacker character and defender unit
            //                var attacker = conection;
            //                var defender = _identificationService.GetUnitByUniqueIdentifier(conection.Pc.TargetUniqueId);

            //                if (attacker.IsConnected == true && defender != null && attacker.Pc.AttackedUniqueIdentifier != null && attacker.Pc.AttackDateTime < DateTime.Now)
            //                {
            //                    // Check dead attacker and defender
            //                    if (attacker.Pc.DeadTime != null || defender.DeadTime != null)
            //                    {
            //                        attacker.Pc.AttackedUniqueIdentifier = null;
            //                        break;
            //                    }

            //                    // Check is visible unit
            //                    if (attacker.Pc.VisibleUnitGames.FirstOrDefault(c => c == defender) == null)
            //                    {
            //                        attacker.Pc.AttackedUniqueIdentifier = null;
            //                        break;
            //                    }

            //                    // Check attack distance
            //                    if (attacker.Pc.CurrentPosition.Distance(defender.Position) > attacker.Pc.DistanceAttack)
            //                    {
            //                        attacker.Pc.AttackedUniqueIdentifier = null;
            //                        break;
            //                    }

            //                    var typeHit = _attackSystem.AttackCharacterToUnit(attacker.Pc, defender);

            //                    _attackFactory.SendAttacked(attacker, attacker.Pc.UniqueIdentifier, defender.UniqueIdentifier, typeHit, attacker.Pc.CurrentPosition, defender.Hp);

            //                    foreach (GameSession visible in attacker.Pc.VisibleCharacterGames)
            //                    {
            //                        _attackFactory.SendAttacked(visible, attacker.Pc.UniqueIdentifier, defender.UniqueIdentifier, typeHit, attacker.Pc.CurrentPosition, defender.Hp);
            //                    }

            //                    // Check hp and dead
            //                    if (defender.Hp <= 0)
            //                    {
            //                        defender.Hp = 0;
            //                        defender.DeadTime = DateTime.Now;

            //                        _attackFactory.SendDeadAttack(attacker, attacker.Pc.UniqueIdentifier, defender.UniqueIdentifier, attacker.Pc.Reputation, ChaoticStatusType.Normal);

            //                        foreach (GameSession visible in attacker.Pc.VisibleCharacterGames)
            //                        {
            //                            _attackFactory.SendDeadAttack(visible, attacker.Pc.UniqueIdentifier, defender.UniqueIdentifier, attacker.Pc.Reputation, ChaoticStatusType.Normal);
            //                        }

            //                        attacker.Pc.AttackedUniqueIdentifier = null;
            //                        defender.AttackedUniqueIdentifier = null;

            //                        // Check level or update
            //                        _expSystem.KillUnit(attacker, defender);

            //                        // Send drop from unit
            //                        _unitDropSystem.SendUnitDrop(defender);
            //                    }
            //                    else
            //                    {
            //                        // Nothing
            //                    }

            //                    // Check dead attacker and defender
            //                    if (attacker.Pc.DeadTime != null || defender.DeadTime != null)
            //                    {
            //                        conection.Pc.checkAttack = false;
            //                        attacker.Pc.AttackedUniqueIdentifier = null;
            //                        _attackFactory.SendEndAttack(conection, attacker.Pc.UniqueIdentifier);

            //                        foreach (GameSession visible in attacker.Pc.VisibleCharacterGames)
            //                        {
            //                            _attackFactory.SendEndAttack(visible, attacker.Pc.UniqueIdentifier);
            //                        }
            //                        break;
            //                    }

            //                    //Thread.Sleep(attacker.CharacterGame.AttackRate);
            //                    attacker.Pc.AttackDateTime = DateTime.Now.AddMilliseconds(attacker.Pc.AttackRate);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //        }

            //        Thread.Sleep(1);
            //    }
            //});

        }

    }
}
