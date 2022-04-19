using Packets.Server.Game.Models.Send.Attack;
using Server.Game.Models.Game;
using System;

namespace Server.Game.Core.Systems
{
    public class AttackSystem
    {
        public AttackSystem()
        {

        }

        /// <summary>
        ///     Attack character to character
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="characterAttackedGameModel"></param>
        /// <returns></returns>
        //public TypeHit AttackCharacterToCharacter(PcGame characterGameModel, PcGame characterAttackedGameModel)
        //{
        //    Random rnd = new Random();
        //    int Damage = 0;
        //    int DDvMin = characterGameModel.DDvMin,
        //        DDvMax = characterGameModel.DDvMax,
        //        Dhit = characterGameModel.DHit,
        //        DDd = characterAttackedGameModel.DDd,
        //        DPv = characterAttackedGameModel.DPv,

        //        RDvMin = characterGameModel.RDvMin,
        //        RDvMax = characterGameModel.RDvMax,
        //        Rhit = characterGameModel.RHit,
        //        RDd = characterAttackedGameModel.RDd,
        //        RPv = characterAttackedGameModel.DPv,

        //        MDvMin = characterGameModel.MDvMin,
        //        MDvMax = characterGameModel.MDvMax,
        //        Mhit = characterGameModel.MHit,
        //        MDd = characterAttackedGameModel.MDd,
        //        MPv = characterAttackedGameModel.MPv,

        //        DDvCriticalAdd = characterGameModel.DDvCriticalAdd,
        //        DDvCriticalRemove = characterAttackedGameModel.DDvCriticalRemove,
        //        Critical = characterGameModel.Critical,
        //        CriticalProtect = characterGameModel.CriticalProtect,
        //        HumKill = characterGameModel.HumanKiller,
        //        HumProt = characterAttackedGameModel.HumanProtect;

        //    double hitChance = 0.905;
        //    double Chance = hitChance;

        //    int DDv = rnd.Next(DDvMin, DDvMax);
        //    int RDv = rnd.Next(RDvMin, RDvMax);
        //    int MDv = rnd.Next(MDvMin, MDvMax);
        //    double Rnd = rnd.NextDouble();

        //    double criticalChance = (100 - Critical - CriticalProtect) / (double)100;
        //    int resultValue = (Dhit - DDd);

        //    //Высчитываем наибольший шанс попадания: ближняя атака, дальняя, или магическая
        //    if ((Rhit - RDd) > resultValue)
        //    {
        //        resultValue = (Rhit - RDd);
        //    }
        //    else if ((Mhit - MDd) > resultValue)
        //    {
        //        resultValue = (Mhit - MDd);
        //    }

        //    //Считаем шанс попадания
        //    if (resultValue >= 0)
        //    {
        //        Chance = hitChance + ((resultValue) / 100);

        //        if (Chance > 0.98)
        //        {
        //            Chance = 0.98;
        //        }
        //    }
        //    else if (resultValue >= -10 && resultValue < 0)
        //    {
        //        Chance = hitChance + ((resultValue * 1.5) / (double)100);

        //        if (Chance < 0.10)
        //        {
        //            Chance = 0.10;
        //        }
        //    }
        //    else if (resultValue >= -15 && resultValue < -10)
        //    {
        //        resultValue += 10;

        //        Chance = 0.755 + ((resultValue * 2) / (double)100);

        //        if (Chance < 0.10)
        //        {
        //            Chance = 0.10;
        //        }
        //    }
        //    else if (resultValue >= -20 && resultValue < -15)
        //    {
        //        resultValue += 15;

        //        Chance = 0.655 + ((resultValue * 3) / (double)100);

        //        if (Chance < 0.10)
        //        {
        //            Chance = 0.10;
        //        }
        //    }
        //    else if (resultValue < -20)
        //    {
        //        resultValue += 20;

        //        Chance = 0.505 + ((resultValue * 5) / (double)100);

        //        if (Chance < 0.10)
        //        {
        //            Chance = 0.10;
        //        }
        //    }

        //    //Подсчет формулы дамага
        //    if (Chance >= Rnd)
        //    {
        //        if (criticalChance <= Rnd) // критическая атака
        //        {
        //            Damage = (DDvMax - DPv) + (RDvMax - RPv) + (MDvMax - MPv) + (DDvCriticalAdd - DDvCriticalRemove);

