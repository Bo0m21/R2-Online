using Database.Balance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Balance.Interfaces
{
    /// <summary>
    ///     Interface for database balance context
    /// </summary>
    public interface IDatabaseBalanceContext : IDisposable
    {
        /// <summary>
        ///     Buff items
        /// </summary>
        DbSet<BuffItemModel> BuffItems { get; set; }

        /// <summary>
        ///     Buffs
        /// </summary>
        DbSet<BuffModel> Buffs { get; set; }

        /// <summary>
        ///     Characters
        /// </summary>
        DbSet<CharacterModel> Characters { get; set; }

        /// <summary>
        ///     Character positions
        /// </summary>
        DbSet<CharacterPositionModel> CharacterPositions { get; set; }

        /// <summary>
        ///     Exps
        /// </summary>
        DbSet<ExpModel> Exps { get; set; }

        /// <summary>
        ///     Items
        /// </summary>
        DbSet<ItemModel> Items { get; set; }

        /// <summary>
        ///     Item reinforces
        /// </summary>
        DbSet<ItemReinforceModel> ItemReinforces { get; set; }

        /// <summary>
        ///     Unit drops
        /// </summary>
        DbSet<UnitDropModel> UnitDrops { get; set; }

        /// <summary>
        ///     Units
        /// </summary>
        DbSet<UnitModel> Units { get; set; }

        /// <summary>
        ///     Unit positions
        /// </summary>
        DbSet<UnitPositionModel> UnitPositions { get; set; }

        /// <summary>
        ///     Unit purchases
        /// </summary>
        DbSet<UnitPurchaseModel> UnitPurchases { get; set; }

        /// <summary>
        ///     Unit sales
        /// </summary>
        DbSet<UnitSaleModel> UnitSales { get; set; }

        /// <summary>
        ///     Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        ///     Async save changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Add new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry Add([NotNull] object entity);

        /// <summary>
        ///     Add new generic entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        ///     Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry Update([NotNullAttribute] object entity);

        /// <summary>
        ///     Update generic entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<TEntity> Update<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
    }
}
