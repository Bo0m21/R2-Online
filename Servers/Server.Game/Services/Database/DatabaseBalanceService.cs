using Database.Balance.Enums;
using Database.Balance.Interfaces;
using Database.Balance.Models;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Services
{
    /// <summary>
    ///     Database balance service
    /// </summary>
    public class DatabaseBalanceService
    {
        private readonly IDatabaseBalanceContext _databaseBalanceContext;
        private readonly DatabaseBalanceMappingService _databaseBalanceMappingService;

        private readonly List<CharacterModel> _characters;
        private readonly List<CharacterPositionModel> _characterPositions;
        private readonly List<ExpModel> _exps;
        private readonly List<ItemModel> _items;
        private readonly List<BuffItemModel> _buffItems;
        private readonly List<BuffModel> _buffs;
        private readonly List<ItemReinforceModel> _itemReinforces;
        private readonly List<UnitDropModel> _unitDrops;
        private readonly List<UnitModel> _units;
        private readonly List<UnitPositionModel> _unitPositions;
        private readonly List<UnitPurchaseModel> _unitPurchases;
        private readonly List<UnitSaleModel> _unitSales;

        public DatabaseBalanceService(IDatabaseBalanceContext databaseBalanceContext, DatabaseBalanceMappingService databaseBalanceMappingService)
        {
            _databaseBalanceContext = databaseBalanceContext;
            _databaseBalanceMappingService = databaseBalanceMappingService;

            // Load all from database balasnce
            _characters = _databaseBalanceContext.Characters.ToList();
            _characterPositions = _databaseBalanceContext.CharacterPositions.ToList();
            _exps = _databaseBalanceContext.Exps.ToList();
            _items = _databaseBalanceContext.Items.ToList();
            _itemReinforces = _databaseBalanceContext.ItemReinforces.ToList();
            _unitDrops = _databaseBalanceContext.UnitDrops.ToList();
            _units = _databaseBalanceContext.Units.ToList();
            _unitPositions = _databaseBalanceContext.UnitPositions.ToList();
            _unitPurchases = _databaseBalanceContext.UnitPurchases.ToList();
            _unitSales = _databaseBalanceContext.UnitSales.ToList();
            _buffItems = _databaseBalanceContext.BuffItems.ToList();
            _buffs = _databaseBalanceContext.Buffs.ToList();
        }

        #region Character
        /// <summary>
        ///     Get character game by level class
        /// </summary>
        /// <param name="level"></param>
        /// <param name="characterType"></param>
        /// <returns></returns>
        public CharacterGameModel GetCharacterByLevelClass(int level, CharacterType characterType)
        {
            CharacterGameModel characterGame = new CharacterGameModel();

            CharacterModel characterBalance = _characters.First(c => c.Level == level && c.Class == characterType);
            _databaseBalanceMappingService.MapCharacterGame(characterGame, characterBalance);

            return characterGame;
        }

        /// <summary>
        ///     Get character position by class
        /// </summary>
        /// <param name="characterType"></param>
        /// <returns></returns>
        public CharacterPositionGameModel GetCharacterPositionByClass(CharacterType characterType)
        {
            CharacterPositionGameModel characterPositionGame = new CharacterPositionGameModel();

            CharacterPositionModel characterPositionBalance = _characterPositions.First(cp => cp.Class == characterType);
            _databaseBalanceMappingService.MapCharacterPositionGame(characterPositionGame, characterPositionBalance);

            return characterPositionGame;
        }

        public void AddCharacterModel(CharacterModel model)
        {
            _databaseBalanceContext.Characters.Add(model);
            _databaseBalanceContext.SaveChanges();
        }
        #endregion

        #region Exp
        /// <summary>
        ///     Get exp by lvl
        /// </summary>
        /// <param name="level"></param>
        public ExpGameModel GetExpByLvl(long level)
        {
            ExpGameModel expGame = new ExpGameModel();

            ExpModel expBalance = _exps.First(e => e.Level == level);
            _databaseBalanceMappingService.MapExpGame(expGame, expBalance);

            return expGame;
        }

        public void AddExpModels(ExpModel model)
        {
            _databaseBalanceContext.Exps.Add(model);
            _databaseBalanceContext.SaveChanges();
        }
        #endregion

        #region Item
        /// <summary>
        ///     Get item by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public ItemGameModel GetItemById(int itemId)
        {
            ItemGameModel itemGame = new ItemGameModel();

            ItemModel itemBalance = _items.FirstOrDefault(i => i.ItemId == itemId);
            _databaseBalanceMappingService.MapItemGame(itemGame, itemBalance);

            return itemGame;
        }

        /// <summary>
        ///     Get buffs by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<BuffGameModel> GetBuffsById(int itemId)
        {
            List<BuffGameModel> buffs = new List<BuffGameModel>();

            List<BuffItemModel> buffsBalance = _buffItems.Where(b => b.Item.ItemId == itemId).ToList();

            foreach (BuffItemModel buffItem in buffsBalance)
            {
                BuffGameModel buff = new BuffGameModel();

                _databaseBalanceMappingService.MapBuffGame(buff, buffItem);

                buffs.Add(buff);
            }

            return buffs;
        }

        /// <summary>
        ///     Get item reinforce by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public ItemReinforceGameModel GetItemReinforceById(int itemId)
        {
            ItemReinforceGameModel itemReinforceGame = new ItemReinforceGameModel();

            ItemReinforceModel itemReinforceBalance = _itemReinforces.First(i => i.Item.ItemId == itemId);
            _databaseBalanceMappingService.MapItemReinforceGame(itemReinforceGame, itemReinforceBalance);

            return itemReinforceGame;
        }
        #endregion

        #region Unit
        /// <summary>
        ///     Get unit drops by id
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public List<UnitDropGameModel> GetUnitDropsById(int unitId)
        {
            List<UnitDropGameModel> unitDropGames = new List<UnitDropGameModel>();

            List<UnitDropModel> unitDropBalances = _unitDrops.Where(u => u.Unit.UnitId == unitId).ToList();

            foreach (UnitDropModel unitDropBalance in unitDropBalances)
            {
                UnitDropGameModel unitDropGame = new UnitDropGameModel();

                _databaseBalanceMappingService.MapUnitDropGame(unitDropGame, unitDropBalance);

                unitDropGames.Add(unitDropGame);
            }

            return unitDropGames;
        }

        /// <summary>
        ///     Get unit by id
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public UnitGameModel GetUnitById(int unitId)
        {
            UnitGameModel unitGame = new UnitGameModel();

            UnitModel unitBalance = _units.First(u => u.UnitId == unitId);
            _databaseBalanceMappingService.MapUnitGame(unitGame, unitBalance);

            return unitGame;
        }

        /// <summary>
        ///     Get unit by id
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public UnitModel GetUnitModelById(int unitId)
        {
            UnitModel unitBalance = _units.First(u => u.UnitId == unitId);

            return unitBalance;
        }

        /// <summary>
        ///     Get unit positions
        /// </summary>
        /// <returns></returns>
        public List<UnitPositionGameModel> GetUnitPositions()
        {
            List<UnitPositionGameModel> unitPositionGames = new List<UnitPositionGameModel>();

            foreach (UnitPositionModel unitPositionBalance in _unitPositions)
            {
                UnitPositionGameModel unitPositionGame = new UnitPositionGameModel();

                _databaseBalanceMappingService.MapUnitPositionGame(unitPositionGame, unitPositionBalance);

                unitPositionGames.Add(unitPositionGame);
            }

            return unitPositionGames;
        }

        /// <summary>
        ///     Get unit position by id
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public UnitPositionGameModel GetUnitPositionById(int unitId)
        {
            UnitPositionGameModel unitPositionGame = new UnitPositionGameModel();

            UnitPositionModel unitPositionBalance = _unitPositions.First(u => u.Unit.UnitId == unitId);
            _databaseBalanceMappingService.MapUnitPositionGame(unitPositionGame, unitPositionBalance);

            return unitPositionGame;
        }

        /// <summary>
        ///     Get unit purchase by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public UnitPurchaseGameModel GetUnitPurchaseById(int itemId)
        {
            UnitPurchaseGameModel unitPurchaseGame = new UnitPurchaseGameModel();

            UnitPurchaseModel unitPurchaseBalance = _unitPurchases.FirstOrDefault(i => i.Item.ItemId == itemId);
            _databaseBalanceMappingService.MapUnitPurchaseGame(unitPurchaseGame, unitPurchaseBalance);

            return unitPurchaseGame;
        }

        /// <summary>
        ///     Get unit purchases by id
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public List<UnitPurchaseGameModel> GetUnitPurchasesById(int unitId)
        {
            List<UnitPurchaseGameModel> unitPurchaseGames = new List<UnitPurchaseGameModel>();

            List<UnitPurchaseModel> unitPurchaseBalances = _unitPurchases.Where(u => u.Unit.UnitId == unitId).ToList();

            foreach (UnitPurchaseModel unitPurchaseBalance in unitPurchaseBalances)
            {
                UnitPurchaseGameModel unitPurchaseGame = new UnitPurchaseGameModel();

                _databaseBalanceMappingService.MapUnitPurchaseGame(unitPurchaseGame, unitPurchaseBalance);

                unitPurchaseGames.Add(unitPurchaseGame);
            }

            return unitPurchaseGames;
        }

        /// <summary>
        ///     Get unit sale by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public UnitSaleGameModel GetUnitSaleById(int itemId)
        {
            UnitSaleGameModel unitSaleGame = new UnitSaleGameModel();

            UnitSaleModel unitSaleBalance = _unitSales.First(u => u.Item.ItemId == itemId);
            _databaseBalanceMappingService.MapUnitSaleGame(unitSaleGame, unitSaleBalance);

            return unitSaleGame;
        }

        public void AddUnitPosition(UnitPositionModel unitPositionModel)
        {
            _databaseBalanceContext.UnitPositions.Add(unitPositionModel);
            _databaseBalanceContext.SaveChanges();
        }

        #endregion
    }
}
