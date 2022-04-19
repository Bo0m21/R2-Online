﻿// <auto-generated />
using Database.Balance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Balance.Migrations
{
    [DbContext(typeof(DatabaseBalanceContext))]
    [Migration("20200406200602_UpdateDistanceAttack")]
    partial class UpdateDistanceAttack
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Balance.Models.CharacterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AttackRate")
                        .HasColumnType("smallint");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("DDd")
                        .HasColumnType("int");

                    b.Property<int>("DDvMax")
                        .HasColumnType("int");

                    b.Property<int>("DDvMin")
                        .HasColumnType("int");

                    b.Property<int>("DPv")
                        .HasColumnType("int");

                    b.Property<short>("Dex")
                        .HasColumnType("smallint");

                    b.Property<int>("Dhit")
                        .HasColumnType("int");

                    b.Property<short>("HpMax")
                        .HasColumnType("smallint");

                    b.Property<short>("HpRegen")
                        .HasColumnType("smallint");

                    b.Property<short>("Int")
                        .HasColumnType("smallint");

                    b.Property<short>("Level")
                        .HasColumnType("smallint");

                    b.Property<int>("MDd")
                        .HasColumnType("int");

                    b.Property<int>("MDvMax")
                        .HasColumnType("int");

                    b.Property<int>("MDvMin")
                        .HasColumnType("int");

                    b.Property<int>("MPv")
                        .HasColumnType("int");

                    b.Property<int>("Mhit")
                        .HasColumnType("int");

                    b.Property<short>("MoveRate")
                        .HasColumnType("smallint");

                    b.Property<short>("MpMax")
                        .HasColumnType("smallint");

                    b.Property<short>("MpRegen")
                        .HasColumnType("smallint");

                    b.Property<int>("RDd")
                        .HasColumnType("int");

                    b.Property<int>("RDvMax")
                        .HasColumnType("int");

                    b.Property<int>("RDvMin")
                        .HasColumnType("int");

                    b.Property<int>("RPv")
                        .HasColumnType("int");

                    b.Property<int>("Rhit")
                        .HasColumnType("int");

                    b.Property<short>("Str")
                        .HasColumnType("smallint");

                    b.Property<short>("WeightMax")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Class", "Level")
                        .IsUnique();

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Database.Balance.Models.CharacterPositionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.Property<float>("Z")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Class")
                        .IsUnique();

                    b.ToTable("CharacterPositions");
                });

            modelBuilder.Entity("Database.Balance.Models.ExpModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<short>("Level")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Exp", "Level")
                        .IsUnique();

                    b.ToTable("Exps");
                });

            modelBuilder.Entity("Database.Balance.Models.ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AddPotionRestoreHp")
                        .HasColumnType("smallint");

                    b.Property<short>("AddPotionRestoreMp")
                        .HasColumnType("smallint");

                    b.Property<short>("AddTransformMaxHp")
                        .HasColumnType("smallint");

                    b.Property<short>("AddTransformMaxMp")
                        .HasColumnType("smallint");

                    b.Property<short>("AttackRate")
                        .HasColumnType("smallint");

                    b.Property<short>("AttackRateWhenTransform")
                        .HasColumnType("smallint");

                    b.Property<short>("Critical")
                        .HasColumnType("smallint");

                    b.Property<short>("CriticalProtect")
                        .HasColumnType("smallint");

                    b.Property<int>("DDd")
                        .HasColumnType("int");

                    b.Property<short>("DDvCriticalAdd")
                        .HasColumnType("smallint");

                    b.Property<short>("DDvCriticalRemove")
                        .HasColumnType("smallint");

                    b.Property<int>("DDvMax")
                        .HasColumnType("int");

                    b.Property<int>("DDvMin")
                        .HasColumnType("int");

                    b.Property<int>("DPv")
                        .HasColumnType("int");

                    b.Property<short>("Dex")
                        .HasColumnType("smallint");

                    b.Property<int>("Dhit")
                        .HasColumnType("int");

                    b.Property<float>("DistanceAttack")
                        .HasColumnType("real");

                    b.Property<short>("Hp")
                        .HasColumnType("smallint");

                    b.Property<short>("HpPotionRestore")
                        .HasColumnType("smallint");

                    b.Property<short>("HpRegen")
                        .HasColumnType("smallint");

                    b.Property<short>("HumanKiller")
                        .HasColumnType("smallint");

                    b.Property<short>("HumanProtect")
                        .HasColumnType("smallint");

                    b.Property<short>("Int")
                        .HasColumnType("smallint");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MDd")
                        .HasColumnType("int");

                    b.Property<int>("MDvMax")
                        .HasColumnType("int");

                    b.Property<int>("MDvMin")
                        .HasColumnType("int");

                    b.Property<int>("MPv")
                        .HasColumnType("int");

                    b.Property<int>("MaxStack")
                        .HasColumnType("int");

                    b.Property<int>("Mhit")
                        .HasColumnType("int");

                    b.Property<short>("MobKiller")
                        .HasColumnType("smallint");

                    b.Property<short>("MobProtect")
                        .HasColumnType("smallint");

                    b.Property<short>("MoveRate")
                        .HasColumnType("smallint");

                    b.Property<short>("MoveRateWhenTransform")
                        .HasColumnType("smallint");

                    b.Property<short>("Mp")
                        .HasColumnType("smallint");

                    b.Property<short>("MpPotionRestore")
                        .HasColumnType("smallint");

                    b.Property<short>("MpRegen")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RDd")
                        .HasColumnType("int");

                    b.Property<int>("RDvMax")
                        .HasColumnType("int");

                    b.Property<int>("RDvMin")
                        .HasColumnType("int");

                    b.Property<int>("RPv")
                        .HasColumnType("int");

                    b.Property<int>("Rhit")
                        .HasColumnType("int");

                    b.Property<short>("Str")
                        .HasColumnType("smallint");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("UseAssassin")
                        .HasColumnType("bit");

                    b.Property<long>("UseDelay")
                        .HasColumnType("bigint");

                    b.Property<bool>("UseInAttack")
                        .HasColumnType("bit");

                    b.Property<bool>("UseKnight")
                        .HasColumnType("bit");

                    b.Property<short>("UseLevel")
                        .HasColumnType("smallint");

                    b.Property<bool>("UseMagician")
                        .HasColumnType("bit");

                    b.Property<bool>("UseRanger")
                        .HasColumnType("bit");

                    b.Property<bool>("UseSummoner")
                        .HasColumnType("bit");

                    b.Property<short>("Weight")
                        .HasColumnType("smallint");

                    b.Property<short>("WeightMax")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Database.Balance.Models.UnitDropModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountFrom")
                        .HasColumnType("int");

                    b.Property<int>("CountTo")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("ItemId", "UnitId")
                        .IsUnique();

                    b.ToTable("UnitDrops");
                });

            modelBuilder.Entity("Database.Balance.Models.UnitModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AttackRate")
                        .HasColumnType("smallint");

                    b.Property<int>("DDd")
                        .HasColumnType("int");

                    b.Property<int>("DDvMax")
                        .HasColumnType("int");

                    b.Property<int>("DDvMin")
                        .HasColumnType("int");

                    b.Property<int>("DPv")
                        .HasColumnType("int");

                    b.Property<int>("Dhit")
                        .HasColumnType("int");

                    b.Property<float>("DistanceAggression")
                        .HasColumnType("real");

                    b.Property<float>("DistanceAttack")
                        .HasColumnType("real");

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<short>("HpMax")
                        .HasColumnType("smallint");

                    b.Property<short>("HpRegen")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsAggression")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAggressionTransformation")
                        .HasColumnType("bit");

                    b.Property<int>("MDd")
                        .HasColumnType("int");

                    b.Property<int>("MDvMax")
                        .HasColumnType("int");

                    b.Property<int>("MDvMin")
                        .HasColumnType("int");

                    b.Property<int>("MPv")
                        .HasColumnType("int");

                    b.Property<int>("Mhit")
                        .HasColumnType("int");

                    b.Property<short>("MoveRate")
                        .HasColumnType("smallint");

                    b.Property<short>("MpMax")
                        .HasColumnType("smallint");

                    b.Property<short>("MpRegen")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RDd")
                        .HasColumnType("int");

                    b.Property<int>("RDvMax")
                        .HasColumnType("int");

                    b.Property<int>("RDvMin")
                        .HasColumnType("int");

                    b.Property<int>("RPv")
                        .HasColumnType("int");

                    b.Property<short>("Reputation")
                        .HasColumnType("smallint");

                    b.Property<int>("Rhit")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId")
                        .IsUnique();

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Database.Balance.Models.UnitPositionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("DirectionSight")
                        .HasColumnType("real");

                    b.Property<int>("Respawn")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.Property<float>("Z")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("UnitPositions");
                });

            modelBuilder.Entity("Database.Balance.Models.UnitDropModel", b =>
                {
                    b.HasOne("Database.Balance.Models.ItemModel", "Item")
                        .WithMany("UnitDrops")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Balance.Models.UnitModel", "Unit")
                        .WithMany("UnitDrops")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Balance.Models.UnitPositionModel", b =>
                {
                    b.HasOne("Database.Balance.Models.UnitModel", "Unit")
                        .WithMany("UnitPositions")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
