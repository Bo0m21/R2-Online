using System;
using System.Collections.Generic;
using Core.Models;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Game.Handlers.Client.Character
{
    /// <summary>
    ///     Обработчик пакета удаления персонажа
    /// </summary>
    public class DeleteCharacters : AcHandler<DeleteCharactersModel>
    {
        public override int Code { get; set; } = 5120;

        public override IEnumerable<int> Treatment(ConnectionModel connection, DeleteCharactersModel model)
        {
            ServiceProvider serviceProvider = Program.ServiceCollection.BuildServiceProvider();

            using (IDatabaseContext databaseContext = serviceProvider.GetService<IDatabaseContext>())
            {
                CharacterModel character = databaseContext.Characters
                    .Include(a => a.Account)
                    .Include(e => e.Equipment)
                    .Include(i => i.Items)
                    .FirstOrDefault(c => c.AccountId == connection.AccountId && c.Id == model.CharacterId);

                if (character == null)
                {
                    connection.ErrorCode = (uint) ServerError.NoCharCannotDel;
                    return new List<int> {1102};
                }

                // Удаление персонажа и экипировки
                character.IsDeleted = true;
                character.Equipment.IsDeleted = true;

                // Удаление вещей
                foreach (ItemModel item in character.Items)
                {
                    item.IsDeleted = true;
                }

                // Сохранение даты удаления и обновление в базе
                character.DeleteDate = DateTime.Now;
                databaseContext.SaveChanges();

                return new List<int> {5121};
            }
        }
    }
}