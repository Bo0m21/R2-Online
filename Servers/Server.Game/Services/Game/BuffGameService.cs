using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Settings;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.GameServices
{
    /// <summary>
    ///     Garbage game service
    /// </summary>
    public class BuffGameService : IHostedService
    {
        private readonly GameSetting _gameSetting;
        private readonly IdentificationService _identificationService;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly AbnormalSystem _abnormalSystem;

        public BuffGameService(IOptions<GameSetting> gameSetting, IdentificationService identificationService, ICharacteristicFactory characteristicFactory, AbnormalSystem abnormalSystem)
        {
            _gameSetting = gameSetting.Value;
            _identificationService = identificationService;
            _characteristicFactory = characteristicFactory;
            _abnormalSystem = abnormalSystem;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            BuffEnd();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Garbage items
        /// </summary>
        private void BuffEnd()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var characters = _identificationService.GetAllConnections().Where(c => c.CharacterGame != null).Select(c => c.CharacterGame);

                        foreach (var character in characters)
                        {
                            foreach (var buff in character.Buffs)
                            {
                                if (buff.EndTick < Environment.TickCount)
                                {
                                    var client = _identificationService.GetConnectionByCharacterName(character.Name);

                                    character.Buffs.Remove(buff);
                                    _abnormalSystem.AbnormalRemove(client.CharacterGame, buff);

                                    _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
                                    _characteristicFactory.SendSpeedCharacteristics(client, client);
                                    _characteristicFactory.SendInformationAbilityCharacteristics(client);
                                    _characteristicFactory.SendInfoWeight(client);

                                    foreach (var visibleCharacters in client.CharacterGame.VisibleCharacterGames)
                                    {
                                        _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
                                        _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacters);
                                    }
                                }
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