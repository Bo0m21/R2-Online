using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IAuthorizationFactory
    {
        void SendWelcome(GameSession loginSession);

        void SendServerTime(GameSession client);

        void SendCompleteEnterWorld(GameSession client);

        // TODO Bytes to models
        void SendGameConfiguration(GameSession client);
    }
}