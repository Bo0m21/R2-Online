using Server.Game.Services;
using System;
using Server.Game.Models.Game;
using Server.Game.Services.Database;

namespace Server.Game.Core.Systems
{
    public class UnitDropSystem
    {
        private IdentificationService _identificationService;
        private ParmRepository _parmService;

        public UnitDropSystem(IdentificationService identificationService, ParmRepository parmService)
        {
            _identificationService = identificationService;
            _parmService = parmService;
        }

        /// <summary>
        ///     Send unit drop
        /// </summary>
        /// <param name="unitGame"></param>
        //public void SendUnitDrop(GMonster unitGame)
        //{
        //    Random random = new Random();

        //    foreach (GUnitDrop monsterDrop in unitGame.Drops)
        //    {
        //        double chance = monsterDrop.Percent / 100;

        //        if (chance <= random.NextDouble())
        //        {
        //            continue;
        //        }

        //        GItem itemGame = _parmService.GetItemById(monsterDrop.ItemId);

        //        //itemGame.IsConfirm = 1;
        //        itemGame.Count = monsterDrop.Count;
        //        itemGame.Status = monsterDrop.ItemStatus;

        //        GPublicItem publicItem = new GPublicItem()
        //        {
        //            Item = itemGame,
        //            Position = unitGame.CurrentPosition,
        //            IsVsibleFirst = true,
        //            DateCreate = DateTime.Now
        //        };

        //        _identificationService.AddItem(publicItem);
        //    };
        //}
    }
}
