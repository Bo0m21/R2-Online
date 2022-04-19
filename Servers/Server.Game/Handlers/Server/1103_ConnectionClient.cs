using Core.Models;

namespace Server.Game.Handlers.Server
{
    /// <summary>
    ///     Обработчик пакета приветствия
    /// </summary>
    public class ConnectionClient : AsHandler<ConnectionClientModel>
    {
        public override int Code { get; set; } = 1103;

        public override ConnectionClientModel Treatment(ConnectionModel connection)
        {
            return new ConnectionClientModel();
        }
    }
}