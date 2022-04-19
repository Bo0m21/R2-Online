using Database.Parm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using AttributeModel = Database.Parm.Models.AttributeModel;

namespace Database.Parm.Interfaces
{
    /// <summary>
    ///     Interface for database balance context
    /// </summary>
    public interface IParmContext : IDisposable
    {
        DbSet<AbnormalModel> Abnormals { get; set; }
        DbSet<AbnormalAddModel> AbnormalAdds { get; set; }
        DbSet<AbnormalAttrApplyModel> AbnormalAttrApplys { get; set; }
        DbSet<AbnormalAttrAttachModel> AbnormalAttrAttaches { get; set; }
        DbSet<AbnormalAttrChangeAbnormalModel> AbnormalAttrChangeAbnormals { get; set; }
        DbSet<AbnormalAttrChangeEquipAbnormalModel> AbnormalAttrChangeEquipAbnormals { get; set; }
        DbSet<AbnormalAttrDetachModel> AbnormalAttrDetaches { get; set; }
        DbSet<AbnormalAttrIgnoreModel> AbnormalAttrIgnores { get; set; }
        DbSet<AbnormalModuleModel> AbnormalModules { get; set; }
        DbSet<AbnormalResistModel> AbnormalResists { get; set; }
        DbSet<AbnormalTypeModel> AbnormalTypes { get; set; }
        DbSet<AttributeModel> Attributes { get; set; }
        DbSet<AttributeAddModel> AttributeAdds { get; set; }
        DbSet<AttributeResistModel> AttributeResists { get; set; }
        DbSet<BeadModel> Beads { get; set; }
        DbSet<BeadEffectModel> BeadEffects { get; set; }
        DbSet<BeadEffectParmModel> BeadEffectParms { get; set; }
        DbSet<CharacterModel> Characters { get; set; }
        DbSet<CharacterPositionModel> CharacterPositions { get; set; }
        DbSet<DialogModel> Dialogs { get; set; }
        DbSet<DialogScriptModel> DialogScripts { get; set; }
        DbSet<DropGroupModel> DropGroups { get; set; }
        DbSet<DropItemModel> DropItems { get; set; }
        DbSet<ExpModel> Exps { get; set; }
        DbSet<FullMoonMonsterListModel> FullMoonMonsterList { get; set; }
        DbSet<ItemModel> Items { get; set; }
        DbSet<ItemAbnormalAddModel> ItemAbnormalAdds { get; set; }
        DbSet<ItemAbnormalResistModel> ItemAbnormalResists { get; set; }
        DbSet<ItemAttributeAddModel> ItemAttributeAdds { get; set; }
        DbSet<ItemBeadEffectModel> ItemBeadEffects { get; set; }
        DbSet<ItemBeadModuleModel> ItemBeadModules { get; set; }
        DbSet<ItemMEndDateModel> ItemMEndDates { get; set; }
        DbSet<ItemPanaltyModel> ItemPanalties { get; set; }
        DbSet<ItemProtectModel> ItemProtects { get; set; }
        DbSet<ItemSkillModel> ItemSkills { get; set; }
        DbSet<ItemSlainModel> ItemSlains { get; set; }
        DbSet<MaterialDrawAddGroupModel> MaterialDrawAddGroups { get; set; }
        DbSet<MaterialDrawIndexModel> MaterialDrawIndexes { get; set; }
        DbSet<MaterialDrawMaterialModel> MaterialDrawMaterials { get; set; }
        DbSet<MaterialDrawResultModel> MaterialDrawResults { get; set; }
        DbSet<MaterialEnchantProbabilityModel> MaterialEnchantProbabilities { get; set; }
        DbSet<MaterialEvolutionGradeModel> MaterialEvolutionGrades { get; set; }
        DbSet<MaterialEvolutionMaterialModel> MaterialEvolutionMaterials { get; set; }
        DbSet<MaterialEvolutionResultModel> MaterialEvolutionResults { get; set; }
        DbSet<MaterialItemInfoModel> MaterialItemInfos { get; set; }
        DbSet<MerchantSellListModel> MerchantSellLists { get; set; }
        DbSet<ModuleModel> Modules { get; set; }
        DbSet<ModuleTypeModel> ModuleTypes { get; set; }
        DbSet<MonsterModel> Monsters { get; set; }
        DbSet<MonsterAbnormalAddModel> MonsterAbnormalAdds { get; set; }
        DbSet<MonsterAbnormalResistModel> MonsterAbnormalResists { get; set; }
        DbSet<MonsterAttributeAddModel> MonsterAttributeAdds { get; set; }
        DbSet<MonsterAttributeResistModel> MonsterAttributeResists { get; set; }
        DbSet<MonsterDropModel> MonsterDrops { get; set; }
        DbSet<MonsterRoleModel> MonsterRoles { get; set; }
        DbSet<MonsterSlainModel> MonsterSlains { get; set; }
        DbSet<MonsterSpotModel> MonsterSpots { get; set; }
        DbSet<MonsterSpotGroupModel> MonsterSpotGroups { get; set; }
        DbSet<ProtectModel> Protects { get; set; }
        DbSet<QuestModel> Quests { get; set; }
        DbSet<QuestConditionModel> QuestConditions { get; set; }
        DbSet<QuestInfoModel> QuestInfos { get; set; }
        DbSet<QuestRefMonsterModel> QuestRefMonsters { get; set; }
        DbSet<QuestRewardModel> QuestRewards { get; set; }
        DbSet<RefineModel> Refines { get; set; }
        DbSet<RefineCreateInfoModel> RefineCreateInfos { get; set; }
        DbSet<RefineMaterialModel> RefineMaterials { get; set; }
        DbSet<RegionOptionModel> RegionOptions { get; set; }
        DbSet<RegionQuestModel> RegionQuests { get; set; }
        DbSet<RegionQuestConditionModel> RegionQuestConditions { get; set; }
        DbSet<RegionQuestPlaceModel> RegionQuestPlaces { get; set; }
        DbSet<RoomInfoModel> RoomInfos { get; set; }
        DbSet<SkillModel> Skills { get; set; }
        DbSet<SkillAbnormalModel> SkillAbnormals { get; set; }
        DbSet<SkillAttributeModel> SkillAttributes { get; set; }
        DbSet<SkillEnhancementModel> SkillEnhancements { get; set; }
        DbSet<SkillEnhancementMaterialModel> SkillEnhancementMaterials { get; set; }
        DbSet<SkillIgnoreCastingDelayGroupModel> SkillIgnoreCastingDelayGroups { get; set; }
        DbSet<SkillIgnoreCoolTimeGroupModel> SkillIgnoreCoolTimeGroups { get; set; }
        DbSet<SkillPackModel> SkillPacks { get; set; }
        DbSet<SkillPackSkillModel> SkillPackSkills { get; set; }
        DbSet<SkillResourceModel> SkillResources { get; set; }
        DbSet<SkillSlainModel> SkillSlains { get; set; }
        DbSet<SkillTreeNodeModel> SkillTreeNodes { get; set; }
        DbSet<SkillTreeNodeItemModel> SkillTreeNodeItems { get; set; }
        DbSet<SkillTreeNodeItemConditionModel> SkillTreeNodeItemConditions { get; set; }
        DbSet<SkillTypeModel> SkillTypes { get; set; }
        DbSet<SlainModel> Slains { get; set; }
        DbSet<SlainTypeModel> SlainTypes { get; set; }
        DbSet<TransformAbilityByLevelModel> TransformAbilityByLevels { get; set; }
        DbSet<TransformListModel> TransformLists { get; set; }


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
        EntityEntry Update([NotNull] object entity);

        /// <summary>
        ///     Update generic entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;
    }
}
