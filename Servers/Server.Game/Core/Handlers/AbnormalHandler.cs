using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Receive.Action;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Core.Systems;
using Server.Game.Models.Game;
using Server.Game.Network;
using System.Linq;
using System.Net.Http;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class AbnormalHandler : IAbnormalHandler
    {
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly AbnormalSystem  _abnormalSystem;

        public AbnormalHandler(ICharacteristicFactory characteristicFactory, AbnormalSystem abnormalSystem)
        {
            _characteristicFactory = characteristicFactory;
            _abnormalSystem = abnormalSystem;
        }

        [HandlerAction(PacketType.AbnormalRemoveReq)]
        public void AbnormalRemove(GameSession client, AbnormalRemoveReqModel model)
        {
            BuffGameModel buffGame = client.CharacterGame.Buffs.FirstOrDefault(i => i.Type == (AbnormalType)model.Type);

            if(buffGame == null)
            {
                //TODO add error
                return;
            }

            if (client.CharacterGame.Buffs == null || client.CharacterGame.Buffs.Count == 0)
            {
                //TODO add error
                return;
            }

            client.CharacterGame.Buffs.Remove(buffGame);
            _abnormalSystem.AbnormalRemove(client.CharacterGame, buffGame);

            _characteristicFactory.SendAbnormalRemove(client, client, buffGame.Type);
            _characteristicFactory.SendInformationAbilityCharacteristics(client);
            _characteristicFactory.SendSpeedCharacteristics(client, client);
            _characteristicFactory.SendInfoWeight(client);

            foreach (var visibleCharacter in client.CharacterGame.VisibleCharacterGames)
            {
                _characteristicFactory.SendAbnormalRemove(client, visibleCharacter, buffGame.Type);
                _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);

            }
        }
    }
}