using Database.DataModel.Enums;
using Database.DataModel.Models;
using Database.Game.Models;
using Server.Game.Models.Game;
using Server.Game.Services.Database;

namespace Server.Game.Services.Mapping
{
    /// <summary>
    ///     Game mapping service
    /// </summary>
    public class GameMappingService
    {
        private readonly ParmRepository _parmRepository;
        private readonly Services.DBGameMappingService _databaseMappingService;

        public GameMappingService(ParmRepository parmRepository, Services.DBGameMappingService databaseMappingService)
        {
            _parmRepository = parmRepository;
            _databaseMappingService = databaseMappingService;
        }

        #region Character
        /// <summary>
        ///     Get character game
        /// </summary>
        /// <param name="parmPc"></param>
        /// <returns></returns>
        public GPc GetCharacterGame(Pc parmPc)
        {
            GPc pc = new GPc();
            ParmMonster parmMon;

            if (parmPc.Class == (int)PcClassEnum.Fighter)
                parmMon = _parmRepository.GetMonsterById(150);
            else if (parmPc.Class == (int)PcClassEnum.Dragoon)
                parmMon = _parmRepository.GetMonsterById(151);
            else if (parmPc.Class == (int)PcClassEnum.Wizard)
                parmMon = _parmRepository.GetMonsterById(152);
            else if (parmPc.Class == (int)PcClassEnum.Assassin)
                parmMon = _parmRepository.GetMonsterById(729);
            else
                parmMon = _parmRepository.GetMonsterById(952);

            _databaseMappingService.MapCharacter(pc, parmPc, parmMon);

            // TODO Перерасчет характеристик персонажа за счет уровня, силы, ловкости, интеллекта


            //GPc characterBalance = _databaseBalanceService.GetCharacterByLevelClass(characterGame.Level, characterGame.Class);
            //MapCharacterGame(characterGame, characterBalance);

            return pc;
        }

        //public void ReMapCharacterGame(GPc character)
        //{
        //    // TODO Перерасчет характеристик персонажа за счет уровня, силы, ловкости, интеллекта
        //    GPc characterGame = _databaseBalanceService.GetCharacterByLevelClass(character.Level, character.Class);

        //    MapCharacterGame(character, characterGame);
        //}

        /// <summary>
        ///     Map character game
        /// </summary>
        /// <param name="characterGameFirst"></param>
        /// <param name="characterGameSecond"></param>
        /// <returns></returns>
        public void MapCharacterGame(GPc characterGameFirst, GPc characterGameSecond)
        {
            // TODO Перерасчет характеристик персонажа за счет уровня, силы, ловкости, интеллекта
            //characterGameFirst.DDvMin = characterGameSecond.DDvMin;
            //characterGameFirst.DDvMax = characterGameSecond.DDvMax;
            //characterGameFirst.MDvMin = characterGameSecond.MDvMin;
            //characterGameFirst.MDvMax = characterGameSecond.MDvMax;
            //characterGameFirst.RDvMin = characterGameSecond.RDvMin;
            //characterGameFirst.RDvMax = characterGameSecond.RDvMax;

            //characterGameFirst.DPv = characterGameSecond.DPv;
            //characterGameFirst.MPv = characterGameSecond.MPv;
            //characterGameFirst.RPv = characterGameSecond.RPv;

            //characterGameFirst.DHit = characterGameSecond.DHit;
            //characterGameFirst.DDd = characterGameSecond.DDd;

            //characterGameFirst.RHit = characterGameSecond.RHit;
            //characterGameFirst.RDd = characterGameSecond.RDd;

            //characterGameFirst.MHit = characterGameSecond.MHit;
            //characterGameFirst.MDd = characterGameSecond.MDd;

            //characterGameFirst.Str = characterGameSecond.Str;
            //characterGameFirst.Dex = characterGameSecond.Dex;
            //characterGameFirst.Int = characterGameSecond.Int;

            //characterGameFirst.HpMax = characterGameSecond.HpMax;
            //characterGameFirst.HpRegen = characterGameSecond.HpRegen;

            //characterGameFirst.MpMax = characterGameSecond.MpMax;
            //characterGameFirst.MpRegen = characterGameSecond.MpRegen;

            //characterGameFirst.WeightMax = characterGameSecond.WeightMax;

            //characterGameFirst.AttackRate = characterGameSecond.AttackRate;
            //characterGameFirst.MoveRate = characterGameSecond.MoveRate;

            //characterGameFirst.DistanceAttack = characterGameSecond.DistanceAttack;

            //characterGameFirst.IsVsibleFirst = true;
        }
        #endregion

        #region Item
        /// <summary>
        ///     Get item game
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public GItem GetItemGame(Item item)
        {
            GItem itemGame = new GItem();

            //_databaseMappingService.MapItem(itemGame, item);

            //GItem itemBalance = _databaseBalanceService.GetItemById(itemGame.Id);
            //MapItemGame(itemGame, itemBalance);

            return itemGame;
        }

