using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Packets.Core.Interfaces;
using Packets.Core.Services;
using Serilog;
using Server.Login.Core.Factories;
using Server.Login.Core.Factories.Interfaces;
using Server.Login.Core.Handlers;
using Server.Login.Core.Handlers.Interfaces;
using Server.Login.Models.Settings;
using Server.Login.Network;
using Server.Login.Services.Hosted;

namespace Server.Login
{
    public class Program
    {
        private static ServiceProvider ServiceProvider { get; set; }

        private static async Task Main(string[] args)
        {
            IHost hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, configurationBilder) =>
                {
                    string environment = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");

                    if (!string.IsNullOrWhiteSpace(environment))
                    {
                        hostingContext.HostingEnvironment.EnvironmentName = environment;
                    }

                    // Register server's settings
                    configurationBilder.SetBasePath(AppContext.BaseDirectory);
                    configurationBilder.AddJsonFile("appsettings.json", optional: false);
                    configurationBilder.AddJsonFile("loginsettings.json", optional: false);
                    configurationBilder.AddJsonFile($"appsettings.{environment}.json", optional: true);
                    configurationBilder.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();

                    // For view russian symbols
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                    // Adding serilog
                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(hostContext.Configuration)
                        .CreateLogger();

                    // Create database context
                    string connection = hostContext.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);

                    // Loading configure
                    services.Configure<LoginSetting>(hostContext.Configuration.GetSection("LoginSetting"));

                    // Register handlers
                    services.AddSingleton<IAuthorizationHandler, AuthorizationHandler>();
                    services.AddSingleton<IServersHandler, ServersHandler>();

                    // Register factories
                    services.AddSingleton<IAuthorizationFactory, AuthorizationFactory>();
                    services.AddSingleton<IServersFactory, ServersFactory>();

                    // Register all handlers packet
                    services.AddSingleton<IRegisterHandlerService, RegisterHandlerService>();

                    // Register services
                    services.AddSingleton<LoginServer>();

                    // Register hosted services
                    services.AddHostedService<NetworkHostedService>();

                    // Building service provider
                    ServiceProvider = services.BuildServiceProvider();

                    // Register all handlers packet assembly
                    ServiceProvider.GetService<IRegisterHandlerService>().RegistrationModels(Assembly.Load("Packets.Server.Login"));
                    ServiceProvider.GetService<IRegisterHandlerService>().RegistrationParsers(Assembly.Load("Packets.Server.Login"));
                    ServiceProvider.GetService<IRegisterHandlerService>().RegistrationHandlers(Assembly.Load("Server.Login"));
                })
                .UseSerilog()
                .Build();

            await hostBuilder.RunAsync();
        }
    }
}