        //            if (HumKill > 0 || HumProt > 0) // проверка на убийцу людей
        //            {
        //                Damage += Damage * (HumKill - HumProt) / 10;
        //            }
        //            if (Damage <= 0)
        //            {
        //                Damage = rnd.Next(0, 5);
        //            }

        //            characterAttackedGameModel.Hp -= (short)Damage; //Прибавляем к критической атаке доп урон при критической атаке и отнимаем хп
        //            return TypeHit.Crit;
        //        }

        //        if (DDv > DPv)
        //        {
        //            Damage += DDv - DPv;
        //        }
        //        if (RDv > RPv)
        //        {
        //            Damage += RDv - RPv;
        //        }
        //        if (MDv > MPv)
        //        {
        //            Damage += MDv - MPv;
        //        }


        //        if (HumKill > 0 || HumProt > 0) // проверка на убийцу людей
        //        {
        //            Damage += Damage * (HumKill - HumProt) / 10;
        //        }
        //        if (Damage <= 0)
        //        {
        //            Damage = rnd.Next(0, 5);
        //        }

        //        characterAttackedGameModel.Hp -= (short)Damage;
        //        return TypeHit.Hit;
        //    }
        //    else
        //    {
        //        return TypeHit.Miss;
        //    }
        //}

        /// <summary>
        ///     Attack character to unit
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="unitGameModel"></param>
        /// <returns></returns>
        //public TypeHit AttackCharacterToUnit(PcGame characterGameModel, MonsterGame unitGameModel)
        //{
        //    //TODO Сделать для мобов тип монстров(ангел, демон, нежить, маги и т.д.)
        //    Random rnd = new Random();
        //    int Damage;
        //    int DDvMin = characterGameModel.DDvMin,
        //        DDvMax = characterGameModel.DDvMax,
        //        Dhit = characterGameModel.DHit,
        //        DDd = unitGameModel.DDd,
        //        DPv = unitGameModel.DPv,

        //        RDvMin = characterGameModel.RDvMin,
        //        RDvMax = characterGameModel.RDvMax,
        //        Rhit = characterGameModel.RHit,
        //        RDd = unitGameModel.RDd,
        //        RPv = unitGameModel.DPv,

        //        MDvMin = characterGameModel.MDvMin,
        //        MDvMax = characterGameModel.MDvMax,
        //        Mhit = characterGameModel.MHit,
        //        MDd = unitGameModel.MDd,
        //        MPv = unitGameModel.MPv,

        //        DDvCriticalAdd = characterGameModel.DDvCriticalAdd,
        //        Critical = characterGameModel.Critical,
        //        CriticalProtect = characterGameModel.CriticalProtect,
        //        MobKiller = characterGameModel.MobKiller;

        //    double hitChance = 0.905;

        //    int DDv = rnd.Next(DDvMin, DDvMax);
        //    int RDv = rnd.Next(RDvMin, RDvMax);
        //    int MDv = rnd.Next(MDvMin, MDvMax);
        //    double Rnd = rnd.NextDouble();

        //    double criticalChance = (100 - Critical - CriticalProtect) / 100;
        //    int resultValue = (Dhit - DDd);

        //    //Высчитываем наибольший шанс попадания: ближняя атака, дальняя, или магическая
        //    if ((Rhit - RDd) > resultValue)
        //    {
        //        resultValue = (Rhit - RDd);
        //    }
        //    else if ((Mhit - MDd) > resultValue)
        //    {
        //        resultValue = (Mhit - MDd);
        //    }

        //    //Считаем шанс попадания
        //    if (resultValue >= 0)
        //    {
        //        hitChance += (resultValue) / 100;

        //        if (hitChance > 0.98)
        //        {
        //            hitChance = 0.98;
        //        }
        //    }
        //    else
        //    {
        //        hitChance += (resultValue * 1.5) / 100;

        //        if (hitChance < 0.10)
        //        {
        //            hitChance = 0.10;
        //        }
        //    }

        //    //Подсчет формулы дамага
        //    if (hitChance >= Rnd)
        //    {
        //        if (criticalChance <= Rnd) // критическая атака
        //        {
        //            Damage = (DDvMax - DPv) + (RDvMax - RPv) + (MDvMax - MPv) + DDvCriticalAdd;

