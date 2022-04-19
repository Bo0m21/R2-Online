using System.Linq;
using Core.Models;
using Database.Interfaces;
using Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Game.Handlers.Server.Character
{
    /// <summary>
    ///     Обработчик пакета дополнительной информации о персонажах
    /// </summary>
    public class OtherInformationCharacters : AsHandler<OtherInformationCharactersModel>
    {
        public override int Code { get; set; } = 5523;

        public override OtherInformationCharactersModel Treatment(ConnectionModel connection)
        {
            ServiceProvider serviceProvider = Program.ServiceCollection.BuildServiceProvider();
            var otherInformationCharactersModel = new OtherInformationCharactersModel();

            using (IDatabaseContext databaseContext = serviceProvider.GetService<IDatabaseContext>())
            {
                IQueryable<CharacterModel> characters = databaseContext.Characters.Where(c => c.AccountId == connection.AccountId);

                foreach (CharacterModel character in characters)
                {
                    otherInformationCharactersModel.OtherInformations.Add(new OtherInformation
                    {
                        CharacterId = character.Id
                    });
                }
            }

            return otherInformationCharactersModel;
        }
    }
}