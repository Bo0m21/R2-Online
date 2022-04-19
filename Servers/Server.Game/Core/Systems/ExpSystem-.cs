using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.GameModels;
using Server.Game.Network;
using Server.Game.Services;

namespace Server.Game.Core.Systems
{
    public class ExpSystem
    {
        private readonly DatabaseBalanceService _databaseBalanceService;
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly CharacterSystem _characterSystem;

        public ExpSystem(DatabaseBalanceService databaseBalanceService, ICharacteristicFactory characteristicFactory, CharacterSystem characterSystem)
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
        public void KillConnection(UnitGameModel unitGameModel, GameSession gameSession)
        {
            var expModel = _databaseBalanceService.GetExpByLvl(gameSession.CharacterGame.Level);

            // TODO to confg 2 percent
            gameSession.CharacterGame.Exp -= (gameSession.CharacterGame.Exp / 100) * 2;

            if (gameSession.CharacterGame.Exp < 0)
            {
                gameSession.CharacterGame.Exp = 0;
            }

            _characteristicFactory.SendInfoExp(gameSession, expModel);
        }

        /// <summary>
        ///     Kill unit and update
        /// </summary>
        /// <param name="client"></param>
        /// <param name="unitGameModel"></param>
        public void KillUnit(GameSession client, UnitGameModel unitGameModel)
        {
            client.CharacterGame.Exp += unitGameModel.Exp;

            var expModel = _databaseBalanceService.GetExpByLvl(client.CharacterGame.Level);

            if (client.CharacterGame.Exp >= expModel.Exp)
            {
                client.CharacterGame.Exp = 0;
                client.CharacterGame.Level += 1;

                // TODO переписать
                _characterSystem.RecalculateCharacter(client.CharacterGame);

                client.CharacterGame.Hp = client.CharacterGame.HpMax;
                client.CharacterGame.Mp = client.CharacterGame.MpMax;

                _characteristicFactory.SendInformationAbilityCharacteristics(client);
                _characteristicFactory.SendHealthPointCharacteristics(client);
                _characteristicFactory.SendSpeedCharacteristics(client, client);
                _characteristicFactory.SendInfoWeight(client);

                _characteristicFactory.SendLevelUp(client, client);

                foreach (var visible in client.CharacterGame.VisibleCharacterGames)
                {
                _characteristicFactory.SendSpeedCharacteristics(client, visible);
                    _characteristicFactory.SendLevelUp(client, visible);
                }
            }
            _characteristicFactory.SendInfoExp(client, expModel);
        }
    }
}
