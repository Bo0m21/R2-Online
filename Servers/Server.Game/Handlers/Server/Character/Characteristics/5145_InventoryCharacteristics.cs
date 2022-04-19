using Core.Models;

namespace Server.Game.Handlers.Server.Character.Characteristics
{
    /// <summary>
    ///     Обработчик пакета характеристик в инвентаре
    /// </summary>
    public class InventoryCharacteristics : AsHandler<InventoryCharacteristicsModel>
    {
        public override int Code { get; set; } = 5145;

        public override InventoryCharacteristicsModel Treatment(ConnectionModel connection)
        {
            var inventoryCharacteristicsModel = new InventoryCharacteristicsModel
            {
                Defence = connection.GameConnection.Character.Defence,
                Level = connection.GameConnection.Character.Level,
                Force = (short) connection.GameConnection.Character.Force,
                Adroitness = (short) connection.GameConnection.Character.Adroitness,
                Intelligence = (short) connection.GameConnection.Character.Intelligence,
                HealthPointMax = connection.GameConnection.Character.HealthPointMax,
                MagicPointMax = connection.GameConnection.Character.MagicPointMax
            };

            return inventoryCharacteristicsModel;
        }
    }
}