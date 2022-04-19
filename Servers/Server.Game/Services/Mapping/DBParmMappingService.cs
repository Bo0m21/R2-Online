using Database.DataModel.Enums;
using Database.DataModel.Models;
using Database.Parm.Models;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using System;
using System.Linq;

namespace Server.Game.Services
{
    /// <summary>
    ///     Database balance mapping service
    /// </summary>
    public class DBParmMappingService
    {
        #region Character mapping
        /// <summary>
        ///     Map character game
        /// </summary>
        /// <param name="characterGame"></param>
        /// <param name="characterBalance"></param>
        /// <returns></returns>
        public void MapCharacterGame(GPc characterGame, CharacterModel characterBalance)
        {
            //characterGame.DDvMin = characterBalance.DDvMin;
            //characterGame.DDvMax = characterBalance.DDvMax;
            //characterGame.MDvMin = characterBalance.MDvMin;
            //characterGame.MDvMax = characterBalance.MDvMax;
            //characterGame.RDvMin = characterBalance.RDvMin;
            //characterGame.RDvMax = characterBalance.RDvMax;

            //characterGame.DPv = characterBalance.DPv;
            //characterGame.MPv = characterBalance.MPv;
            //characterGame.RPv = characterBalance.RPv;

            //characterGame.DHit = characterBalance.Dhit;
            //characterGame.DDd = characterBalance.DDd;

            //characterGame.RHit = characterBalance.Rhit;
            //characterGame.RDd = characterBalance.RDd;

            //characterGame.MHit = characterBalance.Mhit;
            //characterGame.MDd = characterBalance.MDd;

            //characterGame.Str = characterBalance.Str;
            //characterGame.Dex = characterBalance.Dex;
            //characterGame.Int = characterBalance.Int;

            //characterGame.HpMax = characterBalance.HpMax;
            //characterGame.HpRegen = characterBalance.HpRegen;

            //characterGame.MpMax = characterBalance.MpMax;
            //characterGame.MpRegen = characterBalance.MpRegen;

            //characterGame.WeightMax = characterBalance.WeightMax;

            //characterGame.AttackRate = characterBalance.AttackRate;
            //characterGame.MoveRate = characterBalance.MoveRate;

            //characterGame.DistanceAttack = 300; // TODO to db balance

            //characterGame.IsVsibleFirst = true;
        }

        /// <summary>
        ///     Map character position game
        /// </summary>
        /// <param name="characterPositionGame"></param>
        /// <param name="characterPositionBalance"></param>
        public void MapCharacterPositionGame(GCharacterPosition characterPositionGame, CharacterPositionModel characterPositionBalance)
        {
            characterPositionGame.Class = (CharacterTypeEnum)characterPositionBalance.Class;
            characterPositionGame.Position = new Vector3(characterPositionBalance.X, characterPositionBalance.Y, characterPositionBalance.Z);
        }
        #endregion

        #region Exp mapping
        /// <summary>
        ///     Map exp game
        /// </summary>
        /// <param name="expGame"></param>
        /// <param name="expBalance"></param>
        public void MapExpGame(GExp expGame, ExpModel expBalance)
        {
            expGame.Level = expBalance.Level;
            expGame.Exp = (ulong)expBalance.Exp;
        }
        #endregion

