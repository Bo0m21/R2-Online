using Packets.Server.Game.Enums;
using Server.Game.Models.Game;
using Server.Game.Network;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IEquipFactory
    {
        void SendEquip(GameSession clientFrom, GameSession clientTo, GItem item);

        void SendUnEquip(GameSession clientFrom, GameSession clientTo, ItemPositionType position);
    }
}
