using Core.Models;
using Database.Models;

namespace Server.Game.Handlers.Server
{
    /// <summary>
    ///     Обработчик пакета подтверждения входа в мир(инвентарь)
    /// </summary>
    public class CompleteEnterWorld : AsHandler<CompleteEnterWorldModel>
    {
        public override int Code { get; set; } = 5117;

        public override CompleteEnterWorldModel Treatment(ConnectionModel connection)
        {
            // Заполнение характеристик
            var completeEnterWorldModel = new CompleteEnterWorldModel
            {
                SessionGameId = connection.GameConnection.Id,
                CoordinateX = connection.GameConnection.Character.CoordinateX,
                CoordinateZ = connection.GameConnection.Character.CoordinateZ,
                CoordinateY = connection.GameConnection.Character.CoordinateY,
                Reputation = connection.GameConnection.Character.Reputation
            };

            // Заполнение вещей
            foreach (ItemModel item in connection.GameConnection.Character.Items)
            {
                var newItem = new Item
                {
                    Id = item.Id,
                    ItemId = item.ItemId,
                    Amount = item.Amount,
                    Time = item.Time,
                    Type = item.Type,
                    TimeEffect = item.TimeEffect,
                    Lock = item.Lock,
                    Prolong = item.Prolong
                };

                completeEnterWorldModel.Items.Add(newItem);
            }

            return completeEnterWorldModel;
        }
    }
}