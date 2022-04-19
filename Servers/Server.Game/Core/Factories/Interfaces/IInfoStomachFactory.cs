using Server.Game.Network;
using Packets.Server.Game.Models.Send.Character;


namespace Server.Game.Core.Factories.Interfaces
{
    public interface IInfoStomachFactory
    {
        void SendInfoStomach(GameSession clientFrom, InfoStomachModel model);
    }
}
