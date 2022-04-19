using Database.DataModel.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Character;
using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Models.Send.MonsterNpc;
using Packets.Server.Game.Structures;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;
using System.Collections.Generic;
using System.Linq;

namespace Server.Game.Core.Factories
{
    public class VisibleFactory : IVisibleFactory
    {
        public void SendDisplayedCharacters(IEnumerable<GameSession> clientsFrom, GameSession clientTo)
        {
            ExistedPcAckModel existedPcAckModel = new ExistedPcAckModel();

            foreach (var clientFrom in clientsFrom)
            {
                PublicPc publicPc = new PublicPc
                {
                    AliveOrDead = (byte)(clientFrom.Pc.DeadTime == null ? 1 : 0),
                    AttackRate = clientFrom.Pc.Detail.AttackRate,
                    MoveRate = clientFrom.Pc.Detail.MoveRate,
                    UniqueIdentifier = clientFrom.Pc.UniqueId,
                    Class = (byte)clientFrom.Pc.Simple.Class,
                    Gender = clientFrom.Pc.Simple.Sex,
                    Head = clientFrom.Pc.Simple.Head,
                    Face = clientFrom.Pc.Simple.Face,
                    Position = clientFrom.Pc.PositionCur,
                    Reputation = clientFrom.Pc.Detail.Chaotic,
                    Name = clientFrom.Pc.Simple.NickName,
                    Level = (short)clientFrom.Pc.Simple.Level,
                    ChaoticStatus = (int)clientFrom.Pc.Detail.ChaoticStatus,
                    PkCnt = 0
                };

                var weapon = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Weapon);
                if (weapon != null)
                {
                    publicPc.Weapon = weapon.Item.Id;
                }

                var shield = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Shield);
                if (shield != null)
                {
                    publicPc.Shield = shield.Item.Id;
                }

                var armor = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Armor);
                if (armor != null)
                {
                    publicPc.Armor = armor.Item.Id;
                }