        //            if (MobKiller > 0) // проверка на убийцу людей
        //            {
        //                Damage += Damage * MobKiller / 10;
        //            }
        //            if (Damage <= 0)
        //            {
        //                Damage = rnd.Next(0, 5);
        //            }

        //            unitGameModel.Hp -= (short)Damage; //Прибавляем к критической атаке доп урон при критической атаке и отнимаем хп
        //            return TypeHit.Crit;
        //        }

        //        Damage = (DDv - DPv) + (RDv - RPv) + (MDv - MPv);

        //        if (MobKiller > 0) // проверка на убийцу людей
        //        {
        //            Damage += Damage * MobKiller / 10;
        //        }
        //        if (Damage <= 0)
        //        {
        //            Damage = rnd.Next(0, 5);
        //        }

        //        unitGameModel.Hp -= (short)Damage;
        //        return TypeHit.Hit;
        //    }
        //    else
        //    {
        //        return TypeHit.Miss;
        //    }
        //}
    

        /// <summary>
        ///     Attack unit to character
        /// </summary>
        /// <param name="unitGameModel"></param>
        /// <param name="characterGameModel"></param>
        /// <returns></returns>
        //public TypeHit AttackUnitToCharacter(MonsterGame unitGameModel, PcGame characterGameModel)
        //{
        //    if (unitGameModel.Type == Database.Parm.Enums.UnitTypeEnum.Npc)
        //    {
        //        return TypeHit.Miss;
        //    }

        //    //TODO Сделать для мобов тип монстров(ангел, демон, нежить, маги и т.д.)
        //    //TODO Сделать критическую атаку для мобов
        //    Random rnd = new Random();
        //    int Damage;
        //    int DDvMin = unitGameModel.DDvMin,
        //        DDvMax = unitGameModel.DDvMax,
        //        Dhit = unitGameModel.Hit,
        //        DDd = characterGameModel.DDd,
        //        DPv = characterGameModel.DPv,

        //        RDvMin = unitGameModel.RDvMin,
        //        RDvMax = unitGameModel.RDvMax,
        //        Rhit = unitGameModel.Rhit,
        //        RDd = characterGameModel.RDd,
        //        RPv = characterGameModel.DPv,

        //        MDvMin = unitGameModel.MDvMin,
        //        MDvMax = unitGameModel.MDvMax,
        //        Mhit = unitGameModel.Mhit,
        //        MDd = characterGameModel.MDd,
        //        MPv = characterGameModel.MPv,
        //        MobProtect = characterGameModel.MobProtect;

        //    double hitChance = 0.905;

        //    int DDv = rnd.Next(DDvMin, DDvMax);
        //    int RDv = rnd.Next(RDvMin, RDvMax);
        //    int MDv = rnd.Next(MDvMin, MDvMax);
        //    double Rnd = rnd.NextDouble();

        //    int resultValue = (Dhit - DDd);

        //    //Высчитываем наибольший шанс попадания: ближняя атака, дальняя, или магическая
        //    if ((Rhit - RDd) > resultValue)
        //    {
        //        resultValue = (Rhit - RDd);
        //    }
        //    else if ((Mhit - MDd) > resultValue)
        //    {
        //        resultValue = (Mhit - MDd);
        //    }

        //    //Считаем шанс попадания
        //    if (resultValue >= 0)
        //    {
        //        hitChance += (resultValue) / 100;

        //        if (hitChance > 0.98)
        //        {
        //            hitChance = 0.98;
        //        }
        //    }
        //    else
        //    {
        //        hitChance += (resultValue * 1.5) / 100;

        //        if (hitChance < 0.10)
        //        {
        //            hitChance = 0.10;
        //        }
        //    }

        //    //Подсчет формулы дамага
        //    if (hitChance >= Rnd)
        //    {
        //        Damage = (DDv - DPv) + (RDv - RPv) + (MDv - MPv);

        //        if (MobProtect > 0) // проверка на убийцу людей
        //        {
        //            Damage += Damage * MobProtect / 10;
        //        }
        //        if (Damage <= 0)
        //        {
        //            Damage = rnd.Next(0, 5);
        //        }

        //        characterGameModel.Hp -= (short)Damage;
        //        return TypeHit.Hit;
        //    }
        //    else
        //    {
        //        return TypeHit.Miss;
        //    }
        //}
    }
}
