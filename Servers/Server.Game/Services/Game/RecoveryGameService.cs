using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Settings;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.GameServices
{
    /// <summary>
    ///     Recovery game service
    /// </summary>
    public class RecoveryGameService : IHostedService
    {
        private readonly GameSetting _gameSetting;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IdentificationService _identificationService;

        public RecoveryGameService(IOptions<GameSetting> gameSetting, ICharacteristicFactory characteristicFactory, IdentificationService identificationService)
        {
            _gameSetting = gameSetting.Value;
            _characteristicFactory = characteristicFactory;
            _identificationService = identificationService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            RecoveryConnections();
            RecoveryUnits();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Recovery connections
        /// </summary>
        private void RecoveryConnections()
        {
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            var connections = _identificationService.GetAllConnections().Where(c => c.Pc != null);

            //            foreach (var connection in connections)
            //            {
            //                if (connection.Pc.DeadTime != null)
            //                {
            //                    continue;
            //                }

            //                bool isUpdate = false;

            //                if (connection.Pc.LastUpdateHpMp.AddMilliseconds(_gameSetting.RecoveryCharacteristics) < DateTime.Now)
            //                {
            //                    if (connection.Pc.Hp < connection.Pc.HpMax)
            //                    {
            //                        connection.Pc.Hp += connection.Pc.HpRegen;
            //                        isUpdate = true;
            //                    }

            //                    if (connection.Pc.Mp < connection.Pc.MpMax)
            //                    {
            //                        connection.Pc.Mp += connection.Pc.MpRegen;
            //                        isUpdate = true;
            //                    }

            //                    connection.Pc.LastUpdateHpMp = DateTime.Now;
            //                }

            //                if (connection.Pc.Hp > connection.Pc.HpMax)
            //                {
            //                    isUpdate = true;
            //                    connection.Pc.Hp = connection.Pc.HpMax;
            //                }

            //                if (connection.Pc.Mp > connection.Pc.MpMax)
            //                {
            //                    isUpdate = true;
            //                    connection.Pc.Mp = connection.Pc.MpMax;
            //                }

            //                if (isUpdate)
            //                {
            //                    _characteristicFactory.SendHealthPointCharacteristics(connection);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //        }

            //        Thread.Sleep(100);
            //    }
            //});
        }

        /// <summary>
        ///     Recovery units
        /// </summary>
        private void RecoveryUnits()
        {
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            var units = _identificationService.GetAllUnits();

            //            foreach (var unit in units)
            //            {
            //                if (unit.DeadTime != null)
            //                {
            //                    continue;
            //                }

            //                if (unit.LastUpdateHpMp.AddMilliseconds(_gameSetting.RecoveryCharacteristics) < DateTime.Now)
            //                {
            //                    if (unit.Hp < unit.HpMax)
            //                    {
            //                        unit.Hp += unit.HpRegen;
            //                    }

            //                    if (unit.Mp < unit.MpMax)
            //                    {
            //                        unit.Mp += unit.MpRegen;
            //                    }

            //                    unit.LastUpdateHpMp = DateTime.Now;
            //                }

            //                if (unit.Hp > unit.HpMax)
            //                {
            //                    unit.Hp = unit.HpMax;
            //                }

            //                if (unit.Mp > unit.MpMax)
            //                {
            //                    unit.Mp = unit.MpMax;
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //        }

            //        Thread.Sleep(100);
            //    }
            //});
        }
    }
}
