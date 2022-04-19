using Database.Balance.Models;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;

namespace Server.Game.Services
{
    /// <summary>
    ///     Database balance mapping service
    /// </summary>
    public class DatabaseBalanceMappingService
    {
        #region Character mapping
        /// <summary>
        ///     Map character game
        /// </summary>
        /// <param name="characterGame"></param>
        /// <param name="characterBalance"></param>
        /// <returns></returns>
        public void MapCharacterGame(CharacterGameModel characterGame, CharacterModel characterBalance)
        {
            characterGame.DDvMin = characterBalance.DDvMin;
            characterGame.DDvMax = characterBalance.DDvMax;
            characterGame.MDvMin = characterBalance.MDvMin;
            characterGame.MDvMax = characterBalance.MDvMax;
            characterGame.RDvMin = characterBalance.RDvMin;
            characterGame.RDvMax = characterBalance.RDvMax;

            characterGame.DPv = characterBalance.DPv;
            characterGame.MPv = characterBalance.MPv;
            characterGame.RPv = characterBalance.RPv;

            characterGame.DHit = characterBalance.Dhit;
            characterGame.DDd = characterBalance.DDd;

            characterGame.RHit = characterBalance.Rhit;
            characterGame.RDd = characterBalance.RDd;

            characterGame.MHit = characterBalance.Mhit;
            characterGame.MDd = characterBalance.MDd;

            characterGame.Str = characterBalance.Str;
            characterGame.Dex = characterBalance.Dex;
            characterGame.Int = characterBalance.Int;

            characterGame.HpMax = characterBalance.HpMax;
            characterGame.HpRegen = characterBalance.HpRegen;

            characterGame.MpMax = characterBalance.MpMax;
            characterGame.MpRegen = characterBalance.MpRegen;

            characterGame.WeightMax = characterBalance.WeightMax;

            characterGame.AttackRate = characterBalance.AttackRate;
            characterGame.MoveRate = characterBalance.MoveRate;

            characterGame.DistanceAttack = 300; // TODO to db balance

            characterGame.IsVsibleFirst = true;
        }

        /// <summary>
        ///     Map character position game
        /// </summary>
        /// <param name="characterPositionGame"></param>
        /// <param name="characterPositionBalance"></param>
        public void MapCharacterPositionGame(CharacterPositionGameModel characterPositionGame, CharacterPositionModel characterPositionBalance)
        {
            characterPositionGame.Class = characterPositionBalance.Class;
            characterPositionGame.Position = new Vector3(characterPositionBalance.X, characterPositionBalance.Y, characterPositionBalance.Z);
        }
        #endregion

        #region Exp mapping
        /// <summary>
        ///     Map exp game
        /// </summary>
        /// <param name="expGame"></param>
        /// <param name="expBalance"></param>
        public void MapExpGame(ExpGameModel expGame, ExpModel expBalance)
        {
            expGame.Level = expBalance.Level;
            expGame.Exp = expBalance.Exp;
        }
        #endregion

