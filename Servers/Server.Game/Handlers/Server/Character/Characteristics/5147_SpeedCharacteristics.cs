using Core.Models;

namespace Server.Game.Handlers.Server.Character.Characteristics
{
    /// <summary>
    ///     Обработчик пакета характеристик скорости
    /// </summary>
    public class SpeedCharacteristics : AsHandler<SpeedCharacteristicsModel>
    {
        public override int Code { get; set; } = 5147;

        public override SpeedCharacteristicsModel Treatment(ConnectionModel connection)
        {
            var speedCharacteristicsModel = new SpeedCharacteristicsModel
            {
                SpeedAttack = connection.GameConnection.Character.SpeedAttack,
                SpeedRun = connection.GameConnection.Character.SpeedRun,
                SessionGameId = connection.GameConnection.Id
            };

            return speedCharacteristicsModel;
        }
    }
}