        /// <summary>
        ///     Map item game
        /// </summary>
        /// <param name="itemGameFirst"></param>
        /// <param name="itemGameSecond"></param>
        //public void MapItemGame(ItemGameModel itemGameFirst, ItemGameModel itemGameSecond)
        //{
        //    itemGameFirst.Id = itemGameSecond.Id;

        //    itemGameFirst.EquipType = itemGameSecond.EquipType;
        //    itemGameFirst.Name = itemGameSecond.Name;

        //    itemGameFirst.DDvMin = itemGameSecond.DDvMin;
        //    itemGameFirst.DDvMax = itemGameSecond.DDvMax;
        //    itemGameFirst.MDvMin = itemGameSecond.MDvMin;
        //    itemGameFirst.MDvMax = itemGameSecond.MDvMax;
        //    itemGameFirst.RDvMin = itemGameSecond.RDvMin;
        //    itemGameFirst.RDvMax = itemGameSecond.RDvMax;

        //    itemGameFirst.DPv = itemGameSecond.DPv;
        //    itemGameFirst.MPv = itemGameSecond.MPv;
        //    itemGameFirst.RPv = itemGameSecond.RPv;

        //    itemGameFirst.DHit = itemGameSecond.DHit;
        //    itemGameFirst.DDd = itemGameSecond.DDd;

        //    itemGameFirst.RHit = itemGameSecond.RHit;
        //    itemGameFirst.RDd = itemGameSecond.RDd;

        //    itemGameFirst.MHit = itemGameSecond.MHit;
        //    itemGameFirst.MDd = itemGameSecond.MDd;

        //    itemGameFirst.Critical = itemGameSecond.Critical;
        //    itemGameFirst.EnemySubCriticalHit = itemGameSecond.EnemySubCriticalHit;

        //    itemGameFirst.AddDdwhenCritical = itemGameSecond.AddDdwhenCritical;
        //    itemGameFirst.SubDdwhenCritical = itemGameSecond.SubDdwhenCritical;

        //    itemGameFirst.HumanKiller = itemGameSecond.HumanKiller;
        //    itemGameFirst.HumanProtect = itemGameSecond.HumanProtect;

        //    itemGameFirst.MobKiller = itemGameSecond.MobKiller;
        //    itemGameFirst.MobProtect = itemGameSecond.MobProtect;

        //    itemGameFirst.Str = itemGameSecond.Str;
        //    itemGameFirst.Dex = itemGameSecond.Dex;
        //    itemGameFirst.Int = itemGameSecond.Int;

        //    itemGameFirst.HpPlus = itemGameSecond.HpPlus;
        //    itemGameFirst.HpRegen = itemGameSecond.HpRegen;
        //    itemGameFirst.HpPotionRestore = itemGameSecond.HpPotionRestore;
        //    itemGameFirst.AddHpPotionRestore = itemGameSecond.AddHpPotionRestore;
        //    itemGameFirst.AddMaxHpWhenTransform = itemGameSecond.AddMaxHpWhenTransform;

        //    itemGameFirst.Mpplus = itemGameSecond.Mpplus;
        //    itemGameFirst.MpRegen = itemGameSecond.MpRegen;
        //    itemGameFirst.MpPotionRestore = itemGameSecond.MpPotionRestore;
        //    itemGameFirst.AddMpPotionRestore = itemGameSecond.AddMpPotionRestore;
        //    itemGameFirst.AddMaxMpWhenTransform = itemGameSecond.AddMaxMpWhenTransform;

        //    itemGameFirst.Weight = itemGameSecond.Weight;
        //    itemGameFirst.AddWeight = itemGameSecond.AddWeight;

        //    itemGameFirst.MaxStack = itemGameSecond.MaxStack;

        //    itemGameFirst.AttackRate = itemGameSecond.AttackRate;
        //    itemGameFirst.AddAttackRateWhenTransform = itemGameSecond.AddAttackRateWhenTransform;

        //    itemGameFirst.MoveRate = itemGameSecond.MoveRate;
        //    itemGameFirst.AddMoveRateWhenTransform = itemGameSecond.AddMoveRateWhenTransform;

        //    itemGameFirst.AddShortAttackRange = itemGameSecond.AddShortAttackRange;

        //    itemGameFirst.UseLevel = itemGameSecond.UseLevel;

        //    itemGameFirst.UseKnight = itemGameSecond.UseKnight;
        //    itemGameFirst.UseRanger = itemGameSecond.UseRanger;
        //    itemGameFirst.UseMagician = itemGameSecond.UseMagician;
        //    itemGameFirst.UseAssassin = itemGameSecond.UseAssassin;
        //    itemGameFirst.UseSummoner = itemGameSecond.UseSummoner;

        //    itemGameFirst.UseInAttack = itemGameSecond.UseInAttack;

        //    itemGameFirst.Percent = itemGameSecond.Percent;
        //}
        #endregion
    }
}
