using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Database
{
    /// <summary>
    ///     Контекст базы данных
    /// </summary>
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated(); //  TODO For tested

            #region Create tested data

            AccountModel accountModel = Accounts.FirstOrDefault(a => a.Login == "admin");

            if (accountModel == null)
            {
                Accounts.Add(new AccountModel()
                {
                    Login = "admin",
                    Password = "test"
                });

                SaveChanges();
            }

            AccountModel accountModel1 = Accounts.FirstOrDefault(a => a.Login == "admin1");

            if (accountModel1 == null)
            {
                Accounts.Add(new AccountModel()
                {
                    Login = "admin1",
                    Password = "test1"
                });

                SaveChanges();
            }

            AccountModel accountModel2 = Accounts.FirstOrDefault(a => a.Login == "admin2");

            if (accountModel2 == null)
            {
                Accounts.Add(new AccountModel()
                {
                    Login = "admin2",
                    Password = "test2"
                });

                SaveChanges();
            }

            AccountModel accountModel3 = Accounts.FirstOrDefault(a => a.Login == "123456");

            if (accountModel3 == null)
            {
                Accounts.Add(new AccountModel()
                {
                    Login = "123456",
                    Password = "123456"
                });

                SaveChanges();
            }

            ServerModel serverModel = Servers.FirstOrDefault(a => a.Name == "Server");

            if (serverModel == null)
            {
                Servers.Add(new ServerModel()
                {
                    ServerId = 100,
                    Name = "Server",
                    Type = Enums.ServerType.OpenServer,
                    Hidden = false,
                    ServerIp = "127.0.0.1",
                    ServerPort = 11007,
                    Status = true,
                    Congestion = Enums.CongestionType.Low
                });

                SaveChanges();
            }

            #endregion
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }
        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ServerModel> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterModel>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<ItemModel>()
                .HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}