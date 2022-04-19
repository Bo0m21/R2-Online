using System;
using System.Threading;
using System.Threading.Tasks;
using Database.Game.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Game.Interfaces
{
    /// <summary>
    ///     Интерфейс контекста базы
    /// </summary>
    public interface IGameContext : IDisposable
    {
        DbSet<ItemSerial> ItemSerials { get; set; }
        DbSet<Pc> Pcs { get; set; }
        DbSet<PcAbnormal> PcAbnormals { get; set; }
        DbSet<PcAchieveEquip> PcAchieveEquips { get; set; }
        DbSet<PcAchieveInventory> PcAchieveInventories { get; set; }
        DbSet<PcAchieveList> PcAchieveLists { get; set; }
        DbSet<PcBead> PcBeads { get; set; }
        DbSet<PcChatFilter> PcChatFilters { get; set; }
        DbSet<PcCoolTime> PcCoolTimes { get; set; }
        DbSet<PcDeleted> PcDeleteds { get; set; }
        DbSet<PcEquip> PcEquips { get; set; }
        DbSet<PcFriend> PcFriends { get; set; }
        DbSet<PcGoldItemEffect> PcGoldItemEffects { get; set; }
        DbSet<PcInvenQslotInfo> PcInvenQslotInfos { get; set; }
        DbSet<PcInventory> PcInventories { get; set; }
        DbSet<PcLevelupCoin> PcLevelupCoins { get; set; }
        DbSet<PcPopupGuide> PcPopupGuides { get; set; }
        DbSet<PcQuest> PcQuests { get; set; }
        DbSet<PcQuestCondition> PcQuestConditions { get; set; }
        DbSet<PcQuestVisit> PcQuestVisits { get; set; }
        DbSet<PcRestored> PcRestoreds { get; set; }
        DbSet<PcServant> PcServants { get; set; }
        DbSet<PcServantSkillPack> PcServantSkillPacks { get; set; }
        DbSet<PcServantSkillTree> PcServantSkillTrees { get; set; }
        DbSet<PcSkillPackInventory> PcSkillPackInventories { get; set; }
        DbSet<PcSkillTreeInventory> PcSkillTreeInventories { get; set; }
        DbSet<PcState> PcStates { get; set; }
        DbSet<PcStore> PcStores { get; set; }
        DbSet<PcTeleport> PcTeleports { get; set; }
        DbSet<PcUnConfirmedCoin> PcUnConfirmedCoins { get; set; }


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