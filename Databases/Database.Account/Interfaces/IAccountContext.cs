using System;
using System.Threading;
using System.Threading.Tasks;
using Database.Account.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Account.Interfaces
{
    /// <summary>
    ///     Интерфейс контекста базы
    /// </summary>
    public interface IAccountContext : IDisposable
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