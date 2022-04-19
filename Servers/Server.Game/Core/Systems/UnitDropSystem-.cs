using Server.Game.Models.GameModels;
using Server.Game.Services;
using System;
using Server.Game.Models.Game;

namespace Server.Game.Core.Systems
{
    public class UnitDropSystem
    {
        private IdentificationService _identificationService;
        private DatabaseBalanceService _databaseBalanceService;

        public UnitDropSystem(IdentificationService identificationService, DatabaseBalanceService databaseBalanceService)
        {
            _identificationService = identificationService;
            _databaseBalanceService = databaseBalanceService;
        }

        /// <summary>
        ///     Send unit drop
        /// </summary>
        /// <param name="unitGame"></param>
        public void SendUnitDrop(UnitGameModel unitGame)
        {
            Random random = new Random();

            foreach (UnitDropGameModel unitDrop in unitGame.Drops)
            {
                double chance = unitDrop.Percent / 100;

                if (chance <= random.NextDouble())
                {
                    continue;
                }

                int count = random.Next(unitDrop.CountFrom, unitDrop.CountTo);

                ItemGameModel itemGame = _databaseBalanceService.GetItemById(unitDrop.ItemId);

                itemGame.Flag = 1;
                itemGame.Count = count;
                itemGame.ItemStatus = unitDrop.ItemStatus;

                PublicItemGameModel publicItem = new PublicItemGameModel()
                {
                    Item = itemGame,
                    Position = unitGame.Position,
                    IsVsibleFirst = true,
                    DateCreate = DateTime.Now
                };

                _identificationService.AddItem(publicItem);
            };
        }
    }
}
