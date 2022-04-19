using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;
using Server.Game.Services;
using Server.Game.Services.Database;

namespace Server.Game.Core.Systems
{
    public class ExpSystem
    {
        private readonly ParmRepository _databaseBalanceService;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly CharacterSystem _characterSystem;

        public ExpSystem(ParmRepository databaseBalanceService, ICharacteristicFactory characteristicFactory, CharacterSystem characterSystem)
        {
            _databaseBalanceService = databaseBalanceService;
            _characteristicFactory = characteristicFactory;
            _characterSystem = characterSystem;
        }

        /// <summary>
        ///     Kill connection and update
        /// </summary>
        /// <param name="unitGameModel"></param>
        /// <param name="gameSession"></param>
        public void KillConnection(GMonster unitGameModel, GameSession gameSession)
        {
            var expModel = _databaseBalanceService.GetExpByLvl(gameSession.Pc.Simple.Level);

            // TODO to confg 2 percent
            gameSession.Pc.Simple.Exp -= (gameSession.Pc.Simple.Exp / 100) * 2;

            if (gameSession.Pc.Simple.Exp < 0)
            {
                gameSession.Pc.Simple.Exp = 0;
            }

            _characteristicFactory.SendInfoExp(gameSession, expModel);
        }

        /// <summary>
        ///     Kill unit and update
        /// </summary>
        /// <param name="client"></param>
        /// <param name="monster"></param>
        public void KillUnit(GameSession client, GMonster monster)
        {
            client.Pc.Simple.Exp += monster.ParmMon.Exp;

            var expModel = _databaseBalanceService.GetExpByLvl(client.Pc.Simple.Level);

            if (client.Pc.Simple.Exp >= expModel.Exp)
            {
                client.Pc.Simple.Exp = 0;
                client.Pc.Simple.Level += 1;

                // TODO переписать
                //_characterSystem.RecalculateCharacter(client.Pc);

                client.Pc.Simple.Hp = client.Pc.Ability.MaxHp;
                client.Pc.Simple.Mp = client.Pc.Ability.MaxMp;

                _characteristicFactory.SendInformationAbilityCharacteristics(client);
                _characteristicFactory.SendHealthPointCharacteristics(client);
                _characteristicFactory.SendSpeedCharacteristics(client, client);
                _characteristicFactory.SendInfoWeight(client);

                _characteristicFactory.SendLevelUp(client, client);

                foreach (var visible in client.Pc.VisibleCharacterGames)
                {
                _characteristicFactory.SendSpeedCharacteristics(client, visible);
                    _characteristicFactory.SendLevelUp(client, visible);
                }
            }
            _characteristicFactory.SendInfoExp(client, expModel);
        }
    }
}
