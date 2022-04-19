using Database.Models;
using Server.Game.Models.GameModels;

namespace Server.Game.Services.Mapping
{
    /// <summary>
    ///     Game mapping service
    /// </summary>
    public class GameMappingService
    {
        private readonly DatabaseBalanceService _databaseBalanceService;
        private readonly DatabaseMappingService _databaseMappingService;

        public GameMappingService(DatabaseBalanceService databaseBalanceService, DatabaseMappingService databaseMappingService)
        {
            _databaseBalanceService = databaseBalanceService;
            _databaseMappingService = databaseMappingService;
        }

        #region Character
        /// <summary>
        ///     Get character game
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public CharacterGameModel GetCharacterGame(CharacterModel character)
        {
            CharacterGameModel characterGame = new CharacterGameModel();

            _databaseMappingService.MapCharacter(characterGame, character);

            CharacterGameModel characterBalance = _databaseBalanceService.GetCharacterByLevelClass(characterGame.Level, characterGame.Class);
            MapCharacterGame(characterGame, characterBalance);

            return characterGame;
        }

        public void ReMapCharacterGame(CharacterGameModel character)
        {
            CharacterGameModel characterGame = _databaseBalanceService.GetCharacterByLevelClass(character.Level, character.Class);

            MapCharacterGame(character, characterGame);
        }

        /// <summary>
        ///     Map character game
        /// </summary>
        /// <param name="characterGameFirst"></param>
        /// <param name="characterGameSecond"></param>
        /// <returns></returns>
        public void MapCharacterGame(CharacterGameModel characterGameFirst, CharacterGameModel characterGameSecond)
        {
            characterGameFirst.DDvMin = characterGameSecond.DDvMin;
            characterGameFirst.DDvMax = characterGameSecond.DDvMax;
            characterGameFirst.MDvMin = characterGameSecond.MDvMin;
            characterGameFirst.MDvMax = characterGameSecond.MDvMax;
            characterGameFirst.RDvMin = characterGameSecond.RDvMin;
            characterGameFirst.RDvMax = characterGameSecond.RDvMax;

            characterGameFirst.DPv = characterGameSecond.DPv;
            characterGameFirst.MPv = characterGameSecond.MPv;
            characterGameFirst.RPv = characterGameSecond.RPv;

            characterGameFirst.DHit = characterGameSecond.DHit;
            characterGameFirst.DDd = characterGameSecond.DDd;

            characterGameFirst.RHit = characterGameSecond.RHit;
            characterGameFirst.RDd = characterGameSecond.RDd;

            characterGameFirst.MHit = characterGameSecond.MHit;
            characterGameFirst.MDd = characterGameSecond.MDd;

            characterGameFirst.Str = characterGameSecond.Str;
            characterGameFirst.Dex = characterGameSecond.Dex;
            characterGameFirst.Int = characterGameSecond.Int;

            characterGameFirst.HpMax = characterGameSecond.HpMax;
            characterGameFirst.HpRegen = characterGameSecond.HpRegen;

            characterGameFirst.MpMax = characterGameSecond.MpMax;
            characterGameFirst.MpRegen = characterGameSecond.MpRegen;

            characterGameFirst.WeightMax = characterGameSecond.WeightMax;

            characterGameFirst.AttackRate = characterGameSecond.AttackRate;
            characterGameFirst.MoveRate = characterGameSecond.MoveRate;

            characterGameFirst.DistanceAttack = characterGameSecond.DistanceAttack;

            characterGameFirst.IsVsibleFirst = true;
        }
        #endregion

        #region Item
        /// <summary>
        ///     Get item game
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ItemGameModel GetItemGame(ItemModel item)
        {
            ItemGameModel itemGame = new ItemGameModel();

            _databaseMappingService.MapItem(itemGame, item);

            ItemGameModel itemBalance = _databaseBalanceService.GetItemById(itemGame.ItemId);
            MapItemGame(itemGame, itemBalance);

            return itemGame;
        }

