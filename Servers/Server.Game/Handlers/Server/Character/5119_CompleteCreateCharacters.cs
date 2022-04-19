using System.Linq;
using Core.Models;
using Database.Interfaces;
using Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Game.Handlers.Server.Character
{
    /// <summary>
    ///     Обработчик пакета подтверждения создания персонажа
    /// </summary>
    public class CompleteCreateCharacters : AsHandler<CompleteCreateCharactersModel>
    {
        public override int Code { get; set; } = 5119;

        public override CompleteCreateCharactersModel Treatment(ConnectionModel connection)
        {
            ServiceProvider serviceProvider = Program.ServiceCollection.BuildServiceProvider();
            var completeCreateCharactersModel = new CompleteCreateCharactersModel();

            using (IDatabaseContext databaseContext = serviceProvider.GetService<IDatabaseContext>())
            {
                CharacterModel character = databaseContext.Characters.Where(c => c.AccountId == connection.AccountId)
                    .OrderBy(o => o.CreateDate).LastOrDefault();

                if (character != null)
                {
                    completeCreateCharactersModel.CharacterId = character.Id;
                    completeCreateCharactersModel.Force = character.Force;
                    completeCreateCharactersModel.Adroitness = character.Adroitness;
                    completeCreateCharactersModel.Intelligence = character.Intelligence;
                }
            }

            return completeCreateCharactersModel;
        }
    }
}