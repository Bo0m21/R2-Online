using Packets.Server.Game.Models.Send.Character.Characteristics;
using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Models.Send.Level;
using Packets.Server.Game.Models.Send.Action;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;
using System;

namespace Server.Game.Core.Factories
{
    public class CharacteristicFactory : ICharacteristicFactory
    {
        public void SendInformationAbilityCharacteristics(GameSession client)
        {
            InventoryCharacteristicModel inventoryCharacteristicsModel = new InventoryCharacteristicModel
            {
                DDd = (short)client.CharacterGame.DDd,
                MDd = (short)client.CharacterGame.MDd,
                RDd = (short)client.CharacterGame.RDd,
                DPv = (short)client.CharacterGame.DPv,
                MPv = (short)client.CharacterGame.MPv,
                RPv = (short)client.CharacterGame.RPv,
                DDv = (short)client.CharacterGame.DDvMin,
                DHit = (short)client.CharacterGame.DHit,
                RDv = (short)client.CharacterGame.RDvMin,
                RHit = (short)client.CharacterGame.RHit,
                MDv = (short)client.CharacterGame.MDvMin,
                MHit = (short)client.CharacterGame.MHit,
                Str = client.CharacterGame.Str,
                Dex = client.CharacterGame.Dex,
                Int = client.CharacterGame.Int,
                CriticalHit = client.CharacterGame.Critical,
                HpMax = client.CharacterGame.HpMax,
                MpMax = client.CharacterGame.MpMax
            };

            client.Send(inventoryCharacteristicsModel);
        }

        public void SendHealthPointCharacteristics(GameSession client)
        {
            HealthPointCharacteristicModel healthPointCharacteristicsModel = new HealthPointCharacteristicModel
            {
                Hp = client.CharacterGame.Hp,
                Mp = client.CharacterGame.Mp
            };

            client.Send(healthPointCharacteristicsModel);
        }

        public void SendSpeedCharacteristics(GameSession client, GameSession clientTo)
        {
            SpeedCharacteristicModel speedCharacteristicsModel = new SpeedCharacteristicModel
            {
                AttackRate = client.CharacterGame.AttackRate,
                MoveRate = client.CharacterGame.MoveRate,
                SessionGameId = client.CharacterGame.UniqueIdentifier
            };

            clientTo.Send(speedCharacteristicsModel);
        }

        public void SendInfoWeight(GameSession client)
        {
            InfoWeightAckModel infoWeightAckModel = new InfoWeightAckModel
            {
                MaxWeight = client.CharacterGame.WeightMax,
                Weight = client.CharacterGame.Weight
            };

            client.Send(infoWeightAckModel);
        }

        public void SendInfoExp(GameSession client, ExpGameModel expGame)
        {
            InfoExpAckModel infoExpAckModel = new InfoExpAckModel
            {
                Level = client.CharacterGame.Level,
                Exp = client.CharacterGame.Exp,
                ExpAim = expGame.Exp
            };

            client.Send(infoExpAckModel);
        }

        public void SendLevelUp(GameSession clientFrom, GameSession clientTo)
        {
            LevelUpAckModel levelUpAckModel = new LevelUpAckModel
            {
                SessionGameId = clientFrom.CharacterGame.UniqueIdentifier,
                Hp = clientFrom.CharacterGame.HpMax,
                Mp = clientFrom.CharacterGame.HpMax,
            };

            clientTo.Send(levelUpAckModel);
        }

        public void SendAbnormalAdd(GameSession client, GameSession clientTo, BuffGameModel buffModel)
        {
            AbnormalAckModel abnormalAckModel = new AbnormalAckModel
            {
                UniqueIdentifier = client.CharacterGame.UniqueIdentifier,
                BuffId = buffModel.BuffId,
                EndTick = buffModel.EndTick,
                Position = client.CharacterGame.Position
            };

            clientTo.Send(abnormalAckModel);
        }

        public void SendAbnormalRemove(GameSession client, GameSession clientTo, AbnormalType type)
        {
            AbnormalReleaseAckModel abnormalReleaseAckModel = new AbnormalReleaseAckModel
            {
                UniqueIdentifier = client.CharacterGame.UniqueIdentifier,
                Type = (int)type
            };

            clientTo.Send(abnormalReleaseAckModel);
        }
    }
}
