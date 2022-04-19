using Core.Models;

namespace Server.Game.Handlers.Server.Character.Characteristics
{
    /// <summary>
    ///     Обработчик пакета файктического здоровья и маны
    /// </summary>
    public class HealthPointCharacteristics : AsHandler<HealthPointCharacteristicsModel>
    {
        public override int Code { get; set; } = 5146;

        public override HealthPointCharacteristicsModel Treatment(ConnectionModel connection)
        {
            var healthPointCharacteristicsModel = new HealthPointCharacteristicsModel
            {
                HealthPoint = connection.GameConnection.Character.HealthPoint,
                MagicPoint = connection.GameConnection.Character.MagicPoint
            };

            return healthPointCharacteristicsModel;
        }
    }
}