        #region Item mapping
        /// <summary>
        ///     Map item game
        /// </summary>
        /// <param name="itemGame"></param>
        /// <param name="item"></param>
        public void MapItemGame(GItem itemGame, Item item)
        {
            itemGame.Id = item.Id;

            itemGame.Type = item.Type;
            itemGame.EquipType = item.GetEquipType();
            itemGame.Name = item.Name;

            itemGame.DDv = item.DDv;
            itemGame.MDv = item.MDv;
            itemGame.RDv = item.RDv;

            itemGame.DPv = item.DPv;
            itemGame.MPv = item.MPv;
            itemGame.RPv = item.RPv;

            var ddd = GetDdFromSting(item.DDd);
            itemGame.DHit = item.DHit;
            itemGame.DDdMin = ddd[0];
            itemGame.DDdMax = ddd[1];

            var rdd = GetDdFromSting(item.RDd);
            itemGame.RHit = item.RHit;
            itemGame.RDdMin = rdd[0];
            itemGame.RDdMax = rdd[1];

            var mdd = GetDdFromSting(item.MDd);
            itemGame.MHit = item.MHit;
            itemGame.MDdMin = mdd[0];
            itemGame.MDdMax = mdd[1];

            itemGame.Critical = item.Critical;
            itemGame.EnemySubCriticalHit = item.EnemySubCriticalHit;

            itemGame.AddDDWhenCritical = item.AddDDWhenCritical;
            itemGame.SubDDWhenCritical = item.SubDDWhenCritical;

            itemGame.Str = item.Str;
            itemGame.Dex = item.Dex;
            itemGame.Int = item.Int;

            itemGame.HpPlus = item.HpPlus;
            itemGame.HpRegen = item.HpRegen;
            //itemGame.HpPotionRestore = itemModel.HpPotionRestore;
            itemGame.AddHpPotionRestore = item.AddHpPotionRestore;
            itemGame.AddMaxHpWhenTransform = item.AddMaxHpWhenTransform;

            itemGame.Mpplus = item.Mpplus;
            itemGame.MpRegen = item.MpRegen;
            //TODO MpPotionRestore
            //itemGame.MpPotionRestore = itemModel.AddPotionRestore;
            itemGame.AddMpPotionRestore = item.AddMpPotionRestore;
            itemGame.AddMaxMpWhenTransform = item.AddMaxMpWhenTransform;

            itemGame.Weight = item.Weight;
            itemGame.AddWeight = item.AddWeight;

            itemGame.MaxStack = item.MaxStack;

            itemGame.AttackRate = item.AttackRate;
            itemGame.AddAttackRateWhenTransform = item.AddAttackRateWhenTransform;

            itemGame.MoveRate = item.MoveRate;
            itemGame.AddMoveRateWhenTransform = item.AddMoveRateWhenTransform;

            itemGame.AddShortAttackRange = item.Range;

            itemGame.UseLevel = item.UseLevel;

            itemGame.UseClass = item.UseClass;
            itemGame.UseInAttack = item.UseInAttack;
        }

        /// <summary>
        ///     Map item game
        /// </summary>
        /// <param name="buffGame"></param>
        /// <param name="buffBalance"></param>
        /// <param name="time"></param>
        //public void MapBuffGame(BuffGameModel buffGame, BuffItemModel buffBalance)
        //{
        //    buffGame.Time = buffBalance.Time;
        //    buffGame.Type = buffBalance.Buff.Type;
        //    buffGame.BuffId = buffBalance.Buff.BuffId;
        //    buffGame.Level = buffBalance.Buff.Level;
        //    buffGame.Name = buffBalance.Buff.Name;
        //    buffGame.DDvMin = buffBalance.Buff.DDvMin;
        //    buffGame.DDvMax = buffBalance.Buff.DDvMax;
        //    buffGame.MDvMin = buffBalance.Buff.MDvMin;
        //    buffGame.MDvMax = buffBalance.Buff.MDvMax;
        //    buffGame.RDvMin = buffBalance.Buff.RDvMin;
        //    buffGame.RDvMax = buffBalance.Buff.RDvMax;
        //    buffGame.DPv = buffBalance.Buff.DPv;
        //    buffGame.MPv = buffBalance.Buff.MPv;
        //    buffGame.RPv = buffBalance.Buff.RPv;
        //    buffGame.Dhit = buffBalance.Buff.Dhit;
        //    buffGame.DDd = buffBalance.Buff.DDd;
        //    buffGame.Rhit = buffBalance.Buff.Rhit;
        //    buffGame.RDd = buffBalance.Buff.RDd;
        //    buffGame.Mhit = buffBalance.Buff.Mhit;
        //    buffGame.MDd = buffBalance.Buff.MDd;
        //    buffGame.Critical = buffBalance.Buff.Critical;
        //    buffGame.CriticalProtect = buffBalance.Buff.CriticalProtect;
        //    buffGame.DDvCriticalAdd = buffBalance.Buff.DDvCriticalAdd;
        //    buffGame.DDvCriticalRemove = buffBalance.Buff.DDvCriticalRemove;
        //    buffGame.HumanKiller = buffBalance.Buff.HumanKiller;
        //    buffGame.HumanProtect = buffBalance.Buff.HumanProtect;
        //    buffGame.MobKiller = buffBalance.Buff.MobKiller;
        //    buffGame.MobProtect = buffBalance.Buff.MobProtect;
        //    buffGame.Str = buffBalance.Buff.Str;
        //    buffGame.Dex = buffBalance.Buff.Dex;
        //    buffGame.Int = buffBalance.Buff.Int;
        //    buffGame.Hp = buffBalance.Buff.Hp;
        //    buffGame.HpRegen = buffBalance.Buff.HpRegen;
        //    buffGame.HpPotionRestore = buffBalance.Buff.HpPotionRestore;
        //    buffGame.AddPotionRestoreHp = buffBalance.Buff.AddPotionRestoreHp;
        //    buffGame.AddTransformMaxHp = buffBalance.Buff.AddTransformMaxHp;
        //    buffGame.Mp = buffBalance.Buff.Mp;
        //    buffGame.MpRegen = buffBalance.Buff.MpRegen;
        //    buffGame.MpPotionRestore = buffBalance.Buff.MpPotionRestore;
        //    buffGame.AddPotionRestoreMp = buffBalance.Buff.AddPotionRestoreMp;
        //    buffGame.AddTransformMaxMp = buffBalance.Buff.AddTransformMaxMp;
        //    buffGame.WeightMax = buffBalance.Buff.WeightMax;
        //    buffGame.AttackRate = buffBalance.Buff.AttackRate;
        //    buffGame.AttackRateWhenTransform = buffBalance.Buff.AttackRateWhenTransform;
        //    buffGame.MoveRate = buffBalance.Buff.MoveRate;
        //    buffGame.MoveRateWhenTransform = buffBalance.Buff.MoveRateWhenTransform;
        //    buffGame.IncExp = buffBalance.Buff.IncExp;
        //    buffGame.IncDrop = buffBalance.Buff.IncDrop;
        //    buffGame.IncSilver = buffBalance.Buff.IncSilver;
        //    buffGame.IsRemovable = buffBalance.Buff.IsRemovable;
        //}

