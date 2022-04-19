using Database.Parm.Interfaces;
using Database.Parm.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Parm
{
    /// <summary>
    ///     Database parm context
    /// </summary>
    public class ParmContext : DbContext, IParmContext
    {
        public ParmContext(DbContextOptions<ParmContext> options) : base(options)
        {
            //Database.Migrate();
        }

        public virtual DbSet<AbnormalModel> Abnormals { get; set; }
        public virtual DbSet<AbnormalAddModel> AbnormalAdds { get; set; }
        public virtual DbSet<AbnormalAttrApplyModel> AbnormalAttrApplys { get; set; }
        public virtual DbSet<AbnormalAttrAttachModel> AbnormalAttrAttaches { get; set; }
        public virtual DbSet<AbnormalAttrChangeAbnormalModel> AbnormalAttrChangeAbnormals { get; set; }
        public virtual DbSet<AbnormalAttrChangeEquipAbnormalModel> AbnormalAttrChangeEquipAbnormals { get; set; }
        public virtual DbSet<AbnormalAttrDetachModel> AbnormalAttrDetaches { get; set; }
        public virtual DbSet<AbnormalAttrIgnoreModel> AbnormalAttrIgnores { get; set; }
        public virtual DbSet<AbnormalModuleModel> AbnormalModules { get; set; }
        public virtual DbSet<AbnormalResistModel> AbnormalResists { get; set; }
        public virtual DbSet<AbnormalTypeModel> AbnormalTypes { get; set; }
        public virtual DbSet<AttributeModel> Attributes { get; set; }
        public virtual DbSet<AttributeAddModel> AttributeAdds { get; set; }
        public virtual DbSet<AttributeResistModel> AttributeResists { get; set; }
        public virtual DbSet<BeadModel> Beads { get; set; }
        public virtual DbSet<BeadEffectModel> BeadEffects { get; set; }
        public virtual DbSet<BeadEffectParmModel> BeadEffectParms { get; set; }
        public virtual DbSet<CharacterModel> Characters { get; set; }
        public virtual DbSet<CharacterPositionModel> CharacterPositions { get; set; }
        public virtual DbSet<DialogModel> Dialogs { get; set; }
        public virtual DbSet<DialogScriptModel> DialogScripts { get; set; }
        public virtual DbSet<DropGroupModel> DropGroups { get; set; }
        public virtual DbSet<DropItemModel> DropItems { get; set; }
        public virtual DbSet<ExpModel> Exps { get; set; }
        public virtual DbSet<FullMoonMonsterListModel> FullMoonMonsterList { get; set; }
        public virtual DbSet<ItemModel> Items { get; set; }
        public virtual DbSet<ItemAbnormalAddModel> ItemAbnormalAdds { get; set; }
        public virtual DbSet<ItemAbnormalResistModel> ItemAbnormalResists { get; set; }
        public virtual DbSet<ItemAttributeAddModel> ItemAttributeAdds { get; set; }
        public virtual DbSet<ItemBeadEffectModel> ItemBeadEffects { get; set; }
        public virtual DbSet<ItemBeadModuleModel> ItemBeadModules { get; set; }
        public virtual DbSet<ItemMEndDateModel> ItemMEndDates { get; set; }
        public virtual DbSet<ItemPanaltyModel> ItemPanalties { get; set; }
        public virtual DbSet<ItemProtectModel> ItemProtects { get; set; }
        public virtual DbSet<ItemSkillModel> ItemSkills { get; set; }
        public virtual DbSet<ItemSlainModel> ItemSlains { get; set; }
        public virtual DbSet<MaterialDrawAddGroupModel> MaterialDrawAddGroups { get; set; }
        public virtual DbSet<MaterialDrawIndexModel> MaterialDrawIndexes { get; set; }
        public virtual DbSet<MaterialDrawMaterialModel> MaterialDrawMaterials { get; set; }
        public virtual DbSet<MaterialDrawResultModel> MaterialDrawResults { get; set; }
        public virtual DbSet<MaterialEnchantProbabilityModel> MaterialEnchantProbabilities { get; set; }
        public virtual DbSet<MaterialEvolutionGradeModel> MaterialEvolutionGrades { get; set; }
        public virtual DbSet<MaterialEvolutionMaterialModel> MaterialEvolutionMaterials { get; set; }
        public virtual DbSet<MaterialEvolutionResultModel> MaterialEvolutionResults { get; set; }
        public virtual DbSet<MaterialItemInfoModel> MaterialItemInfos { get; set; }
        public virtual DbSet<MerchantSellListModel> MerchantSellLists { get; set; }
        public virtual DbSet<ModuleModel> Modules { get; set; }
        public virtual DbSet<ModuleTypeModel> ModuleTypes { get; set; }
        public virtual DbSet<MonsterModel> Monsters { get; set; }
        public virtual DbSet<MonsterAbnormalAddModel> MonsterAbnormalAdds { get; set; }
        public virtual DbSet<MonsterAbnormalResistModel> MonsterAbnormalResists { get; set; }
        public virtual DbSet<MonsterAttributeAddModel> MonsterAttributeAdds { get; set; }
        public virtual DbSet<MonsterAttributeResistModel> MonsterAttributeResists { get; set; }
        public virtual DbSet<MonsterDropModel> MonsterDrops { get; set; }
        public virtual DbSet<MonsterRoleModel> MonsterRoles { get; set; }
        public virtual DbSet<MonsterSlainModel> MonsterSlains { get; set; }
        public virtual DbSet<MonsterSpotModel> MonsterSpots { get; set; }
        public virtual DbSet<MonsterSpotGroupModel> MonsterSpotGroups { get; set; }
        public virtual DbSet<ProtectModel> Protects { get; set; }
        public virtual DbSet<QuestModel> Quests { get; set; }
        public virtual DbSet<QuestConditionModel> QuestConditions { get; set; }
        public virtual DbSet<QuestInfoModel> QuestInfos { get; set; }
        public virtual DbSet<QuestRefMonsterModel> QuestRefMonsters { get; set; }
        public virtual DbSet<QuestRewardModel> QuestRewards { get; set; }
        public virtual DbSet<RefineModel> Refines { get; set; }
        public virtual DbSet<RefineCreateInfoModel> RefineCreateInfos { get; set; }
        public virtual DbSet<RefineMaterialModel> RefineMaterials { get; set; }
        public virtual DbSet<RegionOptionModel> RegionOptions { get; set; }
        public virtual DbSet<RegionQuestModel> RegionQuests { get; set; }
        public virtual DbSet<RegionQuestConditionModel> RegionQuestConditions { get; set; }
        public virtual DbSet<RegionQuestPlaceModel> RegionQuestPlaces { get; set; }
        public virtual DbSet<RoomInfoModel> RoomInfos { get; set; }
        public virtual DbSet<SkillModel> Skills { get; set; }
        public virtual DbSet<SkillAbnormalModel> SkillAbnormals { get; set; }
        public virtual DbSet<SkillAttributeModel> SkillAttributes { get; set; }
        public virtual DbSet<SkillEnhancementModel> SkillEnhancements { get; set; }
        public virtual DbSet<SkillEnhancementMaterialModel> SkillEnhancementMaterials { get; set; }
        public virtual DbSet<SkillIgnoreCastingDelayGroupModel> SkillIgnoreCastingDelayGroups { get; set; }
        public virtual DbSet<SkillIgnoreCoolTimeGroupModel> SkillIgnoreCoolTimeGroups { get; set; }
        public virtual DbSet<SkillPackModel> SkillPacks { get; set; }
        public virtual DbSet<SkillPackSkillModel> SkillPackSkills { get; set; }
        public virtual DbSet<SkillResourceModel> SkillResources { get; set; }
        public virtual DbSet<SkillSlainModel> SkillSlains { get; set; }
        public virtual DbSet<SkillTreeNodeModel> SkillTreeNodes { get; set; }
        public virtual DbSet<SkillTreeNodeItemModel> SkillTreeNodeItems { get; set; }
        public virtual DbSet<SkillTreeNodeItemConditionModel> SkillTreeNodeItemConditions { get; set; }
        public virtual DbSet<SkillTypeModel> SkillTypes { get; set; }
        public virtual DbSet<SlainModel> Slains { get; set; }
        public virtual DbSet<SlainTypeModel> SlainTypes { get; set; }
        public virtual DbSet<TransformAbilityByLevelModel> TransformAbilityByLevels { get; set; }
        public virtual DbSet<TransformListModel> TransformLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=localhost;Database=R2_Database_Balance;Trusted_Connection=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<AbnormalModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Abnormal");
                entity.Property(e => e.Desc)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Time).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AbnormalAddModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("AbnormalAdd");
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<AbnormalAttrApplyModel>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("UCL_PK_DT_AbnormalAttrApply");
                entity.ToTable("AbnormalAttrApply");
                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("mID");
                entity.Property(e => e.MConditionAid).HasColumnName("mConditionAID");
                entity.Property(e => e.MDesc)
                    .HasMaxLength(200)
                    .HasColumnName("mDesc")
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.MOriginAid).HasColumnName("mOriginAID");
                entity.Property(e => e.MOriginAtype).HasColumnName("mOriginAType");
            });

            modelBuilder.Entity<AbnormalAttrAttachModel>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("UCL_PK_DT_AbnormalAttrAttach");
                entity.ToTable("AbnormalAttrAttach");
                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("mID");
                entity.Property(e => e.MConditionAtype).HasColumnName("mConditionAType");
                entity.Property(e => e.MConditionType).HasColumnName("mConditionType");
                entity.Property(e => e.MDesc)
                    .HasMaxLength(200)
                    .HasColumnName("mDesc")
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.MEffectAid).HasColumnName("mEffectAID");
                entity.Property(e => e.MOriginAid).HasColumnName("mOriginAID");
            });

            modelBuilder.Entity<AbnormalAttrChangeAbnormalModel>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("UCL_PK_DT_AbnormalAttrChangeAbnormal");
                entity.ToTable("AbnormalAttrChangeAbnormal");
                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("mID");
                entity.Property(e => e.MConditionAid).HasColumnName("mConditionAID");
                entity.Property(e => e.MConditionAtype).HasColumnName("mConditionAType");
                entity.Property(e => e.MConditionType).HasColumnName("mConditionType");
                entity.Property(e => e.MDesc)
                    .HasMaxLength(200)
                    .HasColumnName("mDesc")
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.MEffectAid).HasColumnName("mEffectAID");
                entity.Property(e => e.MOriginAid).HasColumnName("mOriginAID");
            });

            modelBuilder.Entity<AbnormalAttrChangeEquipAbnormalModel>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("UCL_PK_DT_AbnormalAttrChangeEquipAbnormal");
                entity.ToTable("AbnormalAttrChangeEquipAbnormal");
                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("mID");
                entity.Property(e => e.MConditionAid).HasColumnName("mConditionAID");
                entity.Property(e => e.MDesc)
                    .HasMaxLength(200)
                    .HasColumnName("mDesc")
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.MEffectAid).HasColumnName("mEffectAID");
                entity.Property(e => e.MOriginAitemNo).HasColumnName("mOriginAItemNo");
                entity.Property(e => e.MOriginAtype).HasColumnName("mOriginAType");
            });

            modelBuilder.Entity<AbnormalAttrDetachModel>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("UCL_PK_DT_AbnormalAttrDetach");
                entity.ToTable("AbnormalAttrDetach");
                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("mID");
                entity.Property(e => e.MAppType).HasColumnName("mAppType");
                entity.Property(e => e.MConditionAtype).HasColumnName("mConditionAType");
                entity.Property(e => e.MConditionType).HasColumnName("mConditionType");
                entity.Property(e => e.MDesc)
                    .HasMaxLength(200)
                    .HasColumnName("mDesc")
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.MEffectAid).HasColumnName("mEffectAID");
                entity.Property(e => e.MEffectAtype).HasColumnName("mEffectAType");
                entity.Property(e => e.MOriginAid).HasColumnName("mOriginAID");
            });

            modelBuilder.Entity<AbnormalAttrIgnoreModel>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("UCL_PK_DT_AbnormalAttrIgnore");
                entity.ToTable("AbnormalAttrIgnore");
                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("mID");
                entity.Property(e => e.MConditionAid).HasColumnName("mConditionAID");
                entity.Property(e => e.MConditionAtype).HasColumnName("mConditionAType");
                entity.Property(e => e.MConditionType).HasColumnName("mConditionType");
                entity.Property(e => e.MDesc)
                    .HasMaxLength(200)
                    .HasColumnName("mDesc")
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.MIsComplex).HasColumnName("mIsComplex");
                entity.Property(e => e.MOriginAid).HasColumnName("mOriginAID");
            });

            modelBuilder.Entity<AbnormalModuleModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("AbnormalModule");
                entity.Property(e => e.AbnormalId).HasColumnName("AbnormalID");
                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            });

            modelBuilder.Entity<AbnormalResistModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("AbnormalResist");
                entity.Property(e => e.Id).HasColumnName("AID");
                entity.Property(e => e.Level).HasColumnName("ALevel");
                entity.Property(e => e.Percent).HasColumnName("APercent");
                entity.Property(e => e.Type).HasColumnName("AType");
            });

            modelBuilder.Entity<AbnormalTypeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("AbnormalType");
                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<AttributeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Attribute");
                entity.Property(e => e.DiceDamage).HasMaxLength(10);
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<AttributeAddModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("AttributeAdd");
                entity.Property(e => e.DiceDamage).HasMaxLength(10);
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<AttributeResistModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("AttributeResist");
                entity.Property(e => e.DiceDamage).HasMaxLength(10);
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<BeadModel>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("CL_PK_Bead_ItemID");
                entity.ToTable("Bead");
                entity.Property(e => e.ItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("ItemID");
                entity.Property(e => e.TargetIpos).HasColumnName("TargetIPos");
            });

            modelBuilder.Entity<BeadEffectModel>(entity =>
            {
                entity.HasKey(e => e.BeadNo)
                    .HasName("CL_PK_BeadEffect_BeadNo");
                entity.ToTable("BeadEffect");
                entity.Property(e => e.BeadNo).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<BeadEffectParmModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("BeadEffectParm");
                entity.HasIndex(e => new { e.BeadNo, e.OrderNo }, "UNC_DT_BeadEffectParm_BeadNo_OrderNo")
                    .IsUnique();
            });

            modelBuilder.Entity<CharacterModel>(entity =>
            {
                entity.HasIndex(e => new { e.Class, e.Level }, "IX_Characters_Class_Level")
                    .IsUnique();
                entity.Property(e => e.DDd).HasColumnName("DDd");
                entity.Property(e => e.DDvMax).HasColumnName("DDvMax");
                entity.Property(e => e.DDvMin).HasColumnName("DDvMin");
                entity.Property(e => e.DPv).HasColumnName("DPv");
                entity.Property(e => e.MDd).HasColumnName("MDd");
                entity.Property(e => e.MDvMax).HasColumnName("MDvMax");
                entity.Property(e => e.MDvMin).HasColumnName("MDvMin");
                entity.Property(e => e.MPv).HasColumnName("MPv");
                entity.Property(e => e.RDd).HasColumnName("RDd");
                entity.Property(e => e.RDvMax).HasColumnName("RDvMax");
                entity.Property(e => e.RDvMin).HasColumnName("RDvMin");
                entity.Property(e => e.RPv).HasColumnName("RPv");
            });

            modelBuilder.Entity<CharacterPositionModel>(entity =>
            {
                entity.HasIndex(e => e.Class, "IX_CharacterPositions_Class")
                    .IsUnique();
            });

            modelBuilder.Entity<DialogModel>(entity =>
            {
                entity.HasKey(e => e.MonsterId);
                entity.ToTable("Dialog");
                entity.Property(e => e.MonsterId).ValueGeneratedNever();
                entity.Property(e => e.Attacked)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Bear)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Click)
                    .HasMaxLength(7000)
                    .IsUnicode(false);
                entity.Property(e => e.Die)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Gossip1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Gossip2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Gossip3)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Gossip4)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.UptDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DialogScriptModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("DialogScript");
                entity.Property(e => e.RegDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ScriptText)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.UptDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DropGroupModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("DropGroup");
            });

            modelBuilder.Entity<DropItemModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("DropItem");
                entity.Property(e => e.Id).HasColumnName("DropItemId");
                entity.Property(e => e.ItemId).HasColumnName("Item");
                entity.Property(e => e.Count).HasColumnName("Count");
                entity.Property(e => e.Status).HasColumnName("Status");
                entity.Property(e => e.IsEvent).HasColumnName("IsEvent");
            });

            modelBuilder.Entity<ExpModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Exp");
                entity.Property(e => e.Exp).HasColumnName("Exp");
                entity.Property(e => e.RestExpRate).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FullMoonMonsterListModel>(entity =>
            {
                entity.HasKey(e => new { e.MonsterId, e.IsFullMoon })
                    .HasName("UCL_PK_FullMoonMonsterList");
                entity.ToTable("FullMoonMonsterList");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<ItemModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Item");
                entity.Property(e => e.AddDdwhenCritical).HasColumnName("AddDDWhenCritical");
                entity.Property(e => e.DDd)
                    .HasMaxLength(10)
                    .HasColumnName("DDD");
                entity.Property(e => e.DDv).HasColumnName("DDV");
                entity.Property(e => e.Desc).HasMaxLength(200);
                entity.Property(e => e.Dex).HasColumnName("DEX");
                entity.Property(e => e.Dhit).HasColumnName("DHIT");
                entity.Property(e => e.DPv).HasColumnName("DPV");
                entity.Property(e => e.FakeId).HasColumnName("FakeID");
                entity.Property(e => e.FakeName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.GetItemFeedback).HasDefaultValueSql("((1))");
                entity.Property(e => e.Hddv).HasColumnName("HDDV");
                entity.Property(e => e.Hdpv).HasColumnName("HDPV");
                entity.Property(e => e.Hmdv).HasColumnName("HMDV");
                entity.Property(e => e.Hmpv).HasColumnName("HMPV");
                entity.Property(e => e.HpPlus).HasColumnName("HPPlus");
                entity.Property(e => e.HpRegen).HasColumnName("HPRegen");
                entity.Property(e => e.Hrdv).HasColumnName("HRDV");
                entity.Property(e => e.Hrpv).HasColumnName("HRPV");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Int).HasColumnName("INT");
                entity.Property(e => e.IsUseableUtgwsvr).HasColumnName("IsUseableUTGWSvr");
                entity.Property(e => e.Mdd)
                    .HasMaxLength(10)
                    .HasColumnName("MDD");
                entity.Property(e => e.MDv).HasColumnName("MDV");
                entity.Property(e => e.Mhit).HasColumnName("MHIT");
                entity.Property(e => e.Mpplus).HasColumnName("MPPlus");
                entity.Property(e => e.Mpregen).HasColumnName("MPRegen");
                entity.Property(e => e.MPv).HasColumnName("MPV");
                entity.Property(e => e.Name).HasMaxLength(40);
                entity.Property(e => e.PshopItemType).HasColumnName("PShopItemType");
                entity.Property(e => e.Rdd)
                    .HasMaxLength(50)
                    .HasColumnName("RDD");
                entity.Property(e => e.RDv).HasColumnName("RDV");
                entity.Property(e => e.Rhit).HasColumnName("RHIT");
                entity.Property(e => e.RPv).HasColumnName("RPV");
                entity.Property(e => e.Str).HasColumnName("STR");
                entity.Property(e => e.SubDdwhenCritical).HasColumnName("SubDDWhenCritical");
                entity.Property(e => e.TermOfValidityMi).HasDefaultValueSql("((0))");
                entity.Property(e => e.UseMsg)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ItemAbnormalAddModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemAbnormalAdd");
                entity.Property(e => e.AbnormalId).HasColumnName("Abnormal_ID");
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            });

            modelBuilder.Entity<ItemAbnormalResistModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemAbnormalResist");
                entity.Property(e => e.AbnormalId).HasColumnName("Abnormal_ID");
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            });

            modelBuilder.Entity<ItemAttributeAddModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemAttributeAdd");
                entity.Property(e => e.AttributeId).HasColumnName("Attribute_ID");
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            });

            modelBuilder.Entity<ItemBeadEffectModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemBeadEffect");
                entity.HasIndex(e => new { e.ItemId, e.BeadNo }, "UNC_ItemBeadEffect_ID_mBeadNo")
                    .IsUnique();
                entity.Property(e => e.ItemId).HasColumnName("ID");
            });

            modelBuilder.Entity<ItemBeadModuleModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemBeadModule");
                entity.HasIndex(e => new { e.ItemId, e.ModuleId }, "UNC_ItemBeadModule_Item_ID_Module_ID")
                    .IsUnique();
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
                entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
            });

            modelBuilder.Entity<ItemMEndDateModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Item_mEndDate");
                entity.Property(e => e.AddDdwhenCritical).HasColumnName("AddDDWhenCritical");
                entity.Property(e => e.Ddd)
                    .HasMaxLength(10)
                    .HasColumnName("DDD");
                entity.Property(e => e.Ddv).HasColumnName("DDV");
                entity.Property(e => e.Desc).HasMaxLength(200);
                entity.Property(e => e.Dex).HasColumnName("DEX");
                entity.Property(e => e.Dhit).HasColumnName("DHIT");
                entity.Property(e => e.Dpv).HasColumnName("DPV");
                entity.Property(e => e.FakeId).HasColumnName("FakeID");
                entity.Property(e => e.FakeName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.Hddv).HasColumnName("HDDV");
                entity.Property(e => e.Hdpv).HasColumnName("HDPV");
                entity.Property(e => e.Hmdv).HasColumnName("HMDV");
                entity.Property(e => e.Hmpv).HasColumnName("HMPV");
                entity.Property(e => e.Hpplus).HasColumnName("HPPlus");
                entity.Property(e => e.Hpregen).HasColumnName("HPRegen");
                entity.Property(e => e.Hrdv).HasColumnName("HRDV");
                entity.Property(e => e.Hrpv).HasColumnName("HRPV");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Int).HasColumnName("INT");
                entity.Property(e => e.IsUseableUtgwsvr).HasColumnName("IsUseableUTGWSvr");
                entity.Property(e => e.Mdd)
                    .HasMaxLength(10)
                    .HasColumnName("MDD");
                entity.Property(e => e.Mdv).HasColumnName("MDV");
                entity.Property(e => e.Mhit).HasColumnName("MHIT");
                entity.Property(e => e.Mpplus).HasColumnName("MPPlus");
                entity.Property(e => e.Mpregen).HasColumnName("MPRegen");
                entity.Property(e => e.Mpv).HasColumnName("MPV");
                entity.Property(e => e.Name).HasMaxLength(40);
                entity.Property(e => e.PshopItemType).HasColumnName("PShopItemType");
                entity.Property(e => e.Rdd)
                    .HasMaxLength(50)
                    .HasColumnName("RDD");
                entity.Property(e => e.Rdv).HasColumnName("RDV");
                entity.Property(e => e.Rhit).HasColumnName("RHIT");
                entity.Property(e => e.Rpv).HasColumnName("RPV");
                entity.Property(e => e.Str).HasColumnName("STR");
                entity.Property(e => e.SubDdwhenCritical).HasColumnName("SubDDWhenCritical");
                entity.Property(e => e.UseMsg)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ItemPanaltyModel>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.UseClass })
                    .HasName("UCL_ItemPanalty");
                entity.ToTable("ItemPanalty");
                entity.Property(e => e.ItemId).HasColumnName("ID");
                entity.Property(e => e.AttackRate).HasDefaultValueSql("((0))");
                entity.Property(e => e.Critical).HasDefaultValueSql("((0))");
                entity.Property(e => e.DDd)
                    .HasMaxLength(10)
                    .HasColumnName("DDD")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.DDv).HasColumnName("DDV");
                entity.Property(e => e.Dex)
                    .HasColumnName("DEX")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.DHit)
                    .HasColumnName("DHIT")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.DPv).HasColumnName("DPV");
                entity.Property(e => e.HDDv).HasColumnName("HDDV");
                entity.Property(e => e.HDPv).HasColumnName("HDPV");
                entity.Property(e => e.HMDv).HasColumnName("HMDV");
                entity.Property(e => e.HMPv).HasColumnName("HMPV");
                entity.Property(e => e.HPPlus)
                    .HasColumnName("HPPlus")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.HPregen)
                    .HasColumnName("HPRegen")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.HRDv).HasColumnName("HRDV");
                entity.Property(e => e.HRPv).HasColumnName("HRPV");
                entity.Property(e => e.Int)
                    .HasColumnName("INT")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.MDd)
                    .HasMaxLength(10)
                    .HasColumnName("MDD")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.MDv).HasColumnName("MDV");
                entity.Property(e => e.MHit)
                    .HasColumnName("MHIT")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.MoveRate).HasDefaultValueSql("((0))");
                entity.Property(e => e.MPPlus)
                    .HasColumnName("MPPlus")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.MPregen)
                    .HasColumnName("MPRegen")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.MPv).HasColumnName("MPV");
                entity.Property(e => e.RDd)
                    .HasMaxLength(50)
                    .HasColumnName("RDD")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.RDv).HasColumnName("RDV");
                entity.Property(e => e.RHit)
                    .HasColumnName("RHIT")
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.RPv).HasColumnName("RPV");
                entity.Property(e => e.Str)
                    .HasColumnName("STR")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ItemProtectModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemProtect");
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
                entity.Property(e => e.ProtectId).HasColumnName("Protect_ID");
            });

            modelBuilder.Entity<ItemSkillModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemSkill");
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
                entity.Property(e => e.SkillId).HasColumnName("Skill_ID");
                entity.Property(e => e.SkillOrderNo).HasColumnName("Skill_OrderNO");
            });

            modelBuilder.Entity<ItemSlainModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ItemSlain");
                entity.Property(e => e.ItemId).HasColumnName("Item_ID");
                entity.Property(e => e.SlainId).HasColumnName("SkillSlain_ID");
            });

            modelBuilder.Entity<MaterialDrawAddGroupModel>(entity =>
            {
                entity.HasKey(e => new { e.Mdrd, e.AddGroup })
                    .HasName("UCL_MaterialDrawAddGroup_MDRD");
                entity.ToTable("MaterialDrawAddGroup");
                entity.Property(e => e.Mdrd).HasColumnName("MDRD");
                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaterialDrawIndexModel>(entity =>
            {
                entity.HasKey(e => e.Mdid)
                    .HasName("UCL_MaterialDrawIndex_MDID");
                entity.ToTable("MaterialDrawIndex");
                entity.Property(e => e.Mdid)
                    .ValueGeneratedNever()
                    .HasColumnName("MDID");
                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(e => e.Mdrd).HasColumnName("MDRD");
            });

            modelBuilder.Entity<MaterialDrawMaterialModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MaterialDrawMaterial");
                entity.Property(e => e.ItemId).HasColumnName("ItemID");
                entity.Property(e => e.Mdid).HasColumnName("MDID");
            });

            modelBuilder.Entity<MaterialDrawResultModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MaterialDrawResult");
                entity.Property(e => e.Cnt).HasDefaultValueSql("((1))");
                entity.Property(e => e.ItemId).HasColumnName("ItemID");
                entity.Property(e => e.ItemStatus).HasDefaultValueSql("((1))");
                entity.Property(e => e.Mdrd).HasColumnName("MDRD");
                entity.Property(e => e.ValTime).HasDefaultValueSql("((10000))");
            });

            modelBuilder.Entity<MaterialEnchantProbabilityModel>(entity =>
            {
                entity.HasKey(e => e.Menchant)
                    .HasName("UCL_MaterialReinforce_MEnchant");
                entity.ToTable("MaterialEnchantProbability");
                entity.Property(e => e.Menchant)
                    .ValueGeneratedNever()
                    .HasColumnName("MEnchant");
                entity.Property(e => e.MaddValue).HasColumnName("MAddValue");
                entity.Property(e => e.MreinforceFail).HasColumnName("MReinforceFail");
            });

            modelBuilder.Entity<MaterialEvolutionGradeModel>(entity =>
            {
                entity.HasKey(e => e.Mgrade)
                    .HasName("UCL_MaterialEvolutionGrade_MGrade");
                entity.ToTable("MaterialEvolutionGrade");
                entity.Property(e => e.Mgrade)
                    .ValueGeneratedNever()
                    .HasColumnName("MGrade");
                entity.Property(e => e.MprobabilityAdd).HasColumnName("MProbabilityAdd");
            });

            modelBuilder.Entity<MaterialEvolutionMaterialModel>(entity =>
            {
                entity.HasKey(e => e.Meid)
                    .HasName("UCL_PK_MaterialEvolutionMaterial");
                entity.ToTable("MaterialEvolutionMaterial");
                entity.Property(e => e.Meid)
                    .ValueGeneratedNever()
                    .HasColumnName("MEID");
                entity.Property(e => e.MSuccess).HasColumnName("mSuccess");
                entity.Property(e => e.Mgrade).HasColumnName("MGrade");
                entity.Property(e => e.Mlevel).HasColumnName("MLevel");
                entity.Property(e => e.Mtype).HasColumnName("MType");
            });

            modelBuilder.Entity<MaterialEvolutionResultModel>(entity =>
            {
                entity.HasKey(e => new { e.Meid, e.ItemId })
                    .HasName("UCL_PK_MaterialEvolutionResult");
                entity.ToTable("MaterialEvolutionResult");
                entity.Property(e => e.Meid).HasColumnName("MEID");
                entity.Property(e => e.ItemId).HasColumnName("ItemID");
                entity.Property(e => e.MPercent).HasColumnName("mPercent");
            });

            modelBuilder.Entity<MaterialItemInfoModel>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("UCL_PK_MaterialItemInfo");
                entity.ToTable("MaterialItemInfo");
                entity.Property(e => e.ItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("ItemID");
                entity.Property(e => e.Menchant).HasColumnName("MEnchant");
                entity.Property(e => e.Mgrade).HasColumnName("MGrade");
                entity.Property(e => e.Mlevel).HasColumnName("MLevel");
                entity.Property(e => e.Mtype).HasColumnName("MType");
            });

            modelBuilder.Entity<MerchantSellListModel>(entity =>
            {
                entity.HasKey(e => new { e.ListId, e.ItemId, e.Flag, e.SortKey })
                    .HasName("PK__Merchant__DD0DDB2DCD4C109C");
                entity.ToTable("MerchantSellList");
                entity.Property(e => e.ListId).HasColumnName("ListID");
                entity.Property(e => e.ItemId).HasColumnName("ItemID");
                entity.Property(e => e.MIndex).HasColumnName("mIndex");
            });

            modelBuilder.Entity<ModuleModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Module");
                entity.Property(e => e.AParam).HasColumnName("AParam");
                entity.Property(e => e.BParam).HasColumnName("BParam");
                entity.Property(e => e.CParam).HasColumnName("CParam");
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ModuleTypeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ModuleType");
                entity.Property(e => e.AparamName)
                    .HasMaxLength(40)
                    .HasColumnName("AParamName")
                    .UseCollation("Chinese_PRC_CI_AS");
                entity.Property(e => e.BparamName)
                    .HasMaxLength(40)
                    .HasColumnName("BParamName")
                    .UseCollation("Chinese_PRC_CI_AS");
                entity.Property(e => e.CparamName)
                    .HasMaxLength(40)
                    .HasColumnName("CParamName")
                    .UseCollation("Chinese_PRC_CI_AS");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Chinese_PRC_CI_AS");
                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .UseCollation("Chinese_PRC_CI_AS");
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<MonsterModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Monster");
                entity.Property(e => e.BuyMerchanId).HasColumnName("BuyMerchanID");
                entity.Property(e => e.ChargeMerchanId).HasColumnName("ChargeMerchanID");
                entity.Property(e => e.DDv).HasColumnName("DDV");
                entity.Property(e => e.DPv).HasColumnName("DPV");
                entity.Property(e => e.Hit).HasColumnName("HIT");
                entity.Property(e => e.Hp).HasColumnName("HP");
                entity.Property(e => e.HpNew).HasColumnName("HPNew");
                entity.Property(e => e.HpRegen).HasColumnName("HPRegen");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.MDv).HasColumnName("MDV");
                entity.Property(e => e.Mp).HasColumnName("MP");
                entity.Property(e => e.MpNew).HasColumnName("MPNew");
                entity.Property(e => e.MpRegen).HasColumnName("MPRegen");
                entity.Property(e => e.MPv).HasColumnName("MPV");
                entity.Property(e => e.Name).HasMaxLength(40);
                entity.Property(e => e.RDv).HasColumnName("RDV");
                entity.Property(e => e.RPv).HasColumnName("RPV");
                entity.Property(e => e.SellMerchanId).HasColumnName("SellMerchanID");
                entity.Property(e => e.SubDDwhenCritical).HasColumnName("SubDDWhenCritical");
                entity.Property(e => e.WmapIconType).HasColumnName("WMapIconType");
            });

            modelBuilder.Entity<MonsterAbnormalAddModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterAbnormalAdd");
                entity.Property(e => e.AbnormalId).HasColumnName("AbnormalID");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<MonsterAbnormalResistModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterAbnormalResist");
                entity.Property(e => e.AbnormalId).HasColumnName("AbnormalID");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<MonsterAttributeAddModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterAttributeAdd");
                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<MonsterAttributeResistModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterAttributeResist");
                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<MonsterDropModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterDrop");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<MonsterRoleModel>(entity =>
            {
                entity.HasKey(e => new { e.MonsterId, e.MonsterRole })
                    .HasName("PK_DT_MonsterRole_MonsterID_Role");
                entity.ToTable("MonsterRole");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
                entity.Property(e => e.MonsterRole).HasColumnName("MonsterRole");
            });

            modelBuilder.Entity<MonsterSlainModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterSlain");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
                entity.Property(e => e.SlainId).HasColumnName("SlainID");
            });

            modelBuilder.Entity<MonsterSpotModel>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.MonsterId })
                    .HasName("PK_MonsterRespwan");
                entity.ToTable("MonsterSpot");
                entity.Property(e => e.GroupId).HasColumnName("GID");
                entity.Property(e => e.MonsterId).HasColumnName("MID");
            });

            modelBuilder.Entity<MonsterSpotGroupModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("MonsterSpotGroup");
                entity.Property(e => e.GId).HasColumnName("GID");
            });

            modelBuilder.Entity<ProtectModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Protect");
                entity.Property(e => e.DDv).HasColumnName("SDDV");
                entity.Property(e => e.DPv).HasColumnName("SDPV");
                entity.Property(e => e.Id).HasColumnName("SID");
                entity.Property(e => e.Level).HasColumnName("SLevel");
                entity.Property(e => e.MDv).HasColumnName("SMDV");
                entity.Property(e => e.MPv).HasColumnName("SMPV");
                entity.Property(e => e.RDv).HasColumnName("SRDV");
                entity.Property(e => e.RPv).HasColumnName("SRPV");
                entity.Property(e => e.Type).HasColumnName("SType");
            });

            modelBuilder.Entity<QuestModel>(entity =>
            {
                entity.HasKey(e => e.QuestNo)
                    .HasName("PK_CL_Quest");
                entity.ToTable("Quest");
                entity.Property(e => e.QuestNo).ValueGeneratedNever();
                entity.Property(e => e.CompletionNpc).HasColumnName("CompletionNPC");
                entity.Property(e => e.Difficulty).HasDefaultValueSql("((1))");
                entity.Property(e => e.FindNpc).HasColumnName("FindNPC");
                entity.Property(e => e.Level2).HasDefaultValueSql("((0))");
                entity.Property(e => e.QuestDesc).HasMaxLength(30);
                entity.Property(e => e.QuestNm)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(' ')");
                entity.Property(e => e.TextNo).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<QuestConditionModel>(entity =>
            {
                entity.HasKey(e => new { e.QuestNo, e.Type, e.Id })
                    .HasName("UCL_PK_QuestCondition_QuestNo");
                entity.ToTable("QuestCondition");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Desc)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestInfoModel>(entity =>
            {
                entity.HasKey(e => new { e.QuestNo, e.Type })
                    .HasName("UCL_PK_QuestInfo_QuestNo");
                entity.ToTable("QuestInfo");
                entity.Property(e => e.Desc)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ParmA).HasDefaultValueSql("((0))");
                entity.Property(e => e.ParmB).HasDefaultValueSql("((0))");
                entity.Property(e => e.ParmC).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<QuestRefMonsterModel>(entity =>
            {
                entity.HasKey(e => new { e.QuestNo, e.MonsterId })
                    .HasName("PK_CL_QuestRefMonster");
                entity.ToTable("QuestRefMonster");
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");
            });

            modelBuilder.Entity<QuestRewardModel>(entity =>
            {
                entity.HasKey(e => new { e.RewardNo, e.Exp, e.Id })
                    .HasName("UCL_PK_QuestReward_RewardNo");
                entity.ToTable("QuestReward");
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<RefineModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Refine");
                entity.Property(e => e.ItemId0).HasColumnName("ItemID0");
                entity.Property(e => e.ItemId1).HasColumnName("ItemID1");
                entity.Property(e => e.ItemId2).HasColumnName("ItemID2");
                entity.Property(e => e.ItemId3).HasColumnName("ItemID3");
                entity.Property(e => e.ItemId4).HasColumnName("ItemID4");
                entity.Property(e => e.ItemId5).HasColumnName("ItemID5");
                entity.Property(e => e.ItemId6).HasColumnName("ItemID6");
                entity.Property(e => e.ItemId7).HasColumnName("ItemID7");
                entity.Property(e => e.ItemId8).HasColumnName("ItemID8");
                entity.Property(e => e.ItemId9).HasColumnName("ItemID9");
                entity.Property(e => e.RefineId).HasColumnName("RefineID");
                entity.Property(e => e.Success).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<RefineCreateInfoModel>(entity =>
            {
                entity.HasKey(e => e.Idx)
                    .HasName("UCL_PK_IDX");
                entity.ToTable("RefineCreateInfo");
                entity.Property(e => e.Idx)
                    .ValueGeneratedNever()
                    .HasColumnName("IDX");
                entity.Property(e => e.RefineId).HasColumnName("RefineID");
            });

            modelBuilder.Entity<RefineMaterialModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("RefineMaterial");
                entity.Property(e => e.ItemId).HasColumnName("ItemID");
                entity.Property(e => e.OrderNo).HasDefaultValueSql("((1))");
                entity.Property(e => e.RefineId).HasColumnName("RefineID");
            });

            modelBuilder.Entity<RegionOptionModel>(entity =>
            {
                entity.HasKey(e => e.Place)
                    .HasName("PK__RegionOp__8310F9986B334A80");
                entity.Property(e => e.Place).ValueGeneratedNever();
                entity.Property(e => e.MonSilverDropRate).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<RegionQuestModel>(entity =>
            {
                entity.HasKey(e => e.QuestNo)
                    .HasName("PK_CL_RegionQuest");
                entity.ToTable("RegionQuest");
                entity.Property(e => e.QuestNo).ValueGeneratedNever();
                entity.Property(e => e.QuestNm)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.QuestNmKey)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<RegionQuestConditionModel>(entity =>
            {
                entity.HasKey(e => new { e.QuestNo, e.ParmId })
                    .HasName("UCL_PK_RegionQuestCondition");
                entity.ToTable("RegionQuestCondition");
                entity.Property(e => e.ParmId).HasColumnName("ParmID");
            });

            modelBuilder.Entity<RegionQuestPlaceModel>(entity =>
            {
                entity.HasKey(e => new { e.QuestNo, e.Place })
                    .HasName("UCL_PK_RegionQuestPlace");
                entity.ToTable("RegionQuestPlace");
            });

            modelBuilder.Entity<RoomInfoModel>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.MapNo, e.KeyItemId })
                    .HasName("UCL_RoomInfo");
                entity.ToTable("RoomInfo");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.RoomName).HasMaxLength(40);
            });

            modelBuilder.Entity<SkillModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Skill");
                entity.Property(e => e.Animation)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.CamShakeWhenHit).HasColumnName("CAmShakeWhenHit");
                entity.Property(e => e.Desc).HasMaxLength(50);
                entity.Property(e => e.HpperUse).HasColumnName("HPPerUse");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.MpperUse).HasColumnName("MPPerUse");
                entity.Property(e => e.Name).HasMaxLength(40);
                entity.Property(e => e.Type).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SkillAbnormalModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillAbnormal");
                entity.Property(e => e.AbnormalId).HasColumnName("AbnormalID");
                entity.Property(e => e.SkillId).HasColumnName("SkillID");
            });

            modelBuilder.Entity<SkillAttributeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillAttribute");
                entity.Property(e => e.AttrbuteId).HasColumnName("AttrbuteID");
                entity.Property(e => e.SkillId).HasColumnName("SkillID");
            });

            modelBuilder.Entity<SkillEnhancementModel>(entity =>
            {
                entity.HasKey(e => e.EnhancementSkillPackId)
                    .HasName("UCL_PK_SkillEnhancement_ESkillPackID");
                entity.ToTable("SkillEnhancement");
                entity.Property(e => e.EnhancementSkillPackId)
                    .ValueGeneratedNever()
                    .HasColumnName("ESkillPackID");
                entity.Property(e => e.SkillPackId).HasColumnName("SkillPackID");
            });

            modelBuilder.Entity<SkillEnhancementMaterialModel>(entity =>
            {
                entity.HasKey(e => new { e.EskillPackId, e.OrderNo })
                    .HasName("UCL_PK_SkillEnhancementMaterial");
                entity.ToTable("SkillEnhancementMaterial");
                entity.Property(e => e.EskillPackId).HasColumnName("ESkillPackID");
                entity.Property(e => e.ItemId).HasColumnName("ItemID");
            });

            modelBuilder.Entity<SkillIgnoreCastingDelayGroupModel>(entity =>
            {
                entity.HasKey(e => new { e.GroupNo, e.IgnoreGroup })
                    .HasName("CL_PKIgnoreCasting");
                entity.ToTable("SkillIgnoreCastingDelayGroup");
            });

            modelBuilder.Entity<SkillIgnoreCoolTimeGroupModel>(entity =>
            {
                entity.HasKey(e => new { e.GroupNo, e.IgnoreGroup })
                    .HasName("CL_PKIgnoreCoolTime");
                entity.ToTable("SkillIgnoreCoolTimeGroup");
            });

            modelBuilder.Entity<SkillPackModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillPack");
                entity.Property(e => e.SkillPackId)
                    .ValueGeneratedNever()
                    .HasColumnName("SkillPackID");
                entity.Property(e => e.Desc)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.IsDrop)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.IsUseableUtgwsvr).HasColumnName("IsUseableUTGWSvr");
                entity.Property(e => e.IsubType).HasColumnName("ISubType");
                entity.Property(e => e.Itype).HasColumnName("IType");
                entity.Property(e => e.IuseType).HasColumnName("IUseType");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.SpriteFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.TermOfValidity).HasDefaultValueSql("((10000))");
                entity.Property(e => e.UseMsg)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SkillPackSkillModel>(entity =>
            {
                entity.HasKey(e => new { e.SkillPackId, e.SkillId })
                    .HasName("PK__SkillPac__79A92FD8770FC95A");
                entity.ToTable("SkillPackSkill");
                entity.Property(e => e.SkillPackId).HasColumnName("SkillPackID");
                entity.Property(e => e.SkillId).HasColumnName("SkillID");
                entity.Property(e => e.SorderNo).HasColumnName("SOrderNO");
            });

            modelBuilder.Entity<SkillResourceModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillResource");
                entity.Property(e => e.FileName).HasMaxLength(50);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            });

            modelBuilder.Entity<SkillSlainModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillSlain");
                entity.Property(e => e.SkillId).HasColumnName("SkillID");
                entity.Property(e => e.SlainId).HasColumnName("SlainID");
            });

            modelBuilder.Entity<SkillTreeNodeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillTreeNode");
                entity.Property(e => e.SkillTreeNodeId)
                    .ValueGeneratedNever()
                    .HasColumnName("SkillTreeNodeID");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.SkillTreeId).HasColumnName("SkillTreeID");
                entity.Property(e => e.TermOfValidity).HasDefaultValueSql("((10000))");
            });

            modelBuilder.Entity<SkillTreeNodeItemModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillTreeNodeItem");
                entity.HasIndex(e => new { e.SkillTreeNodeId, e.Level }, "UNC_SkillTreeNodeItem_SkillTreeNodeID_Level")
                    .IsUnique();
                entity.HasIndex(e => new { e.SkillTreeNodeId, e.SkillPackId }, "UNC_SkillTreeNodeItem_SkillTreeNodeID_SkillPackID")
                    .IsUnique();
                entity.Property(e => e.SkillTreeNodeItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("SkillTreeNodeItemID");
                entity.Property(e => e.SkillPackId).HasColumnName("SkillPackID");
                entity.Property(e => e.SkillTreeNodeId).HasColumnName("SkillTreeNodeID");
            });

            modelBuilder.Entity<SkillTreeNodeItemConditionModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillTreeNodeItemCondition");
                entity.HasIndex(e => new { e.SkillTreeNodeItemId, e.SkillTreeNodeItemConditionType, e.ParamA, e.ParamB, e.ParamC }, "UNC_SkillTreeNodeItemCondition_SkillTreeNodeItemConditionID_SkillTreeNodeItemConditionType_ParamA_ParamB_ParamC")
                    .IsUnique();
                entity.Property(e => e.SkillTreeNodeItemId).HasColumnName("SkillTreeNodeItemID");
            });

            modelBuilder.Entity<SkillTypeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SkillType");
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<SlainModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Slain");
                entity.Property(e => e.Ddplus).HasColumnName("DDPlus");
                entity.Property(e => e.Rddplus).HasColumnName("RDDPlus");
                entity.Property(e => e.RhitPlus).HasColumnName("RHitPlus");
                entity.Property(e => e.SlainId).HasColumnName("SlainID");
            });

            modelBuilder.Entity<SlainTypeModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SlainType");
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<TransformAbilityByLevelModel>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Level })
                    .HasName("UCL_TransformAbilityByLevel_Type_Level")
                    .IsClustered(false);
                entity.ToTable("TransformAbilityByLevel");
                entity.Property(e => e.MaxHp).HasColumnName("MaxHP");
                entity.Property(e => e.MaxMp).HasColumnName("MaxMP");
            });

            modelBuilder.Entity<TransformListModel>(entity =>
            {
                entity.ToTable("TransformList");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.GroupId).HasColumnName("GroupID");
                entity.Property(e => e.MonId).HasColumnName("MonID");
            });
        }
    }
}
