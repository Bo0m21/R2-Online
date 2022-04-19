using Core.Models;

namespace Server.Game.Handlers.Server.Settings
{
    /// <summary>
    ///     Обработчик пакета настроек клиента
    /// </summary>
    public class SettingClient : AsHandler<SettingClientModel>
    {
        public override int Code { get; set; } = 5813;

        public override SettingClientModel Treatment(ConnectionModel connection)
        {
            return new SettingClientModel();
        }
    }
}