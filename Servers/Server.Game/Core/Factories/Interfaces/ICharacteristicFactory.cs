using Server.Game.Network;
using Server.Game.Models.Game;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface ICharacteristicFactory
    {
        void SendInformationAbilityCharacteristics(GameSession client);

        void SendHealthPointCharacteristics(GameSession client);

        void SendSpeedCharacteristics(GameSession client, GameSession clientTo);

        void SendInfoWeight(GameSession client);

        void SendInfoExp(GameSession client, ExpGameModel expGame);

        void SendLevelUp(GameSession clientFrom, GameSession clientTo);

        void SendAbnormalAdd(GameSession client, GameSession clientTo, BuffGameModel buffModel);

        void SendAbnormalRemove(GameSession client, GameSession clientTo, AbnormalType type);
    }
}
