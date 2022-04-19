using Core.Models;

namespace Server.Game.Handlers.Server.Character
{
    /// <summary>
    ///     Обработчик пакета подтверждения удаления персонажа
    /// </summary>
    public class CompleteDeleteCharacters : AsHandler<CompleteDeleteCharactersModel>
    {
        public override int Code { get; set; } = 5121;

        public override CompleteDeleteCharactersModel Treatment(ConnectionModel connection)
        {
            var completeDeleteCharactersModel = new CompleteDeleteCharactersModel();

            // Отправляется пустой пакет

            return completeDeleteCharactersModel;
        }
    }
}