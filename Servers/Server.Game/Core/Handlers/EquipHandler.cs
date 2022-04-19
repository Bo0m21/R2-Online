using Packets.Server.Game.Models.Receive.Inventory;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Core.Handlers.Interfaces;
using Server.Game.Models.GameModels;
using System.Collections.Generic;
using Server.Game.Core.Systems;
using Packets.Core.Attributes;
using Server.Game.Models.Game;
using Database.Balance.Enums;
using Server.Game.Network;
using Packets.Core.Enums;
using System.Linq;
using System;

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
            ItemGameModel itemGame = client.CharacterGame.Items.FirstOrDefault(i => (ulong)i.Id == wearEquipReqModel.SerialNumber);

            if (itemGame == null)
            {
                //TODO error
                return;
            }

            ItemEquipType? newItemType = itemGame.EquipType;
            ItemGameModel itemGameEquipped = client.CharacterGame.Items.FirstOrDefault(i => i.Position == newItemType);

            // Check, newItem is ring? & slot ring1 not empty? Else newItem = ring2
            if ((newItemType == ItemEquipType.Ring1 || newItemType == ItemEquipType.Ring2) && itemGameEquipped != null)
            {
                newItemType = ItemEquipType.Ring2;
                itemGameEquipped = client.CharacterGame.Items.FirstOrDefault(i => i.Position == ItemEquipType.Ring2);
            
                // Remove buffs from equiped item
                if (itemGameEquipped?.Position != null)
                {
                    foreach (BuffGameModel buff in itemGameEquipped.Buffs)
                    {
                        var buffGame = client.CharacterGame.Buffs.FirstOrDefault(b => b.BuffId == buff.BuffId);

                        if (buffGame != null)
                        {
                            client.CharacterGame.Buffs.Remove(buff);
                            _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
                            _abnormalSystem.AbnormalRemove(client.CharacterGame, buff);

                            //Send all visible characters buff
                            foreach (GameSession visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                            {
                                _characteristicFactory.SendAbnormalRemove(client, visibleCharacter, buff.Type);
                            }
                        }
                    }

                    itemGameEquipped.Position = null;
                    _equipSystem.UnEquipItem(client.CharacterGame, itemGameEquipped);
                }
            }
            
            if (itemGame.Buffs != null)
            {
                foreach (BuffGameModel buff in itemGame.Buffs)
                {
                    var buffGame = client.CharacterGame.Buffs.FirstOrDefault(b => b.BuffId == buff.BuffId);
                    buff.EndTick = (uint)Environment.TickCount + buff.Time;

                    if (buffGame == null)
                    {
                        client.CharacterGame.Buffs.Add(buff);
                        _abnormalSystem.AbnormalAdd(client.CharacterGame, buff);
                    }
                    _characteristicFactory.SendAbnormalAdd(client, client, buff);

                    //Send all visible characters equip & buff
                    foreach (GameSession visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                    {
                        _characteristicFactory.SendAbnormalAdd(client, visibleCharacter, buff);
                    }
                }
            }

            itemGame.Position = newItemType;
            _equipSystem.EquipItem(client.CharacterGame, itemGame);
            _characteristicFactory.SendInformationAbilityCharacteristics(client);
            _characteristicFactory.SendSpeedCharacteristics(client, client);
            _characteristicFactory.SendInfoWeight(client);
            _equipFactory.SendEquip(client, client, itemGame);

            foreach (GameSession visibleCharacter in client.CharacterGame.VisibleCharacterGames)
            {
                _equipFactory.SendEquip(client, visibleCharacter, itemGame);
                _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
            }
        }

        [HandlerAction(PacketType.UnEquipReq)]
        public void UnEquip(GameSession client, UnEquipReqModel unEquipReqModel)
        {
            ItemGameModel itemGame = client.CharacterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)unEquipReqModel.Position);

            if (itemGame == null)
            {
                return;
            }

            itemGame.Position = null;

            if (itemGame.Buffs != null && itemGame.Buffs.Count > 0)
            {
                foreach (BuffGameModel buff in itemGame.Buffs)
                {
                    List<ItemGameModel> buffItems = client.CharacterGame.Items.Where(i => i.Position != null && i.Buffs.Any(b => b.BuffId == buff.BuffId)).Select(i => i).ToList();
                    BuffGameModel buffGame = client.CharacterGame.Buffs.FirstOrDefault(b => b.BuffId == buff.BuffId);

                    //Check if items have the same buff
                    if (buffItems.Count == 0 && buffGame != null)
                    {
                        client.CharacterGame.Buffs.Remove(buff);
                        _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
                        _abnormalSystem.AbnormalRemove(client.CharacterGame, buff);

                        foreach (GameSession visibleCharacter in client.CharacterGame.VisibleCharacterGames)
                        {
                            _characteristicFactory.SendAbnormalRemove(client, client, buff.Type);
                        }
                    }
                }
            }

            _equipSystem.UnEquipItem(client.CharacterGame, itemGame);
            _characteristicFactory.SendInformationAbilityCharacteristics(client);
            _characteristicFactory.SendSpeedCharacteristics(client, client);
            _characteristicFactory.SendInfoWeight(client);
            _equipFactory.SendUnEquip(client, client, unEquipReqModel.Position);

            foreach (GameSession visibleCharacter in client.CharacterGame.VisibleCharacterGames)
            {
                _equipFactory.SendUnEquip(client, visibleCharacter, unEquipReqModel.Position);
                _characteristicFactory.SendSpeedCharacteristics(client, visibleCharacter);
            }
        }
    }
}