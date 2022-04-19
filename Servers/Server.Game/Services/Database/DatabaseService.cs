using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Services.Dataabse
{
    /// <summary>
    ///     Database service
    /// </summary>
    public class DatabaseService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly DatabaseMappingService _databaseMappingService;

        private readonly CharacterSystem _characterSystem;

        public DatabaseService(IDatabaseContext databaseContext, DatabaseMappingService databaseMappingService, CharacterSystem characterSystem)
        {
            _databaseContext = databaseContext;
            _databaseMappingService = databaseMappingService;
            _characterSystem = characterSystem;
        }

        #region Account

        #endregion

        #region Character
        /// <summary>
        ///     Get characters by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CharacterGameModel> GetCharactersById(int id)
        {
            List<CharacterModel> characters = _databaseContext.Characters
                .Include(i => i.Account)
                .Include(i => i.Items)
                .Where(charact => charact.AccountId == id)
                .ToList();

            List<CharacterGameModel> characterGames = _characterSystem.GetCharacterGames(characters);

            return characterGames;
        }
        #endregion

        #region Item

        public void UpdateItem(int id, int count)
        {
            ItemModel item = _databaseContext.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                throw new System.Exception("Item not found");
            }

            item.Count = count;

            _databaseContext.SaveChanges();
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
        public SessionGameModel GetSessionById(int id)
        {
            SessionGameModel sessionGame = new SessionGameModel();

            SessionModel session = _databaseContext.Sessions.FirstOrDefault(s => s.Id == id);
            _databaseMappingService.MapSession(sessionGame, session);

            return sessionGame;
        }

        /// <summary>
        ///     Update session status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void UpdateSessionStatus(int id, bool status)
        {
            SessionModel session = _databaseContext.Sessions.FirstOrDefault(s => s.Id == id);

            session.InGame = status;
            _databaseContext.SaveChanges();
        }
        #endregion
    }
}
