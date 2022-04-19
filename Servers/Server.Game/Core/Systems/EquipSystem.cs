using Database.Balance.Enums;
using Server.Game.Models.GameModels;

namespace Server.Game.Core.Systems
{
    public class EquipSystem
    {
        /// <summary>
        ///     Equip item
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="itemGameModel"></param>
        public void EquipItem(CharacterGameModel characterGameModel, ItemGameModel itemGameModel)
        {
            characterGameModel.DDvMin += itemGameModel.DDvMin;
            characterGameModel.DDvMax += itemGameModel.DDvMax;
            characterGameModel.MDvMin += itemGameModel.MDvMin;
            characterGameModel.MDvMax += itemGameModel.MDvMax;
            characterGameModel.RDvMin += itemGameModel.RDvMin;
            characterGameModel.RDvMax += itemGameModel.RDvMax;

            characterGameModel.DPv += itemGameModel.DPv;
            characterGameModel.MPv += itemGameModel.MPv;
            characterGameModel.RPv += itemGameModel.RPv;

            characterGameModel.DHit += itemGameModel.Dhit;
            characterGameModel.DDd += itemGameModel.DDd;

            characterGameModel.RHit += itemGameModel.Rhit;
            characterGameModel.RDd += itemGameModel.RDd;

            characterGameModel.MHit += itemGameModel.Mhit;
            characterGameModel.MDd += itemGameModel.MDd;

            characterGameModel.Critical += itemGameModel.Critical;
            characterGameModel.CriticalProtect += itemGameModel.CriticalProtect;

            characterGameModel.DDvCriticalAdd += itemGameModel.DDvCriticalAdd;
            characterGameModel.DDvCriticalRemove += itemGameModel.DDvCriticalRemove;

            characterGameModel.HumanKiller += itemGameModel.HumanKiller;
            characterGameModel.HumanProtect += itemGameModel.HumanProtect;

            characterGameModel.MobKiller += itemGameModel.MobKiller;
            characterGameModel.MobProtect += itemGameModel.MobProtect;

            characterGameModel.Str += itemGameModel.Str;
            characterGameModel.Dex += itemGameModel.Dex;
            characterGameModel.Int += itemGameModel.Int;

            characterGameModel.HpMax += itemGameModel.Hp;
            characterGameModel.HpRegen += itemGameModel.HpRegen;
            characterGameModel.HpPotionRestore += itemGameModel.HpPotionRestore;
            characterGameModel.AddPotionRestoreHp += itemGameModel.AddPotionRestoreHp;
            characterGameModel.AddTransformMaxHp += itemGameModel.AddTransformMaxHp;

            characterGameModel.MpMax += itemGameModel.Mp;
            characterGameModel.MpRegen += itemGameModel.MpRegen;
            characterGameModel.MpPotionRestore += itemGameModel.MpPotionRestore;
            characterGameModel.AddPotionRestoreMp += itemGameModel.AddPotionRestoreMp;
            characterGameModel.AddTransformMaxMp += itemGameModel.AddTransformMaxMp;

            characterGameModel.WeightMax += itemGameModel.WeightMax;

            characterGameModel.AttackRate -= itemGameModel.AttackRate;
            characterGameModel.AttackRateWhenTransform += itemGameModel.AttackRateWhenTransform;

            characterGameModel.MoveRate += itemGameModel.MoveRate;
            characterGameModel.MoveRateWhenTransform += itemGameModel.MoveRateWhenTransform;

            if (itemGameModel.EquipType == ItemEquipType.Weapon)
            {
                characterGameModel.DistanceAttack = itemGameModel.DistanceAttack;
            }
        }

        /// <summary>
        ///     Un equip item
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="itemGameModel"></param>
        public void UnEquipItem(CharacterGameModel characterGameModel, ItemGameModel itemGameModel)
        {
            characterGameModel.DDvMin -= itemGameModel.DDvMin;
            characterGameModel.DDvMax -= itemGameModel.DDvMax;
            characterGameModel.MDvMin -= itemGameModel.MDvMin;
            characterGameModel.MDvMax -= itemGameModel.MDvMax;
            characterGameModel.RDvMin -= itemGameModel.RDvMin;
            characterGameModel.RDvMax -= itemGameModel.RDvMax;

            characterGameModel.DPv -= itemGameModel.DPv;
            characterGameModel.MPv -= itemGameModel.MPv;
            characterGameModel.RPv -= itemGameModel.RPv;

            characterGameModel.DHit -= itemGameModel.Dhit;
            characterGameModel.DDd -= itemGameModel.DDd;

            characterGameModel.RHit -= itemGameModel.Rhit;
            characterGameModel.RDd -= itemGameModel.RDd;

            characterGameModel.MHit -= itemGameModel.Mhit;
            characterGameModel.MDd -= itemGameModel.MDd;

            characterGameModel.Critical -= itemGameModel.Critical;
            characterGameModel.CriticalProtect -= itemGameModel.CriticalProtect;

            characterGameModel.DDvCriticalAdd -= itemGameModel.DDvCriticalAdd;
            characterGameModel.DDvCriticalRemove -= itemGameModel.DDvCriticalRemove;

            characterGameModel.HumanKiller -= itemGameModel.HumanKiller;
            characterGameModel.HumanProtect -= itemGameModel.HumanProtect;

            characterGameModel.MobKiller -= itemGameModel.MobKiller;
            characterGameModel.MobProtect -= itemGameModel.MobProtect;

            characterGameModel.Str -= itemGameModel.Str;
            characterGameModel.Dex -= itemGameModel.Dex;
            characterGameModel.Int -= itemGameModel.Int;

            characterGameModel.HpMax -= itemGameModel.Hp;
            characterGameModel.HpRegen -= itemGameModel.HpRegen;
            characterGameModel.HpPotionRestore -= itemGameModel.HpPotionRestore;
            characterGameModel.AddPotionRestoreHp -= itemGameModel.AddPotionRestoreHp;
            characterGameModel.AddTransformMaxHp -= itemGameModel.AddTransformMaxHp;

            characterGameModel.MpMax -= itemGameModel.Mp;
            characterGameModel.MpRegen -= itemGameModel.MpRegen;
            characterGameModel.MpPotionRestore -= itemGameModel.MpPotionRestore;
            characterGameModel.AddPotionRestoreMp -= itemGameModel.AddPotionRestoreMp;
            characterGameModel.AddTransformMaxMp -= itemGameModel.AddTransformMaxMp;

            characterGameModel.WeightMax -= itemGameModel.WeightMax;

            characterGameModel.AttackRate += itemGameModel.AttackRate;
            characterGameModel.AttackRateWhenTransform -= itemGameModel.AttackRateWhenTransform;

            characterGameModel.MoveRate -= itemGameModel.MoveRate;
            characterGameModel.MoveRateWhenTransform -= itemGameModel.MoveRateWhenTransform;

            characterGameModel.DistanceAttack -= itemGameModel.DistanceAttack;
        }
    }
}
