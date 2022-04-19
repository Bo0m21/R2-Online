using Core.Models;

namespace Server.Game.Handlers.Server.Character.Characteristics
{
    /// <summary>
    ///     Обработчик пакета конца прыжка
    /// </summary>
    public class JumpEndCharacters : AsHandler<JumpEndCharactersModel>
    {
        public override int Code { get; set; } = 5193;

        public override JumpEndCharactersModel Treatment(ConnectionModel connection)
        {
            var jumpEndCharactersModel = new JumpEndCharactersModel
            {
                SessionGameId = connection.GameConnection.Id,
                SightDirection = connection.GameConnection.Character.SightDirection,
                MoveDirection = connection.GameConnection.Character.MoveDirection
            };

            return jumpEndCharactersModel;
        }
    }
}