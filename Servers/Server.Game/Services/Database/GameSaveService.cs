using Database.Game.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Server.Game.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.Database
{
    internal class GameSaveService : IHostedService
    {
        private readonly GameSetting _gameSetting;
        private readonly IdentificationService _identificationService;
        private readonly IGameContext _gameContext;

        public GameSaveService(IOptions<GameSetting> gameSetting, IdentificationService identificationService, IGameContext gameContext)
        {
            _gameSetting = gameSetting.Value;
            _identificationService = identificationService;
            _gameContext = gameContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            StartSaving();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Visible units
        /// </summary>
        private void StartSaving()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var connections = _identificationService.GetAllConnections().Where(c => c.Pc != null);

                        foreach (var connection in connections)
                        {
                            var pc = connection.Pc;
                            var pcState = _gameContext.PcStates.FirstOrDefault(x => x.No == pc.Simple.PcNo);

                            if (pcState == null)
                            {
                                throw new Exception($"PcState with PcNo:{pc.Simple.PcNo} not found");
                            }

                            pcState.PosX = pc.PositionCur.X;
                            pcState.PosY = pc.PositionCur.Y;
                            pcState.PosZ = pc.PositionCur.Z;

                            _gameContext.SaveChanges();
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(_gameSetting.SavePcsEverySeconds * 1000);
                }
            });
        }
    }
}
