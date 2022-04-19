using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Login.Network;

namespace Server.Login.Services.Hosted
{
    /// <summary>
    ///     Service that manages the Login Server instance.
    /// </summary>
    public class NetworkHostedService : IHostedService
    {
        private readonly ILogger<NetworkHostedService> _logger;
        private readonly LoginServer _networkServer;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        public NetworkHostedService(ILogger<NetworkHostedService> logger, LoginServer loginServer)
        {
            _logger = logger;
            _networkServer = loginServer;
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