        #region Item mapping
        /// <summary>
        ///     Map item game
        /// </summary>
        /// <param name="itemGame"></param>
        /// <param name="itemBalance"></param>
        public void MapItemGame(ItemGameModel itemGame, ItemModel itemBalance)
        {
            itemGame.ItemId = itemBalance.ItemId;

            itemGame.Type = itemBalance.Type;
            itemGame.EquipType = itemBalance.EquipType;
            itemGame.Name = itemBalance.Name;

            itemGame.DDvMin = itemBalance.DDvMin;
            itemGame.DDvMax = itemBalance.DDvMax;
            itemGame.MDvMin = itemBalance.MDvMin;
            itemGame.MDvMax = itemBalance.MDvMax;
            itemGame.RDvMin = itemBalance.RDvMin;
            itemGame.RDvMax = itemBalance.RDvMax;

            itemGame.DPv = itemBalance.DPv;
            itemGame.MPv = itemBalance.MPv;
            itemGame.RPv = itemBalance.RPv;

            itemGame.Dhit = itemBalance.Dhit;
            itemGame.DDd = itemBalance.DDd;

            itemGame.Rhit = itemBalance.Rhit;
            itemGame.RDd = itemBalance.RDd;

            itemGame.Mhit = itemBalance.Mhit;
            itemGame.MDd = itemBalance.MDd;

            itemGame.Critical = itemBalance.Critical;
            itemGame.CriticalProtect = itemBalance.CriticalProtect;

            itemGame.DDvCriticalAdd = itemBalance.DDvCriticalAdd;
            itemGame.DDvCriticalRemove = itemBalance.DDvCriticalRemove;

            itemGame.HumanKiller = itemBalance.HumanKiller;
            itemGame.HumanProtect = itemBalance.HumanProtect;

            itemGame.MobKiller = itemBalance.MobKiller;
            itemGame.MobProtect = itemBalance.MobProtect;

            itemGame.Str = itemBalance.Str;
            itemGame.Dex = itemBalance.Dex;
            itemGame.Int = itemBalance.Int;

            itemGame.Hp = itemBalance.Hp;
            itemGame.HpRegen = itemBalance.HpRegen;
            itemGame.HpPotionRestore = itemBalance.HpPotionRestore;
            itemGame.AddPotionRestoreHp = itemBalance.AddPotionRestoreHp;
            itemGame.AddTransformMaxHp = itemBalance.AddTransformMaxHp;

            itemGame.Mp = itemBalance.Mp;
            itemGame.MpRegen = itemBalance.MpRegen;
            itemGame.MpPotionRestore = itemBalance.MpPotionRestore;
            itemGame.AddPotionRestoreMp = itemBalance.AddPotionRestoreMp;
            itemGame.AddTransformMaxMp = itemBalance.AddTransformMaxMp;

            itemGame.Weight = itemBalance.Weight;
            itemGame.WeightMax = itemBalance.WeightMax;

            itemGame.IsStack = itemBalance.IsStack;

            itemGame.AttackRate = itemBalance.AttackRate;
            itemGame.AttackRateWhenTransform = itemBalance.AttackRateWhenTransform;

            itemGame.MoveRate = itemBalance.MoveRate;
            itemGame.MoveRateWhenTransform = itemBalance.MoveRateWhenTransform;

            itemGame.DistanceAttack = itemBalance.DistanceAttack;

            itemGame.UseLevel = itemBalance.UseLevel;

            itemGame.UseKnight = itemBalance.UseKnight;
            itemGame.UseRanger = itemBalance.UseRanger;
            itemGame.UseMagician = itemBalance.UseMagician;
            itemGame.UseAssassin = itemBalance.UseAssassin;
            itemGame.UseSummoner = itemBalance.UseSummoner;

            itemGame.UseInAttack = itemBalance.UseInAttack;

            itemGame.Percent = itemBalance.Percent;
        }

