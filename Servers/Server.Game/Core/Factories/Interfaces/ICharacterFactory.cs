using Server.Game.Models.GameModels;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface ICharacterFactory
    {
        public void SendCompleteCreateCharacters(GameSession client, CharacterGameModel characterGame);

        public void SendCompleteDeleteCharacters(GameSession client, CharacterGameModel characterGame);

        public void SendInformationCharacters(GameSession client);
    }
}
