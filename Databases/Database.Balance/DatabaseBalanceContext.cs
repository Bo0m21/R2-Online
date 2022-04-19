using Database.Balance.Interfaces;
using Database.Balance.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Balance
{
    /// <summary>
    ///     Database balance context
    /// </summary>
    public class DatabaseBalanceContext : DbContext, IDatabaseBalanceContext
    {
        public DatabaseBalanceContext(DbContextOptions<DatabaseBalanceContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<BuffItemModel> BuffItems { get; set; }
        public DbSet<BuffModel> Buffs { get; set; }
        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<CharacterPositionModel> CharacterPositions { get; set; }
        public DbSet<ExpModel> Exps { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ItemReinforceModel> ItemReinforces { get; set; }
        public DbSet<UnitDropModel> UnitDrops { get; set; }
        public DbSet<UnitModel> Units { get; set; }
        public DbSet<UnitPositionModel> UnitPositions { get; set; }
        public DbSet<UnitPurchaseModel> UnitPurchases { get; set; }
        public DbSet<UnitSaleModel> UnitSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuffItemModel>()
                .HasIndex(u => new { u.BuffId, u.ItemId })
                .IsUnique();

            modelBuilder.Entity<BuffModel>()
                .HasIndex(u => u.BuffId)
                .IsUnique();

            modelBuilder.Entity<CharacterModel>()
                .HasIndex(u => new { u.Class, u.Level })
                .IsUnique();

            modelBuilder.Entity<CharacterPositionModel>()
                .HasIndex(u => u.Class)
                .IsUnique();

            modelBuilder.Entity<ExpModel>()
                .HasIndex(u => new { u.Exp, u.Level })
                .IsUnique();

            modelBuilder.Entity<ItemModel>()
                .HasIndex(u => u.ItemId)
                .IsUnique();

            modelBuilder.Entity<ItemReinforceModel>()
                .HasOne(d => d.Item)
                .WithMany(p => p.ItemReinforces)
                .HasForeignKey(d => d.ItemId);

            modelBuilder.Entity<ItemReinforceModel>()
                .HasOne(d => d.ItemOld)
                .WithMany(p => p.ItemReinforceOlds)
                .HasForeignKey(d => d.ItemOldId);

            modelBuilder.Entity<ItemReinforceModel>()
                .HasOne(d => d.ItemNew)
                .WithMany(p => p.ItemReinforceNews)
                .HasForeignKey(d => d.ItemNewId);

            modelBuilder.Entity<ItemReinforceModel>()
                .HasOne(d => d.Item1)
                .WithMany(p => p.ItemReinforces1)
                .HasForeignKey(d => d.Item1Id);

            modelBuilder.Entity<ItemReinforceModel>()
                .HasOne(d => d.Item2)
                .WithMany(p => p.ItemReinforces2)
                .HasForeignKey(d => d.Item2Id);

            modelBuilder.Entity<ItemReinforceModel>()
                .HasOne(d => d.Item3)
                .WithMany(p => p.ItemReinforces3)
                .HasForeignKey(d => d.Item3Id);

            modelBuilder.Entity<ItemReinforceModel>()
                .HasIndex(u => new { u.ItemId, u.Item1Id, u.Item2Id, u.Item3Id })
                .IsUnique();

            modelBuilder.Entity<UnitDropModel>()
                .HasIndex(u => new { u.ItemId, u.UnitId })
                .IsUnique();

            modelBuilder.Entity<UnitModel>()
                .HasIndex(u => u.UnitId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
