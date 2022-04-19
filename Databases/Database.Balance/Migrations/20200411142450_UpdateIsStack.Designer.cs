﻿// <auto-generated />
using System;
using Database.Balance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Balance.Migrations
{
    [DbContext(typeof(DatabaseBalanceContext))]
    [Migration("20200411142450_UpdateIsStack")]
    partial class UpdateIsStack
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

            modelBuilder.Entity("Database.Balance.Models.ItemEquipModel", b =>
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

                    b.Property<bool>("IsStack")
                        .HasColumnType("bit");

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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("UseAssassin")
                        .HasColumnType("bit");

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

                    b.ToTable("ItemEquips");
                });

            modelBuilder.Entity("Database.Balance.Models.ItemMaterialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsStack")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.Property<short>("Weight")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ItemId", "ItemStatus")
                        .IsUnique();

                    b.ToTable("ItemMaterials");
                });

            modelBuilder.Entity("Database.Balance.Models.ItemReinforceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemEquipId")
                        .HasColumnType("int");

                    b.Property<int>("ItemMaterial1Id")
                        .HasColumnType("int");

                    b.Property<int?>("ItemMaterial2Id")
                        .HasColumnType("int");

                    b.Property<int?>("ItemMaterial3Id")
                        .HasColumnType("int");

                    b.Property<int>("Material1Count")
                        .HasColumnType("int");

                    b.Property<int?>("Material2Count")
                        .HasColumnType("int");

                    b.Property<int?>("Material3Count")
                        .HasColumnType("int");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ItemMaterial1Id");

                    b.HasIndex("ItemMaterial2Id");

                    b.HasIndex("ItemMaterial3Id");

                    b.HasIndex("ItemEquipId", "ItemMaterial1Id", "ItemMaterial2Id", "ItemMaterial3Id")
                        .IsUnique()
                        .HasFilter("[ItemMaterial2Id] IS NOT NULL AND [ItemMaterial3Id] IS NOT NULL");

                    b.ToTable("ItemReinforces");
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

                    b.Property<long>("EatTime")
                        .HasColumnType("bigint");

                    b.Property<int>("ItemBind")
                        .HasColumnType("int");

                    b.Property<int>("ItemEquipId")
                        .HasColumnType("int");

                    b.Property<int>("ItemStatus")
                        .HasColumnType("int");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.Property<int>("TermOfEffectivity")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<short>("UseCount")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("ItemEquipId", "UnitId")
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

                    b.Property<float>("DistanceMove")
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

            modelBuilder.Entity("Database.Balance.Models.ItemReinforceModel", b =>
                {
                    b.HasOne("Database.Balance.Models.ItemEquipModel", "ItemEquip")
                        .WithMany("ItemReinforces")
                        .HasForeignKey("ItemEquipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Balance.Models.ItemMaterialModel", "ItemMaterial1")
                        .WithMany("ItemReinforces1")
                        .HasForeignKey("ItemMaterial1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Balance.Models.ItemMaterialModel", "ItemMaterial2")
                        .WithMany("ItemReinforces2")
                        .HasForeignKey("ItemMaterial2Id");

                    b.HasOne("Database.Balance.Models.ItemMaterialModel", "ItemMaterial3")
                        .WithMany("ItemReinforces3")
                        .HasForeignKey("ItemMaterial3Id");
                });

            modelBuilder.Entity("Database.Balance.Models.UnitDropModel", b =>
                {
                    b.HasOne("Database.Balance.Models.ItemEquipModel", "ItemEquip")
                        .WithMany("UnitDrops")
                        .HasForeignKey("ItemEquipId")
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
