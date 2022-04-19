using Database.Game.Models;
using Server.Game.Models.Game;
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
        public List<GPc> GetGPc(List<Pc> characterModels)
        {
            List<GPc> gPcs = new List<GPc>();

            foreach (Pc characterModel in characterModels)
            {
                var gPc = _gameMappingService.GetCharacterGame(characterModel);
                gPcs.Add(gPc);
            }

            return gPcs;
        }

        /// <summary>
        ///     Get character game
        /// </summary>
        /// <param name="characterModel"></param>
        /// <returns></returns>
        public GPc GetCharacterGame(Pc characterModel)
        {
            GPc characterGameModel = _gameMappingService.GetCharacterGame(characterModel);

            //foreach (ItemModel item in characterModel.Items)
            //{
            //    ItemGameModel itemGameModel = _gameMappingService.GetItemGame(item);

            //    if (itemGameModel.Position != null)
            //    {
            //        _equipSystem.EquipItem(characterGameModel, itemGameModel);
            //    }

            //    characterGameModel.Items.Add(itemGameModel);
            //}

            //_inventarSystem.RecalculateWeight(characterGameModel); //TODO


            return characterGameModel;
        }

        /// <summary>
        ///     Recalculate character
        /// </summary>
        /// <param name="pc"></param>
        //public void RecalculateCharacter(GPc pc)
        //{
        //    _gameMappingService.ReMapCharacterGame(pc);

        //    foreach (var equip in pc.Equip)
        //    {
        //        _equipSystem.EquipItem(pc, equip.Item);
        //    }
        //}
    }
}
