using Server.Game.Models.Game;

namespace Server.Game.Core.Systems
{
    public class AbnormalSystem
    {
        /// <summary>
        ///     Abnormal add
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="buffGameModel"></param>
        //public void AbnormalAdd(GPc characterGameModel, GBuff buffGameModel)
        //{
        //    characterGameModel.DDvMin += buffGameModel.DDvMin;
        //    characterGameModel.DDvMax += buffGameModel.DDvMax;
        //    characterGameModel.MDvMin += buffGameModel.MDvMin;
        //    characterGameModel.MDvMax += buffGameModel.MDvMax;
        //    characterGameModel.RDvMin += buffGameModel.RDvMin;
        //    characterGameModel.RDvMax += buffGameModel.RDvMax;

        //    characterGameModel.DPv += buffGameModel.DPv;
        //    characterGameModel.MPv += buffGameModel.MPv;
        //    characterGameModel.RPv += buffGameModel.RPv;

        //    characterGameModel.DHit += buffGameModel.Dhit;
        //    characterGameModel.DDd += buffGameModel.DDd;

        //    characterGameModel.RHit += buffGameModel.Rhit;
        //    characterGameModel.RDd += buffGameModel.RDd;

        //    characterGameModel.MHit += buffGameModel.Mhit;
        //    characterGameModel.MDd += buffGameModel.MDd;

        //    characterGameModel.Critical += buffGameModel.Critical;
        //    characterGameModel.CriticalProtect += buffGameModel.CriticalProtect;

        //    characterGameModel.DDvCriticalAdd += buffGameModel.DDvCriticalAdd;
        //    characterGameModel.DDvCriticalRemove += buffGameModel.DDvCriticalRemove;

        //    characterGameModel.HumanKiller += buffGameModel.HumanKiller;
        //    characterGameModel.HumanProtect += buffGameModel.HumanProtect;

        //    characterGameModel.MobKiller += buffGameModel.MobKiller;
        //    characterGameModel.MobProtect += buffGameModel.MobProtect;

        //    characterGameModel.Str += buffGameModel.Str;
        //    characterGameModel.Dex += buffGameModel.Dex;
        //    characterGameModel.Int += buffGameModel.Int;

        //    characterGameModel.HpMax += buffGameModel.Hp;
        //    characterGameModel.HpRegen += buffGameModel.HpRegen;
        //    characterGameModel.HpPotionRestore += buffGameModel.HpPotionRestore;
        //    characterGameModel.AddPotionRestoreHp += buffGameModel.AddPotionRestoreHp;
        //    characterGameModel.AddTransformMaxHp += buffGameModel.AddTransformMaxHp;

        //    characterGameModel.MpMax += buffGameModel.Mp;
        //    characterGameModel.MpRegen += buffGameModel.MpRegen;
        //    characterGameModel.MpPotionRestore += buffGameModel.MpPotionRestore;
        //    characterGameModel.AddPotionRestoreMp += buffGameModel.AddPotionRestoreMp;
        //    characterGameModel.AddTransformMaxMp += buffGameModel.AddTransformMaxMp;

        //    characterGameModel.WeightMax += buffGameModel.WeightMax;

        //    characterGameModel.AttackRate -= buffGameModel.AttackRate;
        //    characterGameModel.AttackRateWhenTransform += buffGameModel.AttackRateWhenTransform;

        //    characterGameModel.MoveRate += buffGameModel.MoveRate;
        //    characterGameModel.MoveRateWhenTransform += buffGameModel.MoveRateWhenTransform;

        //    //TODO Drop, exp, incSilver
        //}

        /// <summary>
        ///     Abnormal remove
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="buffGameModel"></param>
        //public void AbnormalRemove(GPc characterGameModel, GBuff buffGameModel)
        //{
        //    characterGameModel.DDvMin -= buffGameModel.DDvMin;
        //    characterGameModel.DDvMax -= buffGameModel.DDvMax;
        //    characterGameModel.MDvMin -= buffGameModel.MDvMin;
        //    characterGameModel.MDvMax -= buffGameModel.MDvMax;
        //    characterGameModel.RDvMin -= buffGameModel.RDvMin;
        //    characterGameModel.RDvMax -= buffGameModel.RDvMax;

        //    characterGameModel.DPv -= buffGameModel.DPv;
        //    characterGameModel.MPv -= buffGameModel.MPv;
        //    characterGameModel.RPv -= buffGameModel.RPv;

        //    characterGameModel.DHit -= buffGameModel.Dhit;
        //    characterGameModel.DDd -= buffGameModel.DDd;

        //    characterGameModel.RHit -= buffGameModel.Rhit;
        //    characterGameModel.RDd -= buffGameModel.RDd;

        //    characterGameModel.MHit -= buffGameModel.Mhit;
        //    characterGameModel.MDd -= buffGameModel.MDd;

        //    characterGameModel.Critical -= buffGameModel.Critical;
        //    characterGameModel.CriticalProtect -= buffGameModel.CriticalProtect;

        //    characterGameModel.DDvCriticalAdd -= buffGameModel.DDvCriticalAdd;
        //    characterGameModel.DDvCriticalRemove -= buffGameModel.DDvCriticalRemove;

        //    characterGameModel.HumanKiller -= buffGameModel.HumanKiller;
        //    characterGameModel.HumanProtect -= buffGameModel.HumanProtect;

        //    characterGameModel.MobKiller -= buffGameModel.MobKiller;
        //    characterGameModel.MobProtect -= buffGameModel.MobProtect;

        //    characterGameModel.Str -= buffGameModel.Str;
        //    characterGameModel.Dex -= buffGameModel.Dex;
        //    characterGameModel.Int -= buffGameModel.Int;

        //    characterGameModel.HpMax -= buffGameModel.Hp;
        //    characterGameModel.HpRegen -= buffGameModel.HpRegen;
        //    characterGameModel.HpPotionRestore -= buffGameModel.HpPotionRestore; //TODO возможно это не нужно, т.к. HpPotionRestore для зелий хп/мп
        //    characterGameModel.AddPotionRestoreHp -= buffGameModel.AddPotionRestoreHp;
        //    characterGameModel.AddTransformMaxHp -= buffGameModel.AddTransformMaxHp;

        //    characterGameModel.MpMax -= buffGameModel.Mp;
        //    characterGameModel.MpRegen -= buffGameModel.MpRegen;
        //    characterGameModel.MpPotionRestore -= buffGameModel.MpPotionRestore; //TODO возможно это не нужно, т.к. HpPotionRestore для зелий хп/мп
        //    characterGameModel.AddPotionRestoreMp -= buffGameModel.AddPotionRestoreMp;
        //    characterGameModel.AddTransformMaxMp -= buffGameModel.AddTransformMaxMp;

        //    characterGameModel.WeightMax -= buffGameModel.WeightMax;

        //    characterGameModel.AttackRate += buffGameModel.AttackRate;
        //    characterGameModel.AttackRateWhenTransform -= buffGameModel.AttackRateWhenTransform;

        //    characterGameModel.MoveRate -= buffGameModel.MoveRate;
        //    characterGameModel.MoveRateWhenTransform -= buffGameModel.MoveRateWhenTransform;
        //    //TODO Drop, exp, incSilver
        //}
    }
}
