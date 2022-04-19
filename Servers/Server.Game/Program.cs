using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Database.Account;
using Database.Account.Interfaces;
using Database.Game;
using Database.Game.Interfaces;
using Database.Parm;
using Database.Parm.Interfaces;
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
using Server.Game.Services.Database;
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

                    // Create database account context
                    string accountConnection = hostContext.Configuration.GetConnectionString("AccountConnection");
                    services.AddDbContext<IAccountContext, AccountContext>(options => options.UseSqlServer(accountConnection), ServiceLifetime.Transient);

                    // Create database parm context
                    string gameConnection = hostContext.Configuration.GetConnectionString("GameConnection");
                    services.AddDbContext<IGameContext, GameContext>(options => options.UseSqlServer(gameConnection), ServiceLifetime.Transient);

                    // Create database parm context
                    string parmConnection = hostContext.Configuration.GetConnectionString("ParmConnection");
                    services.AddDbContext<IParmContext, ParmContext>(options => options.UseSqlServer(parmConnection), ServiceLifetime.Transient);

                    // Register database services
                    services.AddTransient<GameRepository>();
                    services.AddSingleton<ParmRepository>();
                    services.AddSingleton<DatabaseQueueService>();

                    // Register mapping services
                    services.AddSingleton<Services.Mapping.GameMappingService>();
                    services.AddSingleton<Services.DBGameMappingService>();
                    services.AddSingleton<DBParmMappingService>();

                    // Loading configure
                    var gameSettings = hostContext.Configuration.GetSection("GameSetting");
                    services.Configure<GameSetting>(gameSettings);

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
                    services.AddTransient<IInventoryFactory, InventoryFactory>();
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
                    services.AddHostedService<GameSaveService>();

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