using Database.DataModel.Enums;
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
            //GBuff buffGame = client.Pc.Buffs.FirstOrDefault(i => i.Type == (AbnormalTypeEnum)model.Type);

            //if(buffGame == null)
            //{
            //    //TODO add error
                return;
            //}

            //if (client.Pc.Buffs == null || client.Pc.Buffs.Count == 0)
            //{
            //    //TODO add error
            //    return;
            //}

            //client.Pc.Buffs.Remove(buffGame);
            //_abnormalSystem.AbnormalRemove(client.Pc, buffGame);

            //_characteristicFactory.SendAbnormalRemove(client, client, buffGame.Type);
            //_characteristicFactory.SendInformationAbilityCharacteristics(client);
            //_characteristicFactory.SendSpeedCharacteristics(client, client);
            //_characteristicFactory.SendInfoWeight(client);

            //foreach (var visibleCharacter in client.Pc.VisibleCharacterGames)
            //{
            //    _characteristicFactory.SendAbnormalRemove(client, visibleCharacter, buffGame.Type);
            //    _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);

            //}
        }
    }
}