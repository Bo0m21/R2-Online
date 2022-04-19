using Packets.Server.Game.Models.Receive.Character;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface ICharacterHandler
    {
        public void CreateCharactersHandle(GameSession client, CreatePcReqModel model);

        public void DeleteCharactersHandle(GameSession client, DeletePcReqModel model);
    }
}
