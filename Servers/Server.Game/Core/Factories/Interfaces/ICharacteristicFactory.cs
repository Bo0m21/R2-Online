using Server.Game.Network;
using Server.Game.Models.Game;
using Database.DataModel.Enums;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface ICharacteristicFactory
    {
        void SendInformationAbilityCharacteristics(GameSession client);

        void SendHealthPointCharacteristics(GameSession client);

        void SendSpeedCharacteristics(GameSession client, GameSession clientTo);

        void SendInfoWeight(GameSession client);

        void SendInfoExp(GameSession client, GExp expGame);

        void SendLevelUp(GameSession clientFrom, GameSession clientTo);

        void SendAbnormalAdd(GameSession client, GameSession clientTo, GBuff buffModel);

        void SendAbnormalRemove(GameSession client, GameSession clientTo, AbnormalTypeEnum type);
    }
}
