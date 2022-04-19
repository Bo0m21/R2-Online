using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Balance;
using Database.Balance.Interfaces;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Packets.Core.Interfaces;
using Packets.Core.Services;
using Serilog;
using Server.Game.Core.Factories;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Settings;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Dataabse;
using Server.Game.Services.Game;
using Server.Game.Services.GameServices;
using Server.Game.Services.Hosted;
using Server.Game.Services.Mapping;

namespace Server.Game
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
                    configurationBilder.AddJsonFile("gamesettings.json", optional: false);
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

                    // Create database balance context
                    string balanceConnection = hostContext.Configuration.GetConnectionString("BalanceConnection");
                    services.AddDbContext<IDatabaseBalanceContext, DatabaseBalanceContext>(options => options.UseSqlServer(balanceConnection), ServiceLifetime.Transient);

                    // Register database services
                    services.AddSingleton<DatabaseService>();
                    services.AddSingleton<DatabaseBalanceService>();
                    services.AddSingleton<DatabaseQueueService>();

                    // Register mapping services
                    services.AddSingleton<GameMappingService>();
                    services.AddSingleton<DatabaseMappingService>();
                    services.AddSingleton<DatabaseBalanceMappingService>();

                    // Loading configure
                    services.Configure<GameSetting>(hostContext.Configuration.GetSection("GameSetting"));

                    // Register handlers
                    services.AddTransient<ISkillHandler, SkillHandler>();
                    services.AddTransient<IAbnormalHandler, AbnormalHandler>();
                    services.AddTransient<IAuthorizationHandler, AuthorizationHandler>();
                    services.AddTransient<ICharacterHandler, CharacterHandler>();
                    services.AddTransient<ICharacterActionHandler, CharacterActionHandler>();
                    services.AddTransient<IChatHandler, ChatHandler>();
                    services.AddTransient<IInventarHandler, InventarHandler>();
                    services.AddTransient<IAttackHandler, AttackHandler>();
                    services.AddTransient<IEquipHandler, EquipHandler>();
                    services.AddTransient<IReinforceHandler, ReinforceHandler>();
                    services.AddTransient<INpcActionHandler, NpcActionHandler>();

                    // Register factories
                    services.AddTransient<ISkillFactory, SkillFactory>();
                    services.AddTransient<IAttackFactory, AttackFactory>();
                    services.AddTransient<IAuthorizationFactory, AuthorizationFactory>();
                    services.AddTransient<ICharacterActionFactory, CharacterActionFactory>();
                    services.AddTransient<ICharacterFactory, CharacterFactory>();
                    services.AddTransient<ICharacteristicFactory, CharacteristicFactory>();
                    services.AddTransient<IInfoStomachFactory, InfoStomachFactory>();
                    services.AddTransient<IChatFactory, ChatFactory>();
                    services.AddTransient<IErrorFactory, ErrorFactory>();
                    services.AddTransient<IEquipFactory, EquipFactory>();
                    services.AddTransient<IInventarFactory, InventarFactory>();
                    services.AddTransient<IMonsterActionFactory, MonsterActionFactory>();
                    services.AddTransient<IVisibleFactory, VisibleFactory>();
                    services.AddTransient<IReinforceFactory, ReinforceFactory>();
                    services.AddTransient<INpcActionFactory, NpcActionFactory>();

                    // Register systems
                    services.AddTransient<AttackSystem>();
                    services.AddTransient<CharacterSystem>();
                    services.AddTransient<EquipSystem>();
                    services.AddTransient<AbnormalSystem>();
                    services.AddTransient<ExpSystem>();
                    services.AddTransient<InventarSystem>();
                    services.AddTransient<ItemUseSystem>();
                    services.AddTransient<ReinforceSystem>();
                    services.AddTransient<UnitDropSystem>();
                    services.AddTransient<UnitSystem>();

                    // Register all handlers packet
                    services.AddSingleton<IRegisterHandlerService, RegisterHandlerService>();

                    // Register services
                    services.AddSingleton<IdentificationService>();
                    services.AddSingleton<SerialNumberService>();
                    services.AddSingleton<GameServer>();

                    // Register hosted services
                    services.AddHostedService<NetworkHostedService>();

                    // Register game hosted services
                    services.AddHostedService<AttackGameService>();
                    services.AddHostedService<BuffGameService>();
                    services.AddHostedService<GarbageGameService>();
                    services.AddHostedService<RecoveryGameService>();
                    services.AddHostedService<UnitGameService>();
                    services.AddHostedService<VisibleGameService>();

                    // Building service provider
                    ServiceProvider = services.BuildServiceProvider();

                    // Register all handlers packet assembly
                    ServiceProvider.GetService<IRegisterHandlerService>().RegistrationModels(Assembly.Load("Packets.Server.Game"));
                    ServiceProvider.GetService<IRegisterHandlerService>().RegistrationParsers(Assembly.Load("Packets.Server.Game"));
                    ServiceProvider.GetService<IRegisterHandlerService>().RegistrationHandlers(Assembly.Load("Server.Game"));

                })
                .UseSerilog()
                .Build();

            await hostBuilder.RunAsync();
        }
    }
}