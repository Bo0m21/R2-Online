using Microsoft.Extensions.Hosting;
using Server.Game.Core.Systems;
using Server.Game.Models.GameModels;
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
        private readonly DatabaseBalanceService _databaseBalanceService;
        private readonly IdentificationService _identificationService;

        private readonly List<UnitGameModel> _units;

        public UnitGameService(UnitSystem unitSystem, DatabaseBalanceService databaseBalanceService, IdentificationService identificationService)
        {
            _unitSystem = unitSystem;
            _databaseBalanceService = databaseBalanceService;
            _identificationService = identificationService;

            // Load units
            _units = _unitSystem.GetUnitGames();
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
                        foreach (UnitGameModel unit in _units)
                        {
                            if (unit.DeadTime == null)
                            {
                                continue;
                            }

                            if (unit.DeadTime.Value.AddMilliseconds(unit.Respawn) > DateTime.Now)
                            {
                                continue;
                            }

                            _identificationService.RemoveUnit(unit);

                            _unitSystem.ResetUnit(unit);

                            _identificationService.AddUnit(unit);
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
