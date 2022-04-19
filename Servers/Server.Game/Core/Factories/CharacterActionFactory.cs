using Packets.Server.Game.Models.Send.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Factories
{
    public class CharacterActionFactory : ICharacterActionFactory
    {
        public void SendMovedCharacters(GameSession clientTo, GameSession clientFrom)
        {
            MovedCharacterModel movedCharactersModel = new MovedCharacterModel
            {
                SessionGameId = clientFrom.Pc.UniqueId,
                Position = clientFrom.Pc.PositionCur,
                MoveRate = clientFrom.Pc.Detail.MoveRate,
                DirectionSight = clientFrom.Pc.DirectionSight,
                Action = clientFrom.Pc.Action
            };

            clientTo.Send(movedCharactersModel);
        }

        public void SendStopMoveCharacter(GameSession clientTo, GameSession client)
        {
            StopMoveCharacterModel stopMoveCharacterModel = new StopMoveCharacterModel
            {
                SessionGameId = client.Pc.UniqueId,
                Position = client.Pc.PositionCur,
            };

            clientTo.Send(stopMoveCharacterModel);
        }

        public void SendJumpCharacter(GameSession clientTo, GameSession clientFrom)
        {
            JumpEndCharacterModel jumpEndCharactersModel = new JumpEndCharacterModel
            {
                SessionGameId = clientFrom.Pc.UniqueId,
                DirectionSight = clientFrom.Pc.DirectionSight,
                Action = clientFrom.Pc.Action
            };

            clientTo.Send(jumpEndCharactersModel);
        }

        public void SendDirectionCharacter(GameSession clientTo, GameSession clientFrom)
        {
            CharDirectionModel charDirectionModel = new CharDirectionModel
            {
                SessionGameId = clientFrom.Pc.UniqueId,
                DirectionSight = clientFrom.Pc.DirectionSight
            };

            clientTo.Send(charDirectionModel);
        }

        public void SendRespawnCharacter(GameSession clientTo, GameSession clientFrom)
        {
            RespawnAckModel respawnAckModel = new RespawnAckModel
            {
                SessionGameId = clientFrom.Pc.UniqueId,
                Position = clientFrom.Pc.PositionCur
            };

            clientTo.Send(respawnAckModel);
        }
    }
}
