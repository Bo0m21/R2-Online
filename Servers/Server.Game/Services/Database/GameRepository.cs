using Database.Account.Interfaces;
using Database.Account.Models;
using Database.Game.Interfaces;
using Database.Game.Models;
using Microsoft.EntityFrameworkCore;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Services.Database
{
    /// <summary>
    ///     Database service
    /// </summary>
    public class GameRepository
    {
        private readonly IAccountContext _accountContext;
        private readonly IGameContext _gameContext;
        private readonly DBGameMappingService _gameMappingService;

        private readonly CharacterSystem _characterSystem;

        public GameRepository(IAccountContext accountContext,
            IGameContext gameContext,
            DBGameMappingService databaseMappingService, 
            CharacterSystem characterSystem)
        {
            _accountContext = accountContext;
            _gameContext = gameContext;
            _gameMappingService = databaseMappingService;
            _characterSystem = characterSystem;
        }

        #region Account

        #endregion

        #region Character
        /// <summary>
        ///     Get characters by id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<GPc> GetPcsByAccountId(int accountId)
        {
            List<Pc> characters = _gameContext.Pcs
                .Include(i => i.PcDeleted)
                .Include(i => i.PcInvenQslotInfo)
                .Include(i => i.State)
                .Include(i => i.PcAbnormals)
                .Include(i => i.PcChatFilters)
                .Include(i => i.PcFriends)
                .Include(i => i.PcTeleports)
                .Include(i => i.PcEquips)
                .Include(i => i.PcInventoryItems)
                .Where(pc => pc.Owner == accountId)
                .ToList();

            List<GPc> characterGames = _characterSystem.GetGPc(characters);

            return characterGames;
        }

        public async void SavePositionAsync(GPc gPc)
        {
            var pcState = _gameContext.PcStates.FirstOrDefault(x => x.No == gPc.Simple.PcNo);

            pcState.PosX = gPc.PositionCur.X;
            pcState.PosY = gPc.PositionCur.Y;
            pcState.PosZ = gPc.PositionCur.Z;

            await _gameContext.SaveChangesAsync();
        }
        #endregion

        #region Item

        public void UpdateItem(int id, int count)
        {
            //ItemModel item = _gameContext.Items.FirstOrDefault(i => i.Id == id);

            //if (item == null)
            //{
            //    throw new System.Exception("Item not found");
            //}

            //item.Count = count;

            //_gameContext.SaveChanges();
        }

        #endregion

        #region Server

        #endregion

        #region Session
        /// <summary>
        ///     Get session by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GSession GetSessionById(int id)
        {
            GSession sessionGame = new GSession();

            SessionModel session = _accountContext.Sessions.FirstOrDefault(s => s.Id == id);
            _gameMappingService.MapSession(sessionGame, session);

            return sessionGame;
        }

        /// <summary>
        ///     Update session status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void UpdateSessionStatus(int id, bool status)
        {
            SessionModel session = _accountContext.Sessions.FirstOrDefault(s => s.Id == id);

            session.InGame = status;
            _gameContext.SaveChanges();
        }
        #endregion
    }
}