        /// <summary>
        ///     Map item reinforce game
        /// </summary>
        /// <param name="itemReinforceGame"></param>
        /// <param name="itemReinforceBalance"></param>
        //public void MapItemReinforceGame(ItemReinforceGameModel itemReinforceGame, ItemReinforceModel itemReinforceBalance)
        //{
        //    itemReinforceGame.ItemId = itemReinforceBalance.Item.ItemId;

        //    itemReinforceGame.ItemOldId = itemReinforceBalance.ItemOld?.ItemId;
        //    itemReinforceGame.ItemNewId = itemReinforceBalance.ItemNew?.ItemId;

        //    itemReinforceGame.Item1Id = itemReinforceBalance.Item1.ItemId;
        //    itemReinforceGame.Item1Count = itemReinforceBalance.Item1Count;

        //    itemReinforceGame.Item2Id = itemReinforceBalance.Item2?.ItemId;
        //    itemReinforceGame.Item2Count = itemReinforceBalance.Item2Count;

        //    itemReinforceGame.Item3Id = itemReinforceBalance.Item3?.ItemId;
        //    itemReinforceGame.Item3Count = itemReinforceBalance.Item3Count;

        //    itemReinforceGame.Percent = itemReinforceBalance.Percent;
        //}
        #endregion

        #region Unit mapping
        /// <summary>
        ///     Map unit drop game
        /// </summary>
        /// <param name="unitDropGame"></param>
        /// <param name="unitDropBalance"></param>
        //public void MapUnitDropGame(UnitDropGameModel unitDropGame, MonsterDropModel unitDropBalance)
        //{
        //    unitDropGame.UnitId = unitDropBalance.Unit.UnitId;
        //    unitDropGame.ItemId = unitDropBalance.Item.ItemId;

        //    unitDropGame.ItemStatus = unitDropBalance.ItemStatus;
        //    unitDropGame.UseCount = unitDropBalance.UseCount;
        //    unitDropGame.EatTime = unitDropBalance.EatTime;
        //    unitDropGame.TermOfEffectivity = unitDropBalance.TermOfEffectivity;
        //    unitDropGame.ItemBind = unitDropBalance.ItemBind;
        //    unitDropGame.Count = unitDropBalance.Count;
        //    unitDropGame.Percent = unitDropBalance.Percent;
        //}

        /// <summary>
        ///     Map unit game
        /// </summary>
        /// <param name="monsterGame"></param>
        /// <param name="monster"></param>
        public void MapMonstertGame(GMonster monsterGame, Monster monster)
        {
            monsterGame._SetDefaultInfo(new ParmMonster(monster));

            // Set general fields
            monsterGame.IsVsibleFirst = true;

            // Set default position for unit
            //monsterGame.PositionDefault = unitPositionGame.Position;
            //monsterGame.DirectionSightDefault = unitPositionGame.DirectionSight;
            //monsterGame.Respawn = unitPositionGame.Respawn;
        }

        /// <summary>
        ///     Map unit position game
        /// </summary>
        /// <param name="unitPositionGame"></param>
        /// <param name="unitPositionBalance"></param>
        //public void MapUnitPositionGame(GUnitPosition unitPositionGame, UnitPositionModel unitPositionBalance)
        //{
        //    unitPositionGame.UnitId = unitPositionBalance.Unit.UnitId;

