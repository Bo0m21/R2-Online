using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Network;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class CharacterActionHandler : ICharacterActionHandler
    {
        private readonly ICharacterActionFactory _characterActionFactory;
        private readonly ICharacteristicFactory _characteristicFactory;

        public CharacterActionHandler(ICharacterActionFactory characterActionFactory, ICharacteristicFactory characteristicFactory)
        {
            _characteristicFactory = characteristicFactory;
            _characterActionFactory = characterActionFactory;
        }

        [HandlerAction(PacketType.DoMoveReq)]
        public void MovingCharacters(GameSession client, DoMoveReqModel model)
        {
            if (client.CharacterGame.DeadTime != null)
            {
                // TODO отбрасывание не работает ух блять
                _characterActionFactory.SendMovedCharacters(client, client);
                return;
            }

            // TODO Присечь спидхак
            client.CharacterGame.Position = model.Position;
            client.CharacterGame.DirectionSight = model.Direction;
            client.CharacterGame.Action = model.Action;

            // We throw off the attack if we moved
            if (client.CharacterGame.AttackedUniqueIdentifier != null)
            {
                _characterActionFactory.SendStopMoveCharacter(client, client);
                client.CharacterGame.AttackedUniqueIdentifier = null;
            }

            _characterActionFactory.SendMovedCharacters(client, client);

            foreach (var visibleCharacterGame in client.CharacterGame.VisibleCharacterGames)
            {
                _characterActionFactory.SendMovedCharacters(visibleCharacterGame, client);
            }
        }

        [HandlerAction(PacketType.CharJumpReq)]
        public void JumpCharacter(GameSession client, CharJumpReqModel model)
        {
            client.CharacterGame.DirectionSight = model.MoveDirection;
            client.CharacterGame.Action = model.Action;

            _characterActionFactory.SendJumpCharacter(client, client);

            foreach (var visibleCharacterGame in client.CharacterGame.VisibleCharacterGames)
            {
                _characterActionFactory.SendJumpCharacter(visibleCharacterGame, client);
            }
        }

        [HandlerAction(PacketType.CharDirReq)]
        public void DirCharacter(GameSession client, CharDirectionReqModel model)
        {
            client.CharacterGame.DirectionSight = model.Direction;

            _characterActionFactory.SendDirectionCharacter(client, client);

            foreach (var visibleCharacterGame in client.CharacterGame.VisibleCharacterGames)
            {
                _characterActionFactory.SendDirectionCharacter(visibleCharacterGame, client);
            }
        }

        [HandlerAction(PacketType.RespawnReq)]
        public void RespawnCharacter(GameSession client, RespawnReqModel model)
        {
            client.CharacterGame.Hp = (short)(client.CharacterGame.HpMax / 2);
            client.CharacterGame.Mp = (short)(client.CharacterGame.MpMax / 2);

            client.CharacterGame.DeadTime = null;

            _characterActionFactory.SendRespawnCharacter(client, client);
            _characteristicFactory.SendHealthPointCharacteristics(client);
        }
    }
}