        /// <summary>
        ///     Map item game
        /// </summary>
        /// <param name="buffGame"></param>
        /// <param name="buffBalance"></param>
        /// <param name="time"></param>
        public void MapBuffGame(BuffGameModel buffGame, BuffItemModel buffBalance)
        {
            buffGame.Time = buffBalance.Time;
            buffGame.Type = buffBalance.Buff.Type;
            buffGame.BuffId = buffBalance.Buff.BuffId;
            buffGame.Level = buffBalance.Buff.Level;
            buffGame.Name = buffBalance.Buff.Name;
            buffGame.DDvMin = buffBalance.Buff.DDvMin;
            buffGame.DDvMax = buffBalance.Buff.DDvMax;
            buffGame.MDvMin = buffBalance.Buff.MDvMin;
            buffGame.MDvMax = buffBalance.Buff.MDvMax;
            buffGame.RDvMin = buffBalance.Buff.RDvMin;
            buffGame.RDvMax = buffBalance.Buff.RDvMax;
            buffGame.DPv = buffBalance.Buff.DPv;
            buffGame.MPv = buffBalance.Buff.MPv;
            buffGame.RPv = buffBalance.Buff.RPv;
            buffGame.Dhit = buffBalance.Buff.Dhit;
            buffGame.DDd = buffBalance.Buff.DDd;
            buffGame.Rhit = buffBalance.Buff.Rhit;
            buffGame.RDd = buffBalance.Buff.RDd;
            buffGame.Mhit = buffBalance.Buff.Mhit;
            buffGame.MDd = buffBalance.Buff.MDd;
            buffGame.Critical = buffBalance.Buff.Critical;
            buffGame.CriticalProtect = buffBalance.Buff.CriticalProtect;
            buffGame.DDvCriticalAdd = buffBalance.Buff.DDvCriticalAdd;
            buffGame.DDvCriticalRemove = buffBalance.Buff.DDvCriticalRemove;
            buffGame.HumanKiller = buffBalance.Buff.HumanKiller;
            buffGame.HumanProtect = buffBalance.Buff.HumanProtect;
            buffGame.MobKiller = buffBalance.Buff.MobKiller;
            buffGame.MobProtect = buffBalance.Buff.MobProtect;
            buffGame.Str = buffBalance.Buff.Str;
            buffGame.Dex = buffBalance.Buff.Dex;
            buffGame.Int = buffBalance.Buff.Int;
            buffGame.Hp = buffBalance.Buff.Hp;
            buffGame.HpRegen = buffBalance.Buff.HpRegen;
            buffGame.HpPotionRestore = buffBalance.Buff.HpPotionRestore;
            buffGame.AddPotionRestoreHp = buffBalance.Buff.AddPotionRestoreHp;
            buffGame.AddTransformMaxHp = buffBalance.Buff.AddTransformMaxHp;
            buffGame.Mp = buffBalance.Buff.Mp;
            buffGame.MpRegen = buffBalance.Buff.MpRegen;
            buffGame.MpPotionRestore = buffBalance.Buff.MpPotionRestore;
            buffGame.AddPotionRestoreMp = buffBalance.Buff.AddPotionRestoreMp;
            buffGame.AddTransformMaxMp = buffBalance.Buff.AddTransformMaxMp;
            buffGame.WeightMax = buffBalance.Buff.WeightMax;
            buffGame.AttackRate= buffBalance.Buff.AttackRate;
            buffGame.AttackRateWhenTransform = buffBalance.Buff.AttackRateWhenTransform;
            buffGame.MoveRate = buffBalance.Buff.MoveRate;
            buffGame.MoveRateWhenTransform = buffBalance.Buff.MoveRateWhenTransform;
            buffGame.IncExp = buffBalance.Buff.IncExp;
            buffGame.IncDrop = buffBalance.Buff.IncDrop;
            buffGame.IncSilver = buffBalance.Buff.IncSilver;
            buffGame.IsRemovable = buffBalance.Buff.IsRemovable;
        }

        /// <summary>
        ///     Map item reinforce game
        /// </summary>
        /// <param name="itemReinforceGame"></param>
        /// <param name="itemReinforceBalance"></param>
        public void MapItemReinforceGame(ItemReinforceGameModel itemReinforceGame, ItemReinforceModel itemReinforceBalance)
        {
            itemReinforceGame.ItemId = itemReinforceBalance.Item.ItemId;

            itemReinforceGame.ItemOldId = itemReinforceBalance.ItemOld?.ItemId;
            itemReinforceGame.ItemNewId = itemReinforceBalance.ItemNew?.ItemId;

            itemReinforceGame.Item1Id = itemReinforceBalance.Item1.ItemId;
            itemReinforceGame.Item1Count = itemReinforceBalance.Item1Count;

            itemReinforceGame.Item2Id = itemReinforceBalance.Item2?.ItemId;
            itemReinforceGame.Item2Count = itemReinforceBalance.Item2Count;

            itemReinforceGame.Item3Id = itemReinforceBalance.Item3?.ItemId;
            itemReinforceGame.Item3Count = itemReinforceBalance.Item3Count;

            itemReinforceGame.Percent = itemReinforceBalance.Percent;
        }
        #endregion

        #region Unit mapping
        /// <summary>
        ///     Map unit drop game
        /// </summary>
        /// <param name="unitDropGame"></param>
        /// <param name="unitDropBalance"></param>
        public void MapUnitDropGame(UnitDropGameModel unitDropGame, UnitDropModel unitDropBalance)
        {
            unitDropGame.UnitId = unitDropBalance.Unit.UnitId;
            unitDropGame.ItemId = unitDropBalance.Item.ItemId;

            unitDropGame.ItemStatus = unitDropBalance.ItemStatus;
            unitDropGame.UseCount = unitDropBalance.UseCount;
            unitDropGame.EatTime = unitDropBalance.EatTime;
            unitDropGame.TermOfEffectivity = unitDropBalance.TermOfEffectivity;
            unitDropGame.ItemBind = unitDropBalance.ItemBind;
            unitDropGame.CountFrom = unitDropBalance.CountFrom;
            unitDropGame.CountTo = unitDropBalance.CountTo;
            unitDropGame.Percent = unitDropBalance.Percent;
        }

