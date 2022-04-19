using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
using Server.Game.Network;
using System.Collections.Generic;

namespace Server.Game.Core.Factories.Interfaces
{
    public interface IVisibleFactory
    {
        void SendDisplayedCharacters(IEnumerable<GameSession> clientsFrom, GameSession clientTo);

        void SendDisplayedDetailsCharacter(GameSession clientFrom, GameSession clientTo);

        void SendDisplayedItems(GameSession client, IEnumerable<PublicItemGameModel> itemGameModels);

        void SendDisplayedDetailsItem(GameSession client, PublicItemGameModel itemDroppedGame);

        void SendDisplayedUnit(GameSession client, IEnumerable<UnitGameModel> unitGameModels);

        void SendDisplayedDetailsUnit(GameSession client, UnitGameModel unitGameModel);

        void SendExitMap(GameSession client, UniqueIdentifier uniqueItemDrop, ExitMapWhy exitMapWhy);
    }
}