        /// <summary>
        ///     Map item game
        /// </summary>
        /// <param name="itemGameFirst"></param>
        /// <param name="itemGameSecond"></param>
        public void MapItemGame(ItemGameModel itemGameFirst, ItemGameModel itemGameSecond)
        {
            itemGameFirst.ItemId = itemGameSecond.ItemId;

            itemGameFirst.EquipType = itemGameSecond.EquipType;
            itemGameFirst.Name = itemGameSecond.Name;

            itemGameFirst.DDvMin = itemGameSecond.DDvMin;
            itemGameFirst.DDvMax = itemGameSecond.DDvMax;
            itemGameFirst.MDvMin = itemGameSecond.MDvMin;
            itemGameFirst.MDvMax = itemGameSecond.MDvMax;
            itemGameFirst.RDvMin = itemGameSecond.RDvMin;
            itemGameFirst.RDvMax = itemGameSecond.RDvMax;

            itemGameFirst.DPv = itemGameSecond.DPv;
            itemGameFirst.MPv = itemGameSecond.MPv;
            itemGameFirst.RPv = itemGameSecond.RPv;

            itemGameFirst.Dhit = itemGameSecond.Dhit;
            itemGameFirst.DDd = itemGameSecond.DDd;

            itemGameFirst.Rhit = itemGameSecond.Rhit;
            itemGameFirst.RDd = itemGameSecond.RDd;

            itemGameFirst.Mhit = itemGameSecond.Mhit;
            itemGameFirst.MDd = itemGameSecond.MDd;

            itemGameFirst.Critical = itemGameSecond.Critical;
            itemGameFirst.CriticalProtect = itemGameSecond.CriticalProtect;

            itemGameFirst.DDvCriticalAdd = itemGameSecond.DDvCriticalAdd;
            itemGameFirst.DDvCriticalRemove = itemGameSecond.DDvCriticalRemove;

            itemGameFirst.HumanKiller = itemGameSecond.HumanKiller;
            itemGameFirst.HumanProtect = itemGameSecond.HumanProtect;

            itemGameFirst.MobKiller = itemGameSecond.MobKiller;
            itemGameFirst.MobProtect = itemGameSecond.MobProtect;

            itemGameFirst.Str = itemGameSecond.Str;
            itemGameFirst.Dex = itemGameSecond.Dex;
            itemGameFirst.Int = itemGameSecond.Int;

            itemGameFirst.Hp = itemGameSecond.Hp;
            itemGameFirst.HpRegen = itemGameSecond.HpRegen;
            itemGameFirst.HpPotionRestore = itemGameSecond.HpPotionRestore;
            itemGameFirst.AddPotionRestoreHp = itemGameSecond.AddPotionRestoreHp;
            itemGameFirst.AddTransformMaxHp = itemGameSecond.AddTransformMaxHp;

            itemGameFirst.Mp = itemGameSecond.Mp;
            itemGameFirst.MpRegen = itemGameSecond.MpRegen;
            itemGameFirst.MpPotionRestore = itemGameSecond.MpPotionRestore;
            itemGameFirst.AddPotionRestoreMp = itemGameSecond.AddPotionRestoreMp;
            itemGameFirst.AddTransformMaxMp = itemGameSecond.AddTransformMaxMp;

            itemGameFirst.Weight = itemGameSecond.Weight;
            itemGameFirst.WeightMax = itemGameSecond.WeightMax;

            itemGameFirst.IsStack = itemGameSecond.IsStack;

            itemGameFirst.AttackRate = itemGameSecond.AttackRate;
            itemGameFirst.AttackRateWhenTransform = itemGameSecond.AttackRateWhenTransform;

            itemGameFirst.MoveRate = itemGameSecond.MoveRate;
            itemGameFirst.MoveRateWhenTransform = itemGameSecond.MoveRateWhenTransform;

            itemGameFirst.DistanceAttack = itemGameSecond.DistanceAttack;

            itemGameFirst.UseLevel = itemGameSecond.UseLevel;

            itemGameFirst.UseKnight = itemGameSecond.UseKnight;
            itemGameFirst.UseRanger = itemGameSecond.UseRanger;
            itemGameFirst.UseMagician = itemGameSecond.UseMagician;
            itemGameFirst.UseAssassin = itemGameSecond.UseAssassin;
            itemGameFirst.UseSummoner = itemGameSecond.UseSummoner;

            itemGameFirst.UseInAttack = itemGameSecond.UseInAttack;

            itemGameFirst.Percent = itemGameSecond.Percent;
        }
        #endregion
    }
}