        /// <summary>
        ///     Map unit game
        /// </summary>
        /// <param name="unitGame"></param>
        /// <param name="unitBalance"></param>
        public void MapUnitGame(UnitGameModel unitGame, UnitModel unitBalance)
        {
            unitGame.UnitId = unitBalance.UnitId;

            unitGame.Type = unitBalance.Type;
            unitGame.Name = unitBalance.Name;

            unitGame.Exp = unitBalance.Exp;
            unitGame.Reputation = unitBalance.Reputation;

            unitGame.DDvMin = unitBalance.DDvMin;
            unitGame.DDvMax = unitBalance.DDvMax;

            unitGame.MDvMin = unitBalance.MDvMin;
            unitGame.MDvMax = unitBalance.MDvMax;

            unitGame.RDvMin = unitBalance.RDvMin;
            unitGame.RDvMax = unitBalance.RDvMax;

            unitGame.DPv = unitBalance.DPv;
            unitGame.MPv = unitBalance.MPv;
            unitGame.RPv = unitBalance.RPv;

            unitGame.Dhit = unitBalance.Dhit;
            unitGame.DDd = unitBalance.DDd;

            unitGame.Rhit = unitBalance.Rhit;
            unitGame.RDd = unitBalance.RDd;

            unitGame.Mhit = unitBalance.Mhit;
            unitGame.MDd = unitBalance.MDd;

            unitGame.AttackRate = unitBalance.AttackRate;
            unitGame.MoveRate = unitBalance.MoveRate;

            unitGame.HpMax = unitBalance.HpMax;
            unitGame.HpRegen = unitBalance.HpRegen;
            unitGame.MpMax = unitBalance.MpMax;
            unitGame.MpRegen = unitBalance.MpRegen;

            unitGame.DistanceMove = unitBalance.DistanceMove;
            unitGame.DistanceAttack = unitBalance.DistanceAttack;

            unitGame.IsAggression = unitBalance.IsAggression;
            unitGame.IsAggressionTransformation = unitBalance.IsAggressionTransformation;
            unitGame.DistanceAggression = unitBalance.DistanceAggression;

            unitGame.PaymentType = unitBalance.PaymentType;
            unitGame.Script = unitBalance.Script;
        }

        /// <summary>
        ///     Map unit position game
        /// </summary>
        /// <param name="unitPositionGame"></param>
        /// <param name="unitPositionBalance"></param>
        public void MapUnitPositionGame(UnitPositionGameModel unitPositionGame, UnitPositionModel unitPositionBalance)
        {
            unitPositionGame.UnitId = unitPositionBalance.Unit.UnitId;

            unitPositionGame.Position = new Vector3(unitPositionBalance.X, unitPositionBalance.Y, unitPositionBalance.Z);
            unitPositionGame.DirectionSight = unitPositionBalance.DirectionSight;
            unitPositionGame.Respawn = unitPositionBalance.Respawn;
        }

        /// <summary>
        ///     Map unit purchase game
        /// </summary>
        /// <param name="unitPurchaseGame"></param>
        /// <param name="unitPurchaseBalance"></param>
        public void MapUnitPurchaseGame(UnitPurchaseGameModel unitPurchaseGame, UnitPurchaseModel unitPurchaseBalance)
        {
            unitPurchaseGame.UnitId = unitPurchaseBalance.Unit.UnitId;
            unitPurchaseGame.ItemId = unitPurchaseBalance.Item.ItemId;

            unitPurchaseGame.Price = unitPurchaseBalance.Price;
            unitPurchaseGame.Flag = unitPurchaseBalance.Flag;
            unitPurchaseGame.SortKey = unitPurchaseBalance.SortKey;
        }

        /// <summary>
        ///     Map unit sale game
        /// </summary>
        /// <param name="unitSaleGame"></param>
        /// <param name="unitSaleBalance"></param>
        public void MapUnitSaleGame(UnitSaleGameModel unitSaleGame, UnitSaleModel unitSaleBalance)
        {
            unitSaleGame.ItemId = unitSaleBalance.Item.ItemId;

            unitSaleGame.Price = unitSaleBalance.Price;
        }
        #endregion
    }
}