        //    unitPositionGame.Position = new Vector3(unitPositionBalance.X, unitPositionBalance.Y, unitPositionBalance.Z);
        //    unitPositionGame.DirectionSight = unitPositionBalance.DirectionSight;
        //    unitPositionGame.Respawn = unitPositionBalance.Respawn;
        //}

        /// <summary>
        ///     Map unit purchase game
        /// </summary>
        /// <param name="unitPurchaseGame"></param>
        /// <param name="unitPurchaseBalance"></param>
        //public void MapUnitPurchaseGame(GUnitPurchase unitPurchaseGame, UnitPurchaseModel unitPurchaseBalance)
        //{
        //    unitPurchaseGame.UnitId = unitPurchaseBalance.Unit.UnitId;
        //    unitPurchaseGame.ItemId = unitPurchaseBalance.Item.ItemId;

        //    unitPurchaseGame.Price = unitPurchaseBalance.Price;
        //    unitPurchaseGame.Flag = unitPurchaseBalance.Flag;
        //    unitPurchaseGame.SortKey = unitPurchaseBalance.SortKey;
        //}

        /// <summary>
        ///     Map unit sale game
        /// </summary>
        /// <param name="unitSaleGame"></param>
        /// <param name="unitSaleBalance"></param>
        //public void MapUnitSaleGame(GUnitSale unitSaleGame, UnitSaleModel unitSaleBalance)
        //{
        //    unitSaleGame.ItemId = unitSaleBalance.Item.ItemId;

        //    unitSaleGame.Price = unitSaleBalance.Price;
        //}
        #endregion

        private ItemEquipTypeEnum? MapEquipType(ItemTypeEnum type)
        {
            ItemEquipTypeEnum? equipType = null;
            switch (type)
            {
                case ItemTypeEnum.Weapon:
                    equipType = ItemEquipTypeEnum.Weapon;
                    break;
                case ItemTypeEnum.Shield:
                    equipType = ItemEquipTypeEnum.Shield;
                    break;
                case ItemTypeEnum.Armor:
                    equipType = ItemEquipTypeEnum.Armor;
                    break;
                case ItemTypeEnum.Ring:
                    equipType = ItemEquipTypeEnum.Ring1;
                    break;
                case ItemTypeEnum.Amulet:
                    equipType = ItemEquipTypeEnum.Amulet;
                    break;
                case ItemTypeEnum.Boot:
                    equipType = ItemEquipTypeEnum.Boot;
                    break;
                case ItemTypeEnum.Glove:
                    equipType = ItemEquipTypeEnum.Glove;
                    break;
                case ItemTypeEnum.Cap:
                    equipType = ItemEquipTypeEnum.Cap;
                    break;
                case ItemTypeEnum.Belt:
                    equipType = ItemEquipTypeEnum.Belt;
                    break;
                case ItemTypeEnum.Cloak:
                    equipType = ItemEquipTypeEnum.Cloak;
                    break;
                case ItemTypeEnum.Arrow:
                    equipType = ItemEquipTypeEnum.Shield;
                    break;
                case ItemTypeEnum.ExpertnessMaterial:
                    equipType = ItemEquipTypeEnum.ExpertnessMaterial;
                    break;
                case ItemTypeEnum.SoulMaterial:
                    equipType = ItemEquipTypeEnum.SoulMaterial;
                    break;
                case ItemTypeEnum.DefenseMaterial:
                    equipType = ItemEquipTypeEnum.DefenseMaterial;
                    break;
                case ItemTypeEnum.AttackMaterial:
                    equipType = ItemEquipTypeEnum.AttackMaterial;
                    break;
                case ItemTypeEnum.LifeMaterial:
                    equipType = ItemEquipTypeEnum.LifeMaterial;
                    break;
                case ItemTypeEnum.EventAMaterial:
                    equipType = ItemEquipTypeEnum.EventAMaterial;
                    break;
                case ItemTypeEnum.EventBMaterial:
                    equipType = ItemEquipTypeEnum.EventBMaterial;
                    break;
                case ItemTypeEnum.EventCMaterial:
                    equipType = ItemEquipTypeEnum.EventCMaterial;
                    break;
                case ItemTypeEnum.Servant:
                    equipType = ItemEquipTypeEnum.Servant;
                    break;
                default:
                    break;
            }

            return equipType;
        }

        private int[] GetDdFromSting(string dd)
        {
            var d = dd.ToLower().Split('d', '+');
            var ddd = new int[3];

            ddd[0] = int.Parse(d[0]);
            ddd[1] = int.Parse(d[1]);
            ddd[2] = int.Parse(d[2]);

            ddd[0] = ddd[0] + ddd[2];
            ddd[1] = ddd[1] + ddd[2];

            return new int[2] { ddd[0], ddd[1] };
        }
    }
}
