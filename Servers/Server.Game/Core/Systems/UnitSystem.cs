using Database.DataModel.Models;
using Database.Parm.Models;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Services;
using Server.Game.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Core.Systems
{
    public class UnitSystem
    {
        private readonly ParmRepository _parmRepository;
        public UnitSystem(ParmRepository parmRepository)
        {
            _parmRepository = parmRepository;
        }

        /// <summary>
        ///     Get unit games
        /// </summary>
        /// <returns></returns>
        public List<GMonster> GetUnitGames()
        {
            Random random = new Random();
            var monsters = new List<GMonster>();
            var monsterSpots = _parmRepository.GetAllMonsterSpots();

            // Create all units
            foreach (var mSpot in monsterSpots)
            {
                // Get new unit
                var monster = _parmRepository.GetGMonsterById(mSpot.MonsterId);

                // Set general fields
                monster.IsVsibleFirst = true;
                monster.DeadTime = DateTime.MinValue;
                Vector3 pos;
                MonsterSpotGroup sGroup;
                if (mSpot.SpotGroup.Count > 0)
                {
                    var rndSpotGroup = random.Next(0, mSpot.SpotGroup.Count);
                    sGroup = mSpot.SpotGroup[rndSpotGroup];
                    pos = new Vector3((float)sGroup.PosX, (float)sGroup.PosZ, (float)sGroup.PosY);
                }
                else
                {
                    sGroup = mSpot.SpotGroup[0];
                    pos = new Vector3((float)sGroup.PosX, (float)sGroup.PosZ, (float)sGroup.PosY);
                }

                // Set default position for unit
                monster.PositionDefault = pos;
                monster.PositionCur = pos;
                monster.DirectionSight = (float)mSpot.Dir;
                monster.Respawn = mSpot.Tick * 1000;

                monsters.Add(monster);
            }

            return monsters;
        }

        /// <summary>
        ///     Reset unit
        /// </summary>
        /// <param name="unitGame"></param>
        public void ResetUnit(GMonster unitGame)
        {
            //// Set default hp
            //unitGame.Hp = unitGame.HpMax;
            //unitGame.Mp = unitGame.MpMax;

            //// Set default position
            //unitGame.CurrentPosition = new Vector3(unitGame.PositionDefault.X, unitGame.PositionDefault.Y, unitGame.PositionDefault.Z);
            //unitGame.DirectionSight = Random;

            //// Set general fields
            //unitGame.IsVsibleFirst = true;
            //unitGame.DeadTime = null;
        }

        //public UnitGameModel AddUnit(int unitId, UnitPositionModel unitPositionGameModel)
        //{
        //    //TODO Сделано для расстановки мобов в реал тайме
        //    // Get new unit
        //    UnitGameModel unitGame = _databaseBalanceService.GetUnitById(unitId);

        //    // Set general fields
        //    unitGame.IsVsibleFirst = true;
        //    unitGame.DeadTime = null;

        //    // Set drops for unit
        //    unitGame.Drops = _databaseBalanceService.GetUnitDropsById(unitId);

        //    // Set default position for unit
        //    unitGame.PositionDefault = new Vector3(unitPositionGameModel.X, unitPositionGameModel.Y, unitPositionGameModel.Z);
        //    unitGame.Position = unitGame.PositionDefault;
        //    unitGame.DirectionSightDefault = unitPositionGameModel.DirectionSight;
        //    unitGame.Respawn = unitPositionGameModel.Respawn;

        //    return unitGame;
        //}
    }
}
