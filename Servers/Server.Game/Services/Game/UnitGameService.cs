using Microsoft.Extensions.Hosting;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Services.Database;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.GameServices
{
    /// <summary>
    ///     Unit game service 
    /// </summary>
    public class UnitGameService : IHostedService
    {
        private readonly UnitSystem _unitSystem;
        private readonly ParmRepository _databaseBalanceService;
        private readonly IdentificationService _identificationService;

        private readonly List<GMonster> _monsters;

        public UnitGameService(UnitSystem unitSystem, ParmRepository databaseBalanceService, IdentificationService identificationService)
        {
            _unitSystem = unitSystem;
            _databaseBalanceService = databaseBalanceService;
            _identificationService = identificationService;

            // Load units
            _monsters = _unitSystem.GetUnitGames();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Run tasks
            RespawnUnits();
            // MoveUnits();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Respawn units
        /// </summary>
        private void RespawnUnits()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        foreach (var monster in _monsters)
                        {
                            if (monster.DeadTime == null)
                            {
                                continue;
                            }

                            if (monster.DeadTime.Value.AddMilliseconds(monster.Respawn) > DateTime.Now)
                            {
                                continue;
                            }

                            _identificationService.RemoveUnit(monster);

                            monster._SetDefaultInfo(monster.ParmMon);
                            //_unitSystem.ResetUnit(monster);

                            _identificationService.AddUnit(monster);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(100);
                }
            });
        }
    }
}
