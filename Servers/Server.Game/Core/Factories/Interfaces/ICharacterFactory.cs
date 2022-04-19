using Server.Game.Models.Game;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface ICharacterFactory
    {
        public void SendCompleteCreateCharacters(GameSession client, GPc characterGame);

        public void SendCompleteDeleteCharacters(GameSession client, GPc characterGame);

        public void SendInformationCharacters(GameSession client);
    }
}
