using Database.Models;
using Server.Game.Models.GameModels;
using Server.Game.Services.Mapping;
using System.Linq;

namespace Server.Game.Core.Systems
{
    public class InventarSystem
    {
        private readonly GameMappingService _gameMappingService;

        public InventarSystem(GameMappingService gameMappingService)
        {
            _gameMappingService = gameMappingService;
        }

        /// <summary>
        ///     Add item in inventar
        /// </summary>
        /// <param name="characterGame"></param>
        /// <param name="item"></param>
        public void AddItem(CharacterGameModel characterGame, ItemModel item)
        {
            ItemGameModel itemGame = _gameMappingService.GetItemGame(item);
            characterGame.Items.Add(itemGame);
        }

        /// <summary>
        ///     Remove item in inventar
        /// </summary>
        /// <param name="characterGame"></param>
        /// <param name="item"></param>
        public void RemoveItem(CharacterGameModel characterGame, ItemModel item)
        {
            ItemGameModel itemGameModel = characterGame.Items.First(i => i.Id == item.Id);
            characterGame.Items.Remove(itemGameModel);
        }

        /// <summary>
        ///     Update item in inventar
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="itemModel"></param>
        public void UpdateItem(CharacterGameModel characterGameModel, ItemModel itemModel)
        {
            ItemGameModel itemGameModel = characterGameModel.Items.First(i => i.Id == itemModel.Id);
            itemGameModel.Count = itemModel.Count;
        }

        /// <summary>
        ///     Recalculate weight
        /// </summary>
        /// <param name="characterGameModel"></param>
        public void RecalculateWeight(CharacterGameModel characterGameModel)
        {
            characterGameModel.Weight = 0;

            foreach (var item in characterGameModel.Items)
            {
                characterGameModel.Weight += (short)(item.Count * item.Weight);
            }
        }
    }
}
