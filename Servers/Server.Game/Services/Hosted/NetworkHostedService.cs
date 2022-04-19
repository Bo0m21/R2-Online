using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Game.Network;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Game.Services.Hosted
{
    /// <summary>
    ///     Service that manages the Game Server instance.
    /// </summary>
    public class NetworkHostedService : IHostedService
    {
        private readonly ILogger<NetworkHostedService> _logger;
        private readonly GameServer _networkServer;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        public NetworkHostedService(ILogger<NetworkHostedService> logger, GameServer gameServer)
        {
            _logger = logger;
            _networkServer = gameServer;
        }

        /// <summary>
        ///     Starts the network server service
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _networkServer.Start();
            _logger.LogInformation("Server started");

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Stops the network server service
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _networkServer.Stop();
            _logger.LogInformation("Server stopped");

            return Task.CompletedTask;
        }
    }
}
