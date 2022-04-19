using Packets.Server.Game.Models.Receive.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using System.Collections.Generic;
using Server.Game.Core.Systems;
using Packets.Core.Attributes;
using Server.Game.Models.Game;
using Server.Game.Network;
using Packets.Core.Enums;
using System.Linq;
using System;
using Database.DataModel.Enums;

namespace Server.Game.Core.Handlers
{
    [Handler]
    public class EquipHandler : IEquipHandler
    {
        private readonly ICharacteristicFactory _characteristicFactory;
        private readonly IEquipFactory _equipFactory;
        private readonly EquipSystem _equipSystem;
        private readonly AbnormalSystem  _abnormalSystem;

        public EquipHandler(ICharacteristicFactory characteristicFactory, IEquipFactory equipFactory, EquipSystem equipSystem, AbnormalSystem abnormalSystem)
        {
            _characteristicFactory = characteristicFactory;
            _equipFactory = equipFactory;
            _equipSystem = equipSystem;
            _abnormalSystem = abnormalSystem;
        }

        [HandlerAction(PacketType.EquipReq)]
        public void Equip(GameSession client, EquipReqModel wearEquipReqModel)
        {
            //GItem itemGame = client.Pc.Inventory.Items.FirstOrDefault(i => i.SerialNumber == wearEquipReqModel.SerialNumber);
            //if (itemGame == null)
            //{
            //    //TODO error
                return;
            //}

            //GItem itemGameEquipped = client.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == itemGame.EquipType);

            //// Check, newItem is ring? & slot ring1 not empty? Else newItem = ring2
            //if ((itemGame.EquipType == ItemEquipTypeEnum.Ring1 || itemGame.EquipType == ItemEquipTypeEnum.Ring2) && itemGameEquipped != null)
            //{
            //    itemGame.EquipType = ItemEquipTypeEnum.Ring2;
            //    itemGameEquipped = client.Pc.Items.FirstOrDefault(i => i.Position == ItemEquipTypeEnum.Ring2);
            
            //    // Remove buffs from equiped item
            //    if (itemGameEquipped?.EquipPos != null)
            //    {
            //        foreach (GBuff buff in itemGameEquipped.Buffs)
            //        {
            //            var buffGame = client.Pc.Buffs.FirstOrDefault(b => b.BuffId == buff.BuffId);

            //            if (buffGame != null)
            //            {
            //                client.Pc.Buffs.Remove(buff);
            //                _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
            //                _abnormalSystem.AbnormalRemove(client.Pc, buff);

            //                //Send all visible characters buff
            //                foreach (GameSession visibleCharacter in client.Pc.VisibleCharacterGames)
            //                {
            //                    _characteristicFactory.SendAbnormalRemove(client, visibleCharacter, buff.Type);
            //                }
            //            }
            //        }

            //        itemGameEquipped.EquipPos = null;
            //        _equipSystem.UnEquipItem(client.Pc, itemGameEquipped);
            //    }
            //}
            
            //if (itemGame.Buffs != null)
            //{
            //    foreach (GBuff buff in itemGame.Buffs)
            //    {
            //        var buffGame = client.Pc.Buffs.FirstOrDefault(b => b.BuffId == buff.BuffId);
            //        buff.EndTick = (uint)Environment.TickCount + buff.Time;

            //        if (buffGame == null)
            //        {
            //            client.Pc.Buffs.Add(buff);
            //            _abnormalSystem.AbnormalAdd(client.Pc, buff);
            //        }
            //        _characteristicFactory.SendAbnormalAdd(client, client, buff);

            //        //Send all visible characters equip & buff
            //        foreach (GameSession visibleCharacter in client.Pc.VisibleCharacterGames)
            //        {
            //            _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
            //        }
            //    }
            //}

            //itemGame.EquipPos = newItemType;
            //_equipSystem.EquipItem(client.Pc, itemGame);
            //_characteristicFactory.SendInformationAbilityCharacteristics(client);
            //_characteristicFactory.SendSpeedCharacteristics(client, client);
            //_characteristicFactory.SendInfoWeight(client);
            //_equipFactory.SendEquip(client, client, itemGame);

            //foreach (GameSession visibleCharacter in client.Pc.VisibleCharacterGames)
            //{
            //    _equipFactory.SendEquip(client, visibleCharacter, itemGame);
            //    _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
            //}
        }

        [HandlerAction(PacketType.UnEquipReq)]
        public void UnEquip(GameSession client, UnEquipReqModel unEquipReqModel)
        {
            //GItem itemGame = client.Pc.Items.FirstOrDefault(i => i.Position == (ItemEquipTypeEnum)unEquipReqModel.Position);

            //if (itemGame == null)
            //{
                return;
            //}

            //itemGame.EquipPos = null;

            //if (itemGame.Buffs != null && itemGame.Buffs.Count > 0)
            //{
            //    foreach (GBuff buff in itemGame.Buffs)
            //    {
            //        List<GItem> buffItems = client.Pc.Items.Where(i => i.Position != null && i.Buffs.Any(b => b.BuffId == buff.BuffId)).Select(i => i).ToList();
            //        GBuff buffGame = client.Pc.Buffs.FirstOrDefault(b => b.BuffId == buff.BuffId);

            //        //Check if items have the same buff
            //        if (buffItems.Count == 0 && buffGame != null)
            //        {
            //            client.Pc.Buffs.Remove(buff);
            //            _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
            //            _abnormalSystem.AbnormalRemove(client.Pc, buff);

            //            foreach (GameSession visibleCharacter in client.Pc.VisibleCharacterGames)
            //            {
            //                _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
            //            }
            //        }
            //    }
            //}

            //_equipSystem.UnEquipItem(client.Pc, itemGame);
            //_characteristicFactory.SendInformationAbilityCharacteristics(client);
            //_characteristicFactory.SendSpeedCharacteristics(client, client);
            //_characteristicFactory.SendInfoWeight(client);
            //_equipFactory.SendUnEquip(client, client, unEquipReqModel.Position);

            //foreach (GameSession visibleCharacter in client.Pc.VisibleCharacterGames)
            //{
            //    _equipFactory.SendUnEquip(client, visibleCharacter, unEquipReqModel.Position);
            //    _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
            //}
        }
    }
}