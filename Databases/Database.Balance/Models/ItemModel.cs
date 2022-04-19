using Database.Balance.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Balance.Models
{
    /// <summary>
    ///     Item model
    /// </summary>
    public class ItemModel
    {
        public ItemModel()
        {
            ItemReinforces = new List<ItemReinforceModel>();
            ItemReinforceOlds = new List<ItemReinforceModel>();
            ItemReinforceNews = new List<ItemReinforceModel>();
            BuffItems = new List<BuffItemModel>();
            UnitDrops = new List<UnitDropModel>();
            UnitPurchases = new List<UnitPurchaseModel>();
            UnitSales = new List<UnitSaleModel>();
        }

        public int Id { get; set; }

        /// <summary>
        ///     Item id
        /// </summary>
        [Required]
        public int ItemId { get; set; }

        /// <summary>
        ///     Item name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     Item type
        /// </summary>
        [Required]
        public ItemType Type { get; set; }

        #region Item common fields
        /// <summary>
        ///     Weight
        /// </summary>
        public short Weight { get; set; }

        /// <summary>
        ///     Is stack
        /// </summary>
        public bool IsStack { get; set; }

        /// <summary>
        ///     Is stack
        /// </summary>
        public bool IsUsable { get; set; }
        #endregion

        #region Item equip
        /// <summary>
        ///     Item equip type
        /// </summary>
        public ItemEquipType? EquipType { get; set; }

        /// <summary>
        ///     Direct Damage value min
        /// </summary>
        public int DDvMin { get; set; }

        /// <summary>
        ///     Direct Damage value max
        /// </summary>
        public int DDvMax { get; set; }

        /// <summary>
        ///     Magic Damage value min
        /// </summary>
        public int MDvMin { get; set; }

        /// <summary>
        ///     Magic Damage value max
        /// </summary>
        public int MDvMax { get; set; }

        /// <summary>
        ///     Range Damage value min
        /// </summary>
        public int RDvMin { get; set; }

        /// <summary>
        ///     Range Damage value max
        /// </summary>
        public int RDvMax { get; set; }

        /// <summary>
        ///     Direct Protection value
        /// </summary>
        public int DPv { get; set; }

        /// <summary>
        ///     Magic Protection value
        /// </summary>
        public int MPv { get; set; }

        /// <summary>
        ///     Range Protection value
        /// </summary>
        public int RPv { get; set; }

        /// <summary>
        ///     Direct hit
        /// </summary>
        public int Dhit { get; set; }

        /// <summary>
        ///     Direct Damage dodge
        /// </summary>
        public int DDd { get; set; }

        /// <summary>
        ///     Range hit
        /// </summary>
        public int Rhit { get; set; }

        /// <summary>
        ///     Range Damage dodge
        /// </summary>
        public int RDd { get; set; }

        /// <summary>
        ///     Magic hit
        /// </summary>
        public int Mhit { get; set; }

        /// <summary>
        ///     Magic Damage dodge
        /// </summary>
        public int MDd { get; set; }

        /// <summary>
        ///     Critical
        /// </summary>
        public short Critical { get; set; }

        /// <summary>
        ///     Critical protect
        /// </summary>
        public short CriticalProtect { get; set; }

        /// <summary>
        ///     DDv critical add
        /// </summary>
        public short DDvCriticalAdd { get; set; }

        /// <summary>
        ///     DDv critical remove
        /// </summary>
        public short DDvCriticalRemove { get; set; }

        /// <summary>
        ///     Human killer
        /// </summary>
        public short HumanKiller { get; set; }

        /// <summary>
        ///     Human protect
        /// </summary>
        public short HumanProtect { get; set; }

        /// <summary>
        ///     Mob killer
        /// </summary>
        public short MobKiller { get; set; }

        /// <summary>
        ///     Mob protect
        /// </summary>
        public short MobProtect { get; set; }

        /// <summary>
        ///     Strength
        /// </summary>
        public short Str { get; set; }

        /// <summary>
        ///     Adroitness
        /// </summary>
        public short Dex { get; set; }

        /// <summary>
        ///     Intelligence
        /// </summary>
        public short Int { get; set; }

        /// <summary>
        ///     Health point
        /// </summary>
        public short Hp { get; set; }

        /// <summary>
        ///     Health point regen
        /// </summary>
        public short HpRegen { get; set; }

        /// <summary>
        ///     Hp potion restore
        /// </summary>
        public short HpPotionRestore { get; set; }

        /// <summary>
        ///     Add potion restore hp
        /// </summary>
        public short AddPotionRestoreHp { get; set; }

        /// <summary>
        ///     Add transform hp
        /// </summary>
        public short AddTransformMaxHp { get; set; }

        /// <summary>
        ///     Magic point
        /// </summary>
        public short Mp { get; set; }

        /// <summary>
        ///     Magic point regen
        /// </summary>
        public short MpRegen { get; set; }

        /// <summary>
        ///     Mp potion restore
        /// </summary>
        public short MpPotionRestore { get; set; }

        /// <summary>
        ///     Add potion restore mp
        /// </summary>
        public short AddPotionRestoreMp { get; set; }

        /// <summary>
        ///     Add transform max hp
        /// </summary>
        public short AddTransformMaxMp { get; set; }

        /// <summary>
        ///     Weight max
        /// </summary>
        public short WeightMax { get; set; }

        /// <summary>
        ///     Attack rate
        /// </summary>
        public short AttackRate { get; set; }

        /// <summary>
        ///     Attack speed when transform
        /// </summary>
        public short AttackRateWhenTransform { get; set; }

        /// <summary>
        ///     Move rate
        /// </summary>
        public short MoveRate { get; set; }

        /// <summary>
        ///     Move speed when transform
        /// </summary>
        public short MoveRateWhenTransform { get; set; }

        /// <summary>
        ///     Distance attack
        /// </summary>
        public float DistanceAttack { get; set; }

        /// <summary>
        ///     Use level
        /// </summary>
        public short UseLevel { get; set; }

        /// <summary>
        ///   Use Knight
        /// </summary>
        public bool UseKnight { get; set; }

        /// <summary>
        ///     Use Ranger
        /// </summary>
        public bool UseRanger { get; set; }

        /// <summary>
        ///     Use Magician
        /// </summary>
        public bool UseMagician { get; set; }

        /// <summary>
        ///     Use Assassin
        /// </summary>
        public bool UseAssassin { get; set; }

        /// <summary>
        ///     Use Summoner
        /// </summary>
        public bool UseSummoner { get; set; }

        /// <summary>
        ///     Use in attack
        /// </summary>
        public bool UseInAttack { get; set; }
        #endregion

        #region Item material
        /// <summary>
        ///     Percent
        /// </summary>
        public float Percent { get; set; }
        #endregion

        #region Premium
        /// <summary>
        ///     Increase exp
        /// </summary>
        public short IncExp { get; set; }
        /// <summary>
        ///     Increase drop
        /// </summary>
        public short IncDrop { get; set; }
        /// <summary>
        ///     Increase silver drop
        /// </summary>
        public short IncSilver { get; set; }
        #endregion

        /// <summary>
        ///     Item reinforces
        /// </summary>
        public List<ItemReinforceModel> ItemReinforces { get; set; }

        /// <summary>
        ///     Item reinforce olds
        /// </summary>
        public List<ItemReinforceModel> ItemReinforceOlds { get; set; }

        /// <summary>
        ///     Item reinforce news
        /// </summary>
        public List<ItemReinforceModel> ItemReinforceNews { get; set; }

        /// <summary>
        ///     Item reinforces 1
        /// </summary>
        public List<ItemReinforceModel> ItemReinforces1 { get; set; }

        /// <summary>
        ///     Item reinforces 2
        /// </summary>
        public List<ItemReinforceModel> ItemReinforces2 { get; set; }

        /// <summary>
        ///     Item reinforces 3
        /// </summary>
        public List<ItemReinforceModel> ItemReinforces3 { get; set; }

        /// <summary>
        ///     Buff items
        /// </summary>
        public List<BuffItemModel> BuffItems { get; set; }

        /// <summary>
        ///     Unit drops
        /// </summary>
        public List<UnitDropModel> UnitDrops { get; set; }

        /// <summary>
        ///     Unit purchases
        /// </summary>
        public List<UnitPurchaseModel> UnitPurchases { get; set; }

        /// <summary>
        ///     Unit sales
        /// </summary>
        public List<UnitSaleModel> UnitSales { get; set; }
    }
}
