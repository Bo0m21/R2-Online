using Database.Models;
using Server.Game.Models.GameModels;
using Server.Game.Services.Mapping;
using System.Collections.Generic;

namespace Server.Game.Core.Systems
{
    public class CharacterSystem
    {
        private readonly EquipSystem _equipSystem;
        private readonly InventarSystem _inventarSystem;
        private readonly GameMappingService _gameMappingService;

        public CharacterSystem(EquipSystem equipSystem, InventarSystem inventarSystem, GameMappingService gameMappingService)
        {
            _equipSystem = equipSystem;
            _inventarSystem = inventarSystem;
            _gameMappingService = gameMappingService;
        }

        /// <summary>
        ///     Get chracter games
        /// </summary>
        /// <param name="characterModels"></param>
        /// <returns></returns>
        public List<CharacterGameModel> GetCharacterGames(List<CharacterModel> characterModels)
        {
            List<CharacterGameModel> characterGameModels = new List<CharacterGameModel>();

            foreach (CharacterModel characterModel in characterModels)
            {
                CharacterGameModel characterGame = GetCharacterGame(characterModel);
                characterGameModels.Add(characterGame);
            }

            return characterGameModels;
        }

        /// <summary>
        ///     Get character game
        /// </summary>
        /// <param name="characterModel"></param>
        /// <returns></returns>
        public CharacterGameModel GetCharacterGame(CharacterModel characterModel)
        {
            CharacterGameModel characterGameModel = _gameMappingService.GetCharacterGame(characterModel);

            foreach (ItemModel item in characterModel.Items)
            {
                ItemGameModel itemGameModel = _gameMappingService.GetItemGame(item);

                if (itemGameModel.Position != null)
                {
                    _equipSystem.EquipItem(characterGameModel, itemGameModel);
                }

                characterGameModel.Items.Add(itemGameModel);
            }

            _inventarSystem.RecalculateWeight(characterGameModel);

            return characterGameModel;
        }

        /// <summary>
        ///     Recalculate character
        /// </summary>
        /// <param name="characterGameModel"></param>
        public void RecalculateCharacter(CharacterGameModel characterGameModel)
        {
            _gameMappingService.ReMapCharacterGame(characterGameModel);

            foreach (ItemGameModel item in characterGameModel.Items)
            {
                if (item.Position != null)
                {
                    _equipSystem.EquipItem(characterGameModel, item);
                }
            }
        }
    }
}