                var ring1 = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Ring1);
                if (ring1 != null)
                {
                    publicPc.Ring1 = ring1.Item.Id;
                }

                var ring2 = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Ring2);
                if (ring2 != null)
                {
                    publicPc.Ring2 = ring2.Item.Id;
                }

                var amulet = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Amulet);
                if (amulet != null)
                {
                    publicPc.Amulet = amulet.Item.Id;
                }

                var boot = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Boot);
                if (boot != null)
                {
                    publicPc.Boot = boot.Item.Id;
                }

                var glove = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Glove);
                if (glove != null)
                {
                    publicPc.Glove = glove.Item.Id;
                }

                var cap = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Cap);
                if (cap != null)
                {
                    publicPc.Cap = cap.Item.Id;
                }

                var belt = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Belt);
                if (belt != null)
                {
                    publicPc.Belt = belt.Item.Id;
                }

                var cloak = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Cloak);
                if (cloak != null)
                {
                    publicPc.Cloak = cloak.Item.Id;
                }

                var expertnessMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.ExpertnessMaterial);
                if (expertnessMaterial != null)
                {
                    publicPc.ExpertnessMaterial = expertnessMaterial.Item.Id;
                }

                var soulMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.SoulMaterial);
                if (soulMaterial != null)
                {
                    publicPc.SoulMaterial = soulMaterial.Item.Id;
                }

                var defenceMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.DefenseMaterial);
                if (defenceMaterial != null)
                {
                    publicPc.DefenceMaterial = defenceMaterial.Item.Id;
                }

                var attackMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.AttackMaterial);
                if (attackMaterial != null)
                {
                    publicPc.AttackMaterial = attackMaterial.Item.Id;
                }

                var llifeMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.LifeMaterial);
                if (llifeMaterial != null)
                {
                    publicPc.LifeMaterial = llifeMaterial.Item.Id;
                }

                var eventAMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventAMaterial);
                if (eventAMaterial != null)
                {
                    publicPc.EventAMaterial = eventAMaterial.Item.Id;
                }

                var eventBMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventBMaterial);
                if (eventBMaterial != null)
                {
                    publicPc.EventBMaterial = eventBMaterial.Item.Id;
                }

                var eventCMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventCMaterial);
                if (eventCMaterial != null)
                {
                    publicPc.EventCMaterial = eventCMaterial.Item.Id;
                }

                existedPcAckModel.Character.Add(publicPc);
            }

            clientTo.Send(existedPcAckModel);
        }

        public void SendDisplayedDetailsCharacter(GameSession clientFrom, GameSession clientTo)
        {
            PublicPc publicPc = new PublicPc
            {
                AliveOrDead = (byte)(clientFrom.Pc.DeadTime == null ? 1 : 0),
                AttackRate = clientFrom.Pc.Detail.AttackRate,
                MoveRate = clientFrom.Pc.Detail.MoveRate,
                UniqueIdentifier = clientFrom.Pc.UniqueId,
                Class = (byte)clientFrom.Pc.Simple.Class,
                Gender = clientFrom.Pc.Simple.Sex,
                Head = clientFrom.Pc.Simple.Head,
                Face = clientFrom.Pc.Simple.Face,
                Position = clientFrom.Pc.PositionCur,
                Reputation = clientFrom.Pc.Detail.Chaotic,
                Name = clientFrom.Pc.Simple.NickName,
                Level = (short)clientFrom.Pc.Simple.Level,
                ChaoticStatus = (int)clientFrom.Pc.Detail.ChaoticStatus,
                PkCnt = 0
            };

            DisplayedCharacterModel displayedCharactersModel = new DisplayedCharacterModel
            {

                Character = new PublicPc()
                {
                    AliveOrDead = (byte)(clientFrom.Pc.DeadTime == null ? 1 : 0),
                    AttackRate = clientFrom.Pc.Detail.AttackRate,
                    MoveRate = clientFrom.Pc.Detail.MoveRate,
                    UniqueIdentifier = clientFrom.Pc.UniqueId,
                    Class = (byte)clientFrom.Pc.Simple.Class,
                    Gender = clientFrom.Pc.Simple.Sex,
                    Head = clientFrom.Pc.Simple.Head,
                    Face = clientFrom.Pc.Simple.Face,
                    Position = clientFrom.Pc.PositionCur,
                    Reputation = clientFrom.Pc.Detail.Chaotic,
                    Name = clientFrom.Pc.Simple.NickName,
                    Level = (short)clientFrom.Pc.Simple.Level,
                    ChaoticStatus = (int)clientFrom.Pc.Detail.ChaoticStatus,
                    PkCnt = 0
                }
            };

            var weapon = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Weapon);
            if (weapon != null)
            {
                displayedCharactersModel.Character.Weapon = weapon.Item.Id;
            }

            var shield = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Shield);
            if (shield != null)
            {
                displayedCharactersModel.Character.Shield = shield.Item.Id;
            }

            var armor = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Armor);
            if (armor != null)
            {
                displayedCharactersModel.Character.Armor = armor.Item.Id;
            }

            var ring1 = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Ring1);
            if (ring1 != null)
            {
                displayedCharactersModel.Character.Ring1 = ring1.Item.Id;
            }

            var ring2 = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Ring2);
            if (ring2 != null)
            {
                displayedCharactersModel.Character.Ring2 = ring2.Item.Id;
            }

            var amulet = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Amulet);
            if (amulet != null)
            {
                displayedCharactersModel.Character.Amulet = amulet.Item.Id;
            }

            var boot = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Boot);
            if (boot != null)
            {
                displayedCharactersModel.Character.Boot = boot.Item.Id;
            }

            var glove = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Glove);
            if (glove != null)
            {
                displayedCharactersModel.Character.Glove = glove.Item.Id;
            }

            var cap = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Cap);
            if (cap != null)
            {
                displayedCharactersModel.Character.Cap = cap.Item.Id;
            }

            var belt = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Belt);
            if (belt != null)
            {
                displayedCharactersModel.Character.Belt = belt.Item.Id;
            }

            var cloak = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Cloak);
            if (cloak != null)
            {
                displayedCharactersModel.Character.Cloak = cloak.Item.Id;
            }

            var expertnessMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.ExpertnessMaterial);
            if (expertnessMaterial != null)
            {
                displayedCharactersModel.Character.ExpertnessMaterial = expertnessMaterial.Item.Id;
            }

            var soulMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.SoulMaterial);
            if (soulMaterial != null)
            {
                displayedCharactersModel.Character.SoulMaterial = soulMaterial.Item.Id;
            }

            var defenceMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.DefenseMaterial);
            if (defenceMaterial != null)
            {
                displayedCharactersModel.Character.DefenceMaterial = defenceMaterial.Item.Id;
            }

            var attackMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.AttackMaterial);
            if (attackMaterial != null)
            {
                displayedCharactersModel.Character.AttackMaterial = attackMaterial.Item.Id;
            }

            var llifeMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.LifeMaterial);
            if (llifeMaterial != null)
            {
                displayedCharactersModel.Character.LifeMaterial = llifeMaterial.Item.Id;
            }

            var eventAMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventAMaterial);
            if (eventAMaterial != null)
            {
                displayedCharactersModel.Character.EventAMaterial = eventAMaterial.Item.Id;
            }

            var eventBMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventBMaterial);
            if (eventBMaterial != null)
            {
                displayedCharactersModel.Character.EventBMaterial = eventBMaterial.Item.Id;
            }

            var eventCMaterial = clientFrom.Pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventCMaterial);
            if (eventCMaterial != null)
            {
                displayedCharactersModel.Character.EventCMaterial = eventCMaterial.Item.Id;
            }

            clientTo.Send(displayedCharactersModel);
        }

        public void SendDisplayedItems(GameSession client, IEnumerable<GPublicItem> itemGameModels)
        {
            ExistedItemAckModel displayedItemModel = new ExistedItemAckModel();

            foreach (var itemGameModel in itemGameModels)
            {
                PublicItem item = new PublicItem
                {
                    Item = new ItemApiModel()
                    {
                        Flag = (byte)(itemGameModel.Item.IsConfirm ? 1 : 0),
                        SerialNumber = (ulong)itemGameModel.Item.Id,
                        ItemId = itemGameModel.Item.Id,
                        Count = itemGameModel.Item.Count,
                        EndTick = itemGameModel.Item.EndTick,
                        ItemStatus = (byte)itemGameModel.Item.Status,
                        UseCount = itemGameModel.Item.UseCount,
                        EatTime = itemGameModel.Item.EatTime,
                        TermOfEffectivity = itemGameModel.Item.TermOfValidity,
                        ItemBind = (byte)itemGameModel.Item.ItemBind,
                        Restore = itemGameModel.Item.Restore,
                        Hole = itemGameModel.Item.Hole
                    },
                    Position = itemGameModel.Position,
                    UniqueIdentifier = itemGameModel.UniqueId
                };

                displayedItemModel.Items.Add(item);
            }

            client.Send(displayedItemModel);
        }

        public void SendDisplayedDetailsItem(GameSession client, GPublicItem itemDroppedGame)
        {
            EnteredItemAckModel enteredItemModel = new EnteredItemAckModel()
            {
                Item = new PublicItem
                {
                    Item = new ItemApiModel()
                    {
                        Flag = (byte)(itemDroppedGame.Item.IsConfirm ? 1 : 0),
                        SerialNumber = (ulong)itemDroppedGame.Item.Id,
                        ItemId = itemDroppedGame.Item.Id,
                        Count = itemDroppedGame.Item.Count,
                        EndTick = itemDroppedGame.Item.EndTick,
                        ItemStatus = (byte)itemDroppedGame.Item.Status,
                        UseCount = itemDroppedGame.Item.UseCount,
                        EatTime = itemDroppedGame.Item.EatTime,
                        TermOfEffectivity = itemDroppedGame.Item.TermOfValidity,
                        ItemBind = (byte)itemDroppedGame.Item.ItemBind,
                        Restore = itemDroppedGame.Item.Restore,
                        Hole = itemDroppedGame.Item.Hole
                    },
                    UniqueIdentifier = itemDroppedGame.UniqueId,
                    Position = itemDroppedGame.Position
                }
            };

            client.Send(enteredItemModel);
        }

        public void SendDisplayedUnit(GameSession client, IEnumerable<GMonster> unitGameModels)
        {
            ExistedMonAckModel displayedNpcMonsterModel = new ExistedMonAckModel();

            foreach (var monster in unitGameModels)
            {
                MonsterApiModel npc = new MonsterApiModel
                {
                    AliveOrDead = (byte)(monster.DeadTime == null ? 1 : 0),
                    AttackRate = monster.Detail.AttackRate,
                    Reputation = monster.Detail.Chaotic,
                    DirectionSight = monster.DirectionSight,
                    Hp = (short)(monster.Simple.Hp * 100 / monster.ParmMon.Hp),
                    Level = 0,
                    MonsterId = monster.ParmMon.ParmNo,
                    MoveRate = monster.Detail.MoveRate,
                    OwnerName = "",
                    OwnerPcGuildNo = 0,
                    OwnerPcNo = 0,
                    ParmNo = (uint)monster.ParmMon.ParmNo,
                    Position = monster.PositionCur,
                    SummonType = 0,
                    UniqueIdentifier = monster.UniqueId,
                    TransformationId = monster.ParmMon.ParmNo
                };

                displayedNpcMonsterModel.NpcMonsters.Add(npc);
            }

            client.Send(displayedNpcMonsterModel);
        }

        public void SendDisplayedDetailsUnit(GameSession client, GMonster monster)
        {
            EnteredMonAckModel enteredMonAckModel = new EnteredMonAckModel()
            {
                Monster = new MonsterApiModel()
                {
                    AliveOrDead = (byte)(monster.DeadTime == null ? 1 : 0),
                    AttackRate = monster.Detail.AttackRate,
                    Reputation = monster.Detail.Chaotic,
                    DirectionSight = monster.DirectionSight,
                    Hp = (short)(monster.Hp * 100 / monster.ParmMon.Hp),
                    Level = 0,
                    MonsterId = monster.ParmMon.ParmNo,
                    MoveRate = monster.Detail.MoveRate,
                    OwnerName = "",
                    OwnerPcGuildNo = 0,
                    OwnerPcNo = 0,
                    ParmNo = (uint)monster.ParmMon.ParmNo,
                    Position = monster.PositionCur,
                    SummonType = 0,
                    UniqueIdentifier = monster.UniqueId,
                    TransformationId = monster.ParmMon.ParmNo
                }
            };

            client.Send(enteredMonAckModel);
        }

        public void SendExitMap(GameSession client, UniqueId uniqueItemDrop, ExitMapWhy exitMapWhy)
        {
            ExitMapGbjAckModel exitMapModel = new ExitMapGbjAckModel()
            {
                UniqueItemDrop = uniqueItemDrop,
                Why = exitMapWhy
            };

            client.Send(exitMapModel);
        }
    }
}
