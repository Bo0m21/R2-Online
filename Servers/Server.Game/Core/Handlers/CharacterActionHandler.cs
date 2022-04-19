using Database.Game.Interfaces;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Network;
using Server.Game.Services.Database;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class CharacterActionHandler : ICharacterActionHandler
    {
        private readonly GameRepository _gameRepository;

        private readonly ICharacterActionFactory _characterActionFactory;
        private readonly ICharacteristicFactory _characteristicFactory;

        public CharacterActionHandler(GameRepository gameRepository, ICharacterActionFactory characterActionFactory, ICharacteristicFactory characteristicFactory)
        {
            _characteristicFactory = characteristicFactory;
            _characterActionFactory = characterActionFactory;
            _gameRepository = gameRepository;
        }

        [HandlerAction(PacketType.DoMoveReq)]
        public void MovingCharacters(GameSession client, DoMoveReqModel model)
        {
            if (client.Pc.DeadTime != null)
            {
                // TODO отбрасывание не работает ух блять
                _characterActionFactory.SendMovedCharacters(client, client);
                return;
            }

            // TODO Присечь спидхак
            client.Pc.PositionCur = model.Position;
            client.Pc.DirectionSight = model.Direction;
            client.Pc.Action = model.Action;

            // We throw off the attack if we moved
            if (client.Pc.AttackedUniqueIdentifier != null)
            {
                _characterActionFactory.SendStopMoveCharacter(client, client);
                client.Pc.AttackedUniqueIdentifier = null;
            }

            _characterActionFactory.SendMovedCharacters(client, client);

            foreach (var visibleCharacterGame in client.Pc.VisibleCharacterGames)
            {
                _characterActionFactory.SendMovedCharacters(visibleCharacterGame, client);
            }
        }

        [HandlerAction(PacketType.CharJumpReq)]
        public void JumpCharacter(GameSession client, CharJumpReqModel model)
        {
            client.Pc.DirectionSight = model.MoveDirection;
            client.Pc.Action = model.Action;

            _characterActionFactory.SendJumpCharacter(client, client);

            foreach (var visibleCharacterGame in client.Pc.VisibleCharacterGames)
            {
                _characterActionFactory.SendJumpCharacter(visibleCharacterGame, client);
            }
        }

        [HandlerAction(PacketType.CharDirReq)]
        public void DirCharacter(GameSession client, CharDirectionReqModel model)
        {
            client.Pc.DirectionSight = model.Direction;

            _characterActionFactory.SendDirectionCharacter(client, client);

            foreach (var visibleCharacterGame in client.Pc.VisibleCharacterGames)
            {
                _characterActionFactory.SendDirectionCharacter(visibleCharacterGame, client);
            }
        }

        [HandlerAction(PacketType.RespawnReq)]
        public void RespawnCharacter(GameSession client, RespawnReqModel model)
        {
            client.Pc.Simple.Hp = (short)(client.Pc.Ability.MaxHp / 2);
            client.Pc.Simple.Mp = (short)(client.Pc.Ability.MaxMp / 2);

            client.Pc.DeadTime = null;

            _characterActionFactory.SendRespawnCharacter(client, client);
            _characteristicFactory.SendHealthPointCharacteristics(client);
        }
    }
}
