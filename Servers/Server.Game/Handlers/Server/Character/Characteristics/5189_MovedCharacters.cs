using Core.Models;

namespace Server.Game.Handlers.Server.Character.Characteristics
{
    /// <summary>
    ///     Обработчик пакета перемещенного персонажа
    /// </summary>
    public class MovedCharacters : AsHandler<MovedCharactersModel>
    {
        public override int Code { get; set; } = 5189;

        public override MovedCharactersModel Treatment(ConnectionModel connection)
        {
            var movedCharactersModel = new MovedCharactersModel
            {
                SessionGameId = connection.GameConnection.Id,
                CoordinateX = connection.GameConnection.Character.CoordinateX,
                CoordinateZ = connection.GameConnection.Character.CoordinateZ,
                CoordinateY = connection.GameConnection.Character.CoordinateY,
                SpeedRun = connection.GameConnection.Character.SpeedRun,
                SightDirection = connection.GameConnection.Character.SightDirection,
                MoveDirection = connection.GameConnection.Character.MoveDirection
            };

            return movedCharactersModel;
        }
    }
}