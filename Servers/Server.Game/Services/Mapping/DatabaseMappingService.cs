using Database.Models;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;

namespace Server.Game.Services
{
    /// <summary>
    ///     Database mapping service
    /// </summary>
    public class DatabaseMappingService
    {
        #region Character mapping
        /// <summary>
        ///     Map character
        /// </summary>
        /// <param name="characterGame"></param>
        /// <param name="character"></param>
        public void MapCharacter(CharacterGameModel characterGame, CharacterModel character)
        {
            characterGame.Id = character.Id;
            characterGame.Name = character.Name;
            characterGame.SlotNumber = character.SlotNumber;

            characterGame.Class = character.Class;
            characterGame.Gender = character.Gender;
            characterGame.Head = character.Head;
            characterGame.Face = character.Face;

            characterGame.Level = character.Level;
            characterGame.Exp = character.Exp;

            characterGame.Hp = character.Hp;
            characterGame.Mp = character.Mp;

            characterGame.Reputation = character.Reputation;

            characterGame.Position = character.Position;
            characterGame.DirectionSight = character.DirectionSight;
        }
        #endregion

        #region Item mapping
        /// <summary>
        ///     Map item
        /// </summary>
        /// <param name="itemGame"></param>
        /// <param name="item"></param>
        public void MapItem(ItemGameModel itemGame, ItemModel item)
        {
            itemGame.Id = item.Id;
            itemGame.ItemId = item.ItemId;

            itemGame.Position = item.Position;
            itemGame.Count = item.Count;

            itemGame.Flag = item.Flag;
            itemGame.EndTick = item.EndTick;
            itemGame.ItemStatus = item.ItemStatus;
            itemGame.UseCount = item.UseCount;
            itemGame.EatTime = item.EatTime;
            itemGame.TermOfEffectivity = item.TermOfEffectivity;
            itemGame.ItemBind = item.ItemBind;
            itemGame.Restore = item.Restore;
            itemGame.Hole = item.Hole;
        }
        #endregion

        #region Session mapping
        /// <summary>
        ///     Map session
        /// </summary>
        /// <param name="sessionGame"></param>
        /// <param name="session"></param>
        public void MapSession(SessionGameModel sessionGame, SessionModel session)
        {
            sessionGame.Id = session.Id;

            sessionGame.AccountId = session.AccountId;
            sessionGame.ServerId = session.ServerId;
            sessionGame.InGame = session.InGame;
        }
        #endregion
    }
}
