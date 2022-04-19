using Packets.Server.Game.Models.Receive.Character;
using Server.Game.Network;

namespace Server.Game.Core.Handlers.Interfaces
{
    public interface ICharacterActionHandler
    {
        void MovingCharacters(GameSession client, DoMoveReqModel model);

        void JumpCharacter(GameSession client, CharJumpReqModel model);

        void DirCharacter(GameSession client, CharDirectionReqModel model);

        void RespawnCharacter(GameSession client, RespawnReqModel model);
    }
}
