using Database.Game.Interfaces;
using Database.Game.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Database.Game
{
    /// <summary>
    ///     Контекст базы данных
    /// </summary>
    public class GameContext : DbContext, IGameContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            //Database.EnsureCreated(); //  TODO For tested
        }

        public virtual DbSet<ItemSerial> ItemSerials { get; set; }
        public virtual DbSet<Pc> Pcs { get; set; }
        public virtual DbSet<PcAbnormal> PcAbnormals { get; set; }
        public virtual DbSet<PcAchieveEquip> PcAchieveEquips { get; set; }
        public virtual DbSet<PcAchieveInventory> PcAchieveInventories { get; set; }
        public virtual DbSet<PcAchieveList> PcAchieveLists { get; set; }
        public virtual DbSet<PcBead> PcBeads { get; set; }
        public virtual DbSet<PcChatFilter> PcChatFilters { get; set; }
        public virtual DbSet<PcCoolTime> PcCoolTimes { get; set; }
        public virtual DbSet<PcDeleted> PcDeleteds { get; set; }
        public virtual DbSet<PcEquip> PcEquips { get; set; }
        public virtual DbSet<PcFriend> PcFriends { get; set; }
        public virtual DbSet<PcGoldItemEffect> PcGoldItemEffects { get; set; }
        public virtual DbSet<PcInvenQslotInfo> PcInvenQslotInfos { get; set; }
        public virtual DbSet<PcInventory> PcInventories { get; set; }
        public virtual DbSet<PcLevelupCoin> PcLevelupCoins { get; set; }
        public virtual DbSet<PcPopupGuide> PcPopupGuides { get; set; }
        public virtual DbSet<PcQuest> PcQuests { get; set; }
        public virtual DbSet<PcQuestCondition> PcQuestConditions { get; set; }
        public virtual DbSet<PcQuestVisit> PcQuestVisits { get; set; }
        public virtual DbSet<PcRestored> PcRestoreds { get; set; }
        public virtual DbSet<PcServant> PcServants { get; set; }
        public virtual DbSet<PcServantSkillPack> PcServantSkillPacks { get; set; }
        public virtual DbSet<PcServantSkillTree> PcServantSkillTrees { get; set; }
        public virtual DbSet<PcSkillPackInventory> PcSkillPackInventories { get; set; }
        public virtual DbSet<PcSkillTreeInventory> PcSkillTreeInventories { get; set; }
        public virtual DbSet<PcState> PcStates { get; set; }
        public virtual DbSet<PcStore> PcStores { get; set; }
        public virtual DbSet<PcTeleport> PcTeleports { get; set; }
        public virtual DbSet<PcUnConfirmedCoin> PcUnConfirmedCoins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=localhost;Database=R2Game;Trusted_Connection=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ItemSerial>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK_CL_ItemSerial");

                entity.ToTable("ItemSerial");
            });

            modelBuilder.Entity<Pc>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PkPc")
                    .IsClustered(false);

                entity.ToTable("Pc");

                entity.Property(e => e.DelDate).HasColumnType("datetime");

                entity.Property(e => e.NickName).HasColumnName("Nm")
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcAbnormal>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.ParmNo });

                entity.ToTable("PcAbnormal");

                entity.Property(e => e.RestoreCnt).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PcNoNavigation)
                    .WithMany(p => p.PcAbnormals)
                    .HasForeignKey(d => d.PcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcAbnormalPc");
            });

            modelBuilder.Entity<PcAchieveEquip>(entity =>
            {
                entity.HasKey(e => e.SerialNo);

                entity.ToTable("PcAchieveEquip");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<PcAchieveInventory>(entity =>
            {
                entity.HasKey(e => e.SerialNo);

                entity.ToTable("PcAchieveInventory");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.AchieveGuildId).HasColumnName("AchieveGuildID");

                entity.Property(e => e.AchieveId).HasColumnName("AchieveID");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcAchieveList>(entity =>
            {
                entity.ToTable("PcAchieveList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AchieveId).HasColumnName("AchieveID");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcBead>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PcBead");

                entity.HasIndex(e => new { e.OwnerSerialNo, e.BeadIndex }, "UNC_PcBead_OwnerSerialNo_BeadIndex")
                    .IsUnique();

                entity.HasIndex(e => new { e.OwnerSerialNo, e.ItemNo }, "UNC_PcBead_OwnerSerialNo_ItemNo")
                    .IsUnique();

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PcChatFilter>(entity =>
            {
                entity.HasKey(e => new { e.OwnerPcNo, e.ChatFilterPcNo, e.ChatFilterPcNm })
                    .HasName("UCL_PK_PcChatFilter_OwnerPcNo_ChatFilterPcNo_ChatFilterPcNm");

                entity.ToTable("PcChatFilter");

                entity.Property(e => e.ChatFilterPcNm)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OwnerPcNoNavigation)
                    .WithMany(p => p.PcChatFilters)
                    .HasForeignKey(d => d.OwnerPcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcChatFilterPc");
            });

            modelBuilder.Entity<PcCoolTime>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.CoolTimeGroup })
                    .HasName("UCL_PcCoolTime");

                entity.ToTable("PcCoolTime");

                entity.Property(e => e.Sid).HasColumnName("SID");
            });

            modelBuilder.Entity<PcDeleted>(entity =>
            {
                entity.HasKey(e => e.PcNo)
                    .HasName("PkPcDeleted");

                entity.ToTable("PcDeleted");

                entity.Property(e => e.PcNo).ValueGeneratedNever();

                entity.Property(e => e.PcNm)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PcNoNavigation)
                    .WithOne(p => p.PcDeleted)
                    .HasForeignKey<PcDeleted>(d => d.PcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcDeletedPc");
            });

            modelBuilder.Entity<PcEquip>(entity =>
            {
                entity.HasKey(e => new { e.Owner, e.Slot })
                    .HasName("PkPcEquip");

                entity.ToTable("PcEquip");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PcNoNavigation)
                    .WithMany(p => p.PcEquips)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                    //.HasConstraintName("FkPcAbnormalPc");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.PcEquips)
                    .HasForeignKey(d => d.SerialNo)
                    .HasConstraintName("FkPcEquipPcInventory");
            });

            modelBuilder.Entity<PcFriend>(entity =>
            {
                entity.HasKey(e => new { e.OwnerPcNo, e.FriendPcNo, e.FriendPcNm })
                    .HasName("PK_CL_PcFriend");

                entity.ToTable("PcFriend");

                entity.Property(e => e.FriendPcNm)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OwnerPcNoNavigation)
                    .WithMany(p => p.PcFriends)
                    .HasForeignKey(d => d.OwnerPcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcFriendPc");
            });

            modelBuilder.Entity<PcGoldItemEffect>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.ItemType })
                    .HasName("CL_PK_PcGoldItemEffect");

                entity.ToTable("PcGoldItemEffect");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ItemNo).HasDefaultValueSql("((409))");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcInvenQslotInfo>(entity =>
            {
                entity.HasKey(e => e.PcNo)
                    .HasName("UCL_PK_PcInvenQSlotInfo");

                entity.ToTable("PcInvenQSlotInfo");

                entity.Property(e => e.PcNo).ValueGeneratedNever();

                entity.Property(e => e.Info)
                    .HasMaxLength(8000)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PcNoNavigation)
                    .WithOne(p => p.PcInvenQslotInfo)
                    .HasForeignKey<PcInvenQslotInfo>(d => d.PcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcInvenQSlotInfoPc");
            });

            modelBuilder.Entity<PcInventory>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK_NC_PcInventory_1")
                    .IsClustered(false);

                entity.ToTable("PcInventory");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.ApplyAbnItemEndDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CntUse).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PcNoNavigation)
                    .WithMany(p => p.PcInventoryItems)
                    .HasForeignKey(d => d.PcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PcLevelupCoin>(entity =>
            {
                entity.HasKey(e => e.Pcno)
                    .HasName("UCL_PK_PcLevelupCoin_Pcno");

                entity.ToTable("PcLevelupCoin");

                entity.Property(e => e.Pcno).ValueGeneratedNever();
            });

            modelBuilder.Entity<PcPopupGuide>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.GuideNo })
                    .HasName("UCL_PcPopupGuide_UnitedKey");

                entity.ToTable("PcPopupGuide");
            });

            modelBuilder.Entity<PcQuest>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.QuestNo })
                    .HasName("PK_CL_PcQuest");

                entity.ToTable("PcQuest");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LimitTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<PcQuestCondition>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.QuestNo, e.MonsterNo })
                    .HasName("UCL_PK_PcQuestCondition_PcNo");

                entity.ToTable("PcQuestCondition");
            });

            modelBuilder.Entity<PcQuestVisit>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.QuestNo, e.PlaceNo })
                    .HasName("UCL_PK_PcQuestVisit_PcNo");

                entity.ToTable("PcQuestVisit");
            });

            modelBuilder.Entity<PcRestored>(entity =>
            {
                entity.HasKey(e => e.PcNo);

                entity.ToTable("PcRestored");

                entity.Property(e => e.PcNo).ValueGeneratedNever();

                entity.Property(e => e.PcNm)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PcRestoredOperator)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcServant>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("UCL_PK_PcServant");

                entity.ToTable("PcServant");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.Level).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcServantSkillPack>(entity =>
            {
                entity.HasKey(e => new { e.SerialNo, e.Spid })
                    .HasName("UCL_PK_PcServantSkillPack");

                entity.ToTable("PcServantSkillPack");

                entity.Property(e => e.Spid).HasColumnName("SPID");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcServantSkillTree>(entity =>
            {
                entity.HasKey(e => new { e.SerialNo, e.Stniid })
                    .HasName("UCL_PK_PcServantSkillTree");

                entity.ToTable("PcServantSkillTree");

                entity.Property(e => e.Stniid).HasColumnName("STNIID");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Stid).HasColumnName("STID");
            });

            modelBuilder.Entity<PcSkillPackInventory>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.Spid })
                    .HasName("UCL_PK_PcSkillPackInventory_mPcNo_mSPID");

                entity.ToTable("PcSkillPackInventory");

                entity.Property(e => e.Spid).HasColumnName("SPID");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcSkillTreeInventory>(entity =>
            {
                entity.HasKey(e => new { e.PcNo, e.Stniid })
                    .HasName("UCL_PK_PcSkillTreeInventory_PcNo_STNIID");

                entity.ToTable("PcSkillTreeInventory");

                entity.Property(e => e.Stniid).HasColumnName("STNIID");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcState>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PkPcState");

                entity.ToTable("PcState");

                entity.Property(e => e.No).ValueGeneratedNever();

                entity.Property(e => e.DiscipleJoinCount).HasDefaultValueSql("((3))");

                entity.Property(e => e.GuildQmcnt).HasColumnName("GuildQMCnt");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsPreventItemDrop).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoginTm).HasColumnType("datetime");

                entity.Property(e => e.LogoutTm).HasColumnType("datetime");

                entity.Property(e => e.Qmcnt).HasColumnName("QMCnt");

                entity.Property(e => e.Stomach).HasDefaultValueSql("((100))");

                entity.HasOne(d => d.NoNavigation)
                    .WithOne(p => p.State)
                    .HasForeignKey<PcState>(d => d.No)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcStatePc");
            });

            modelBuilder.Entity<PcStore>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK_NC_PcStore_1")
                    .IsClustered(false);

                entity.ToTable("PcStore");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.ApplyAbnItemEndDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CntUse).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PcTeleport>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PkPcTeleport")
                    .IsClustered(false);

                entity.ToTable("PcTeleport");

                entity.Property(e => e.Level).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PcNoNavigation)
                    .WithMany(p => p.PcTeleports)
                    .HasForeignKey(d => d.PcNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkPcTeleportPc");
            });

            modelBuilder.Entity<PcUnConfirmedCoin>(entity =>
            {
                entity.HasKey(e => e.PcNo);

                entity.ToTable("PcUnConfirmedCoin");

                entity.Property(e => e.PcNo).ValueGeneratedNever();

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}