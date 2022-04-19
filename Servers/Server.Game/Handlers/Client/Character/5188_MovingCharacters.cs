using System.Collections.Generic;
using Core.Models;

namespace Server.Game.Handlers.Client.Character
{
    /// <summary>
    ///     Обработчик пакета перемещения персонажа
    /// </summary>
    public class MovingCharacters : AcHandler<MovingCharactersModel>
    {
        public override int Code { get; set; } = 5188;

        public override IEnumerable<int> Treatment(ConnectionModel connection, MovingCharactersModel model)
        {
            // TODO Присечь спидхак
            connection.GameConnection.Character.CoordinateX = model.CoordinateX;
            connection.GameConnection.Character.CoordinateZ = model.CoordinateZ;
            connection.GameConnection.Character.CoordinateY = model.CoordinateY;
            connection.GameConnection.Character.SightDirection = model.SightDirection;
            connection.GameConnection.Character.MoveDirection = model.MoveDirection;

            // Скидываем атаку если мы дивнулись
            connection.GameConnection.AttackedConnection = null;

            // Отправляем перемещение персонажа
            MoveService.MoveCraracters(connection);
            MoveService.MoveNpcMonsters(connection);

            return new List<int> {5189};
        }
    }
}