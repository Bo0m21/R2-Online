using Server.Game.Models.GameModels;

namespace Server.Game.Core.Systems
{
    public class ItemUseSystem
    {
        /// <summary>
        ///     Abnormal add
        /// </summary>
        /// <param name="characterGameModel"></param>
        /// <param name="item"></param>
        public void ItemUse(CharacterGameModel characterGameModel, ItemGameModel item)
        {
            characterGameModel.Hp += item.HpPotionRestore;
            characterGameModel.Mp += item.MpPotionRestore;
        }
    }
}
