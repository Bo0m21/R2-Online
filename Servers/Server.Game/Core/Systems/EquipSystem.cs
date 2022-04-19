using Database.DataModel.Enums;
using Server.Game.Models.Game;

namespace Server.Game.Core.Systems
{
    public class EquipSystem
    {
        /// <summary>
        ///     Equip item
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="itemGameModel"></param>
        public void EquipItem(GPc characterGameModel, GItem itemGameModel)
        {
            //characterGameModel.DDv += itemGameModel.DDv;
            //characterGameModel.MDv += itemGameModel.MDv;
            //characterGameModel.RDv += itemGameModel.RDv;

            //characterGameModel.DPv += itemGameModel.DPv;
            //characterGameModel.MPv += itemGameModel.MPv;
            //characterGameModel.RPv += itemGameModel.RPv;

            //characterGameModel.DHit += itemGameModel.DHit;
            //characterGameModel.DDdMin += itemGameModel.DDdMin;
            //characterGameModel.DDdMax += itemGameModel.DDdMax;

            //characterGameModel.RHit += itemGameModel.RHit;
            //characterGameModel.RDdMin += itemGameModel.RDdMin;
            //characterGameModel.RDdMax += itemGameModel.RDdMax;

            //characterGameModel.MHit += itemGameModel.MHit;
            //characterGameModel.MDdMin += itemGameModel.MDdMin;
            //characterGameModel.MDdMax += itemGameModel.MDdMax;

            //characterGameModel.Critical += itemGameModel.Critical;
            //characterGameModel.CriticalProtect += itemGameModel.EnemySubCriticalHit;

            //characterGameModel.DDvCriticalAdd += itemGameModel.AddDDWhenCritical;
            //characterGameModel.DDvCriticalRemove += itemGameModel.SubDDWhenCritical;

            //characterGameModel.HumanKiller += itemGameModel.HumanKiller;
            //characterGameModel.HumanProtect += itemGameModel.HumanProtect;

            //characterGameModel.MobKiller += itemGameModel.MobKiller;
            //characterGameModel.MobProtect += itemGameModel.MobProtect;

            //characterGameModel.Str += itemGameModel.Str;
            //characterGameModel.Dex += itemGameModel.Dex;
            //characterGameModel.Int += itemGameModel.Int;

            //characterGameModel.HpMax += itemGameModel.HpPlus;
            //characterGameModel.HpRegen += itemGameModel.HpRegen;
            //characterGameModel.HpPotionRestore += itemGameModel.HpPotionRestore;
            //characterGameModel.AddPotionRestoreHp += itemGameModel.AddHpPotionRestore;
            //characterGameModel.AddTransformMaxHp += itemGameModel.AddMaxHpWhenTransform;

            //characterGameModel.MpMax += itemGameModel.Mpplus;
            //characterGameModel.MpRegen += itemGameModel.MpRegen;
            //characterGameModel.MpPotionRestore += itemGameModel.MpPotionRestore;
            //characterGameModel.AddPotionRestoreMp += itemGameModel.AddMpPotionRestore;
            //characterGameModel.AddTransformMaxMp += itemGameModel.AddMaxMpWhenTransform;

            //characterGameModel.WeightMax += itemGameModel.AddWeight;

            //characterGameModel.AttackRate -= itemGameModel.AttackRate;
            //characterGameModel.AttackRateWhenTransform += itemGameModel.AddAttackRateWhenTransform;

            //characterGameModel.MoveRate += itemGameModel.MoveRate;
            //characterGameModel.MoveRateWhenTransform += itemGameModel.AddMoveRateWhenTransform;

            //if (itemGameModel.EquipType == ItemEquipTypeEnum.Weapon)
            //{
            //    characterGameModel.DistanceAttack = itemGameModel.AddShortAttackRange;
            //}
        }

        /// <summary>
        ///     Un equip item
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="itemGameModel"></param>
        public void UnEquipItem(GPc characterGameModel, GItem itemGameModel)
        {
            //characterGameModel.DDv -= itemGameModel.DDv;
            //characterGameModel.MDv -= itemGameModel.MDv;
            //characterGameModel.RDv -= itemGameModel.RDv;

            //characterGameModel.DPv -= itemGameModel.DPv;
            //characterGameModel.MPv -= itemGameModel.MPv;
            //characterGameModel.RPv -= itemGameModel.RPv;

            //characterGameModel.DHit -= itemGameModel.DHit;
            //characterGameModel.DDdMin -= itemGameModel.DDdMin;
            //characterGameModel.DDdMax -= itemGameModel.DDdMax;

            //characterGameModel.RHit -= itemGameModel.RHit;
            //characterGameModel.RDdMin -= itemGameModel.RDdMin;
            //characterGameModel.RDdMax -= itemGameModel.RDdMax;

            //characterGameModel.MHit -= itemGameModel.MHit;
            //characterGameModel.MDdMin -= itemGameModel.MDdMin;
            //characterGameModel.MDdMax -= itemGameModel.MDdMax;

            //characterGameModel.Critical -= itemGameModel.Critical;
            //characterGameModel.CriticalProtect -= itemGameModel.EnemySubCriticalHit;

            //characterGameModel.DDvCriticalAdd -= itemGameModel.AddDDWhenCritical;
            //characterGameModel.DDvCriticalRemove -= itemGameModel.SubDDWhenCritical;

            //characterGameModel.HumanKiller -= itemGameModel.HumanKiller;
            //characterGameModel.HumanProtect -= itemGameModel.HumanProtect;

            //characterGameModel.MobKiller -= itemGameModel.MobKiller;
            //characterGameModel.MobProtect -= itemGameModel.MobProtect;

            //characterGameModel.Str -= itemGameModel.Str;
            //characterGameModel.Dex -= itemGameModel.Dex;
            //characterGameModel.Int -= itemGameModel.Int;

            //characterGameModel.HpMax -= itemGameModel.HpPlus;
            //characterGameModel.HpRegen -= itemGameModel.HpRegen;
            //characterGameModel.HpPotionRestore -= itemGameModel.HpPotionRestore;
            //characterGameModel.AddPotionRestoreHp -= itemGameModel.AddHpPotionRestore;
            //characterGameModel.AddTransformMaxHp -= itemGameModel.AddMaxHpWhenTransform;

            //characterGameModel.MpMax -= itemGameModel.Mpplus;
            //characterGameModel.MpRegen -= itemGameModel.MpRegen;
            //characterGameModel.MpPotionRestore -= itemGameModel.MpPotionRestore;
            //characterGameModel.AddPotionRestoreMp -= itemGameModel.AddMpPotionRestore;
            //characterGameModel.AddTransformMaxMp -= itemGameModel.AddMaxMpWhenTransform;

            //characterGameModel.WeightMax -= itemGameModel.AddWeight;

            //characterGameModel.AttackRate += itemGameModel.AttackRate;
            //characterGameModel.AttackRateWhenTransform -= itemGameModel.AddAttackRateWhenTransform;

            //characterGameModel.MoveRate -= itemGameModel.MoveRate;
            //characterGameModel.MoveRateWhenTransform -= itemGameModel.AddMoveRateWhenTransform;

            //characterGameModel.DistanceAttack -= itemGameModel.AddShortAttackRange;
        }
    }
}
