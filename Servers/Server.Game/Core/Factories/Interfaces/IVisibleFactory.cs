using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Network;
using System.Collections.Generic;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IVisibleFactory
    {
        void SendDisplayedCharacters(IEnumerable<GameSession> clientsFrom, GameSession clientTo);

        void SendDisplayedDetailsCharacter(GameSession clientFrom, GameSession clientTo);

        void SendDisplayedItems(GameSession client, IEnumerable<GPublicItem> itemGameModels);

        void SendDisplayedDetailsItem(GameSession client, GPublicItem itemDroppedGame);

        void SendDisplayedUnit(GameSession client, IEnumerable<GMonster> unitGameModels);

        void SendDisplayedDetailsUnit(GameSession client, GMonster unitGameModel);

        void SendExitMap(GameSession client, UniqueId uniqueItemDrop, ExitMapWhy exitMapWhy);
    }
}
