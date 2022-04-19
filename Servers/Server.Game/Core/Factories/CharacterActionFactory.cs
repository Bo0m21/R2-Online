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
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier,
                Position = clientFrom.CharacterGame.Position,
                MoveRate = clientFrom.CharacterGame.MoveRate,
                DirectionSight = clientFrom.CharacterGame.DirectionSight,
                Action = clientFrom.CharacterGame.Action
            };

            clientTo.Send(movedCharactersModel);
        }

        public void SendStopMoveCharacter(GameSession clientTo, GameSession client)
        {
            StopMoveCharacterModel stopMoveCharacterModel = new StopMoveCharacterModel
            {
                SessionGameId = client.CharacterGame.UniqueIdentifier,
                Position = client.CharacterGame.Position,
            };

            clientTo.Send(stopMoveCharacterModel);
        }

        public void SendJumpCharacter(GameSession clientTo, GameSession clientFrom)
        {
            JumpEndCharacterModel jumpEndCharactersModel = new JumpEndCharacterModel
            {
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier,
                DirectionSight = clientFrom.CharacterGame.DirectionSight,
                Action = clientFrom.CharacterGame.Action
            };

            clientTo.Send(jumpEndCharactersModel);
        }

        public void SendDirectionCharacter(GameSession clientTo, GameSession clientFrom)
        {
            CharDirectionModel charDirectionModel = new CharDirectionModel
            {
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier,
                DirectionSight = clientFrom.CharacterGame.DirectionSight
            };

            clientTo.Send(charDirectionModel);
        }

        public void SendRespawnCharacter(GameSession clientTo, GameSession clientFrom)
        {
            RespawnAckModel respawnAckModel = new RespawnAckModel
            {
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier,
                Position = clientFrom.CharacterGame.Position
            };

            clientTo.Send(respawnAckModel);
        }
    }
}
