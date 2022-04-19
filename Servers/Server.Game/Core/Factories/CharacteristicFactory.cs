using Packets.Server.Game.Models.Send.Character.Characteristics;
using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Models.Send.Level;
using Packets.Server.Game.Models.Send.Action;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;
using System;
using Database.DataModel.Enums;

namespace Server.Game.Core.Factories
{
    public class CharacteristicFactory : ICharacteristicFactory
    {
        public void SendInformationAbilityCharacteristics(GameSession client)
        {
            InventoryCharacteristicModel inventoryCharacteristicsModel = new InventoryCharacteristicModel
            {
                DDv = (short)client.Pc.Ability.DDv,
                MDv = (short)client.Pc.Ability.MDv,
                RDv = (short)client.Pc.Ability.RDv,
                DPv = (short)client.Pc.Ability.DPv,
                MPv = (short)client.Pc.Ability.MPv,
                RPv = (short)client.Pc.Ability.RPv,
                DDD = (short)client.Pc.Ability.DDD,
                DHit = (short)client.Pc.Ability.DHit,
                RDD = (short)client.Pc.Ability.RDD,
                RHit = (short)client.Pc.Ability.RHit,
                MDD = (short)client.Pc.Ability.MDD,
                MHit = (short)client.Pc.Ability.MHit,
                Str = client.Pc.Ability.Str,
                Dex = client.Pc.Ability.Dex,
                Int = client.Pc.Ability.Int,
                CriticalHit = client.Pc.Ability.CriticalHit,
                HpMax = client.Pc.Ability.MaxHp,
                MpMax = client.Pc.Ability.MaxMp
            };

            client.Send(inventoryCharacteristicsModel);
        }

        public void SendHealthPointCharacteristics(GameSession client)
        {
            HealthPointCharacteristicModel healthPointCharacteristicsModel = new HealthPointCharacteristicModel
            {
                Hp = client.Pc.Simple.Hp,
                Mp = client.Pc.Simple.Mp
            };

            client.Send(healthPointCharacteristicsModel);
        }

        public void SendSpeedCharacteristics(GameSession client, GameSession clientTo)
        {
            SpeedCharacteristicModel speedCharacteristicsModel = new SpeedCharacteristicModel
            {
                AttackRate = client.Pc.Detail.AttackRate,
                MoveRate = client.Pc.Detail.MoveRate,
                SessionGameId = client.Pc.UniqueId
            };

            clientTo.Send(speedCharacteristicsModel);
        }

        public void SendInfoWeight(GameSession client)
        {
            InfoWeightAckModel infoWeightAckModel = new InfoWeightAckModel
            {
                MaxWeight = client.Pc.Inventory.MaxWeight,
                Weight = client.Pc.Inventory.Weight
            };

            client.Send(infoWeightAckModel);
        }

        public void SendInfoExp(GameSession client, GExp expGame)
        {
            InfoExpAckModel infoExpAckModel = new InfoExpAckModel
            {
                Level = (short)client.Pc.Simple.Level,
                Exp = (long)client.Pc.Simple.Exp,
                ExpAim = expGame.Exp
            };

            client.Send(infoExpAckModel);
        }

        public void SendLevelUp(GameSession clientFrom, GameSession clientTo)
        {
            LevelUpAckModel levelUpAckModel = new LevelUpAckModel
            {
                SessionGameId = clientFrom.Pc.UniqueId,
                Hp = clientFrom.Pc.Ability.MaxHp,
                Mp = clientFrom.Pc.Ability.MaxHp,
            };

            clientTo.Send(levelUpAckModel);
        }

        public void SendAbnormalAdd(GameSession client, GameSession clientTo, GBuff buffModel)
        {
            AbnormalAckModel abnormalAckModel = new AbnormalAckModel
            {
                UniqueIdentifier = client.Pc.UniqueId,
                BuffId = buffModel.BuffId,
                EndTick = buffModel.EndTick,
                Position = client.Pc.PositionCur
            };

            clientTo.Send(abnormalAckModel);
        }

        public void SendAbnormalRemove(GameSession client, GameSession clientTo, AbnormalTypeEnum type)
        {
            AbnormalReleaseAckModel abnormalReleaseAckModel = new AbnormalReleaseAckModel
            {
                UniqueIdentifier = client.Pc.UniqueId,
                Type = (int)type
            };

            clientTo.Send(abnormalReleaseAckModel);
        }
    }
}
