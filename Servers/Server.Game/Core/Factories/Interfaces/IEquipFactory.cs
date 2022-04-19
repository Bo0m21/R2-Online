using Packets.Server.Game.Enums;
using Server.Game.Models.GameModels;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IEquipFactory
    {
        void SendEquip(GameSession clientFrom, GameSession clientTo, ItemGameModel itemGameModel);

        void SendUnEquip(GameSession clientFrom, GameSession clientTo, ItemPositionType position);
    }
}
