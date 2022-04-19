using System;
using System.Threading;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Interfaces
{
    /// <summary>
    ///     Интерфейс контекста базы
    /// </summary>
    public interface IDatabaseContext : IDisposable
    {
        /// <summary>
        ///     Аккаунты пользователей
        /// </summary>
        DbSet<AccountModel> Accounts { get; set; }

        /// <summary>
        ///     Сессии пользователей
        /// </summary>
        DbSet<SessionModel> Sessions { get; set; }

        /// <summary>
        ///     Персонажи пользователей
        /// </summary>
        DbSet<CharacterModel> Characters { get; set; }

        /// <summary>
        ///     Вещи персонажей
        /// </summary>
        DbSet<ItemModel> Items { get; set; }

        /// <summary>
        ///     Game servers
        /// </summary>
        DbSet<ServerModel> Servers { get; set; }

        /// <summary>
        ///     Сохранение изменений
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        ///     Асинхронное сохранение изменений
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}