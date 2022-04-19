using Database.Account.Interfaces;
using Database.Account.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Database.Account
{
    /// <summary>
    ///     Контекст базы данных
    /// </summary>
    public class AccountContext : DbContext, IAccountContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            //Database.EnsureCreated(); //  TODO For tested

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

            ServerModel serverModel = Servers.FirstOrDefault(a => a.Name == "Server");

            if (serverModel == null)
            {
                Servers.Add(new ServerModel()
                {
                    ServerId = 100,
                    Name = "Server",
                    Type = Enums.ServerType.OpenServer,
                    Hidden = false,
                    ServerIp = "192.168.1.129",
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
        public DbSet<ServerModel> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}