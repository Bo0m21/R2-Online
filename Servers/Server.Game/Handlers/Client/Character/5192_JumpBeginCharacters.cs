using System.Collections.Generic;
using Core.Models;

namespace Server.Game.Handlers.Client.Character
{
    /// <summary>
    ///     Обработчик пакета начала прыжка
    /// </summary>
    public class JumpBeginCharacters : AcHandler<JumpBeginCharactersModel>
    {
        public override int Code { get; set; } = 5192;

        public override IEnumerable<int> Treatment(ConnectionModel connection, JumpBeginCharactersModel model)
        {
            connection.GameConnection.Character.SightDirection = model.SightDirection;
            connection.GameConnection.Character.MoveDirection = model.MoveDirection;

            // Отправляем прыжок персонажа
            MoveService.JumpCraracters(connection);

            return new List<int> {5193};
        }
    }
}