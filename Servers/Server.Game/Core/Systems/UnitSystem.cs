using Database.Balance.Models;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Server.Game.Services;
using System;
using System.Collections.Generic;

namespace Server.Game.Core.Systems
{
    public class UnitSystem
    {
        private readonly DatabaseBalanceService _databaseBalanceService;
        public UnitSystem(DatabaseBalanceService databaseBalanceService)
        {
            _databaseBalanceService = databaseBalanceService;
        }

        /// <summary>
        ///     Get unit games
        /// </summary>
        /// <returns></returns>
        public List<UnitGameModel> GetUnitGames()
        {
            List<UnitGameModel> unitGames = new List<UnitGameModel>();

            // Get all unit positions
            List<UnitPositionGameModel> unitPositionGames = _databaseBalanceService.GetUnitPositions();

            // Create all units
            foreach (var unitPositionGame in unitPositionGames)
            {
                // Get new unit
                UnitGameModel unitGame = _databaseBalanceService.GetUnitById(unitPositionGame.UnitId);

                // Set general fields
                unitGame.IsVsibleFirst = true;
                unitGame.DeadTime = DateTime.MinValue;

                // Set drops for unit
                unitGame.Drops = _databaseBalanceService.GetUnitDropsById(unitPositionGame.UnitId);

                // Set default position for unit
                unitGame.PositionDefault = unitPositionGame.Position;
                unitGame.DirectionSightDefault = unitPositionGame.DirectionSight;
                unitGame.Respawn = unitPositionGame.Respawn;

                unitGames.Add(unitGame);
            }

            return unitGames;
        }

        /// <summary>
        ///     Reset unit
        /// </summary>
        /// <param name="unitGame"></param>
        public void ResetUnit(UnitGameModel unitGame)
        {
            // Set default hp
            unitGame.Hp = unitGame.HpMax;
            unitGame.Mp = unitGame.MpMax;

            // Set default position
            unitGame.Position = new Vector3(unitGame.PositionDefault.X, unitGame.PositionDefault.Y, unitGame.PositionDefault.Z);
            unitGame.DirectionSight = unitGame.DirectionSightDefault;

            // Set general fields
            unitGame.IsVsibleFirst = true;
            unitGame.DeadTime = null;
        }

        public UnitGameModel AddUnit(int unitId,UnitPositionModel unitPositionGameModel)
        {
            //TODO Сделано для расстановки мобов в реал тайме
            // Get new unit
            UnitGameModel unitGame = _databaseBalanceService.GetUnitById(unitId);

            // Set general fields
            unitGame.IsVsibleFirst = true;
            unitGame.DeadTime = null;

            // Set drops for unit
            unitGame.Drops = _databaseBalanceService.GetUnitDropsById(unitId);

            // Set default position for unit
            unitGame.PositionDefault = new Vector3(unitPositionGameModel.X, unitPositionGameModel.Y, unitPositionGameModel.Z);
            unitGame.Position = unitGame.PositionDefault;
            unitGame.DirectionSightDefault = unitPositionGameModel.DirectionSight;
            unitGame.Respawn = unitPositionGameModel.Respawn;

            return unitGame;
        }
    }
}
