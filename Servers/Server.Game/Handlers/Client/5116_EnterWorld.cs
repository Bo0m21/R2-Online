using System.Collections.Generic;
using Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Game.Handlers.Client
{
    /// <summary>
    ///     Обработчик пакета входа в мир
    /// </summary>
    public class EnterWorld : AcHandler<EnterWorldModel>
    {
        public override int Code { get; set; } = 5116;

        public override IEnumerable<int> Treatment(ConnectionModel connection, EnterWorldModel model)
        {
            ServiceProvider serviceProvider = Program.ServiceCollection.BuildServiceProvider();

            
        }
    }
}