using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Server.Game.Models.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.GameServices
{
    /// <summary>
    ///     Garbage game service
    /// </summary>
    public class GarbageGameService : IHostedService
    {
        private readonly GameSetting _gameSetting;
        private readonly IdentificationService _identificationService;

        public GarbageGameService(IOptions<GameSetting> gameSetting, IdentificationService identificationService)
        {
            _gameSetting = gameSetting.Value;
            _identificationService = identificationService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            GarbageItems();
            GarbageUnits();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Garbage items
        /// </summary>
        private void GarbageItems()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var items = _identificationService.GetAllItems();

                        foreach (var item in items)
                        {
                            if (item.DateCreate.AddMilliseconds(_gameSetting.GarbageItems) > DateTime.Now)
                            {
                                continue;
                            }

                            _identificationService.RemoveItem(item);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(100);
                }
            });
        }

        /// <summary>
        ///     Garbage units
        /// </summary>
        private void GarbageUnits()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var units = _identificationService.GetAllUnits();

                        foreach (var unit in units)
                        {
                            if (unit.DeadTime == null)
                            {
                                continue;
                            }

                            if (unit.Respawn <= _gameSetting.GarbageUnits + 5000)
                            {
                                if (unit.DeadTime.Value.AddMilliseconds(unit.Respawn - 5000) > DateTime.Now)
                                {
                                    continue;
                                }

                                _identificationService.RemoveUnit(unit);
                            }
                            else
                            {
                                if (unit.DeadTime.Value.AddMilliseconds(_gameSetting.GarbageUnits) > DateTime.Now)
                                {
                                    continue;
                                }

                                _identificationService.RemoveUnit(unit);
                            }
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
