using Database.Balance.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Character;
using Packets.Server.Game.Models.Send.Inventory;
using Packets.Server.Game.Models.Send.MonsterNpc;
using Packets.Server.Game.Structures;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Models.GameModels;
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
                var characterGame = clientFrom.CharacterGame;

                PublicPc publicPc = new PublicPc
                {
                    AliveOrDead = (byte)(characterGame.DeadTime == null ? 1 : 0),
                    AttackRate = characterGame.AttackRate,
                    MoveRate = characterGame.MoveRate,
                    UniqueIdentifier = clientFrom.CharacterGame.UniqueIdentifier,
                    Class = (byte)characterGame.Class,
                    Gender = characterGame.Gender,
                    Head = characterGame.Head,
                    Face = characterGame.Face,
                    Position = characterGame.Position,
                    Reputation = characterGame.Reputation,
                    Name = characterGame.Name,
                    Level = characterGame.Level,
                    ChaoticStatus = 0,
                    PkCnt = 0
                };

                var weapon = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Weapon);

                if (weapon != null)
                {
                    publicPc.Weapon = weapon.ItemId;
                }

                var shield = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Shield);

                if (shield != null)
                {
                    publicPc.Shield = shield.ItemId;
                }

                var armor = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Armor);

                if (armor != null)
                {
                    publicPc.Armor = armor.ItemId;
                }

                var ring1 = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Ring1);

                if (ring1 != null)
                {
                    publicPc.Ring1 = ring1.ItemId;
                }

                var ring2 = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Ring2);

                if (ring2 != null)
                {
                    publicPc.Ring2 = ring2.ItemId;
                }

                var amulet = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Amulet);

                if (amulet != null)
                {
                    publicPc.Amulet = amulet.ItemId;
                }

                var boot = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Boot);

                if (boot != null)
                {
                    publicPc.Boot = boot.ItemId;
                }

                var glove = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Glove);

                if (glove != null)
                {
                    publicPc.Glove = glove.ItemId;
                }

                var cap = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Cap);

                if (cap != null)
                {
                    publicPc.Cap = cap.ItemId;
                }

                var belt = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Belt);

                if (belt != null)
                {
                    publicPc.Belt = belt.ItemId;
                }

                var cloak = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Cloak);

                if (cloak != null)
                {
                    publicPc.Cloak = cloak.ItemId;
                }

                var expertnessMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.ExpertnessMaterial);

                if (expertnessMaterial != null)
                {
                    publicPc.ExpertnessMaterial = expertnessMaterial.ItemId;
                }

                var soulMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.SoulMaterial);

                if (soulMaterial != null)
                {
                    publicPc.SoulMaterial = soulMaterial.ItemId;
                }

                var defenceMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.DefenceMaterial);

                if (defenceMaterial != null)
                {
                    publicPc.DefenceMaterial = defenceMaterial.ItemId;
                }

                var attackMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.AttackMaterial);

                if (attackMaterial != null)
                {
                    publicPc.AttackMaterial = attackMaterial.ItemId;
                }

                var llifeMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.LifeMaterial);

                if (llifeMaterial != null)
                {
                    publicPc.LifeMaterial = llifeMaterial.ItemId;
                }

                var eventAMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventAMaterial);

                if (eventAMaterial != null)
                {
                    publicPc.EventAMaterial = eventAMaterial.ItemId;
                }

                var eventBMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventBMaterial);

                if (eventBMaterial != null)
                {
                    publicPc.EventBMaterial = eventBMaterial.ItemId;
                }

                var eventCMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventCMaterial);

                if (eventCMaterial != null)
                {
                    publicPc.EventCMaterial = eventCMaterial.ItemId;
                }

                existedPcAckModel.Character.Add(publicPc);
            }

            clientTo.Send(existedPcAckModel);
        }

        public void SendDisplayedDetailsCharacter(GameSession clientFrom, GameSession clientTo)
        {
            var characterGame = clientFrom.CharacterGame;

            DisplayedCharacterModel displayedCharactersModel = new DisplayedCharacterModel
            {
                Character = new PublicPc()
                {
                    AliveOrDead = (byte)(characterGame.DeadTime == null ? 1 : 0),
                    AttackRate = characterGame.AttackRate,
                    MoveRate = characterGame.MoveRate,
                    UniqueIdentifier = clientFrom.CharacterGame.UniqueIdentifier,
                    Class = (byte)characterGame.Class,
                    Gender = characterGame.Gender,
                    Head = characterGame.Head,
                    Face = characterGame.Face,
                    Position = characterGame.Position,
                    Reputation = characterGame.Reputation,
                    Name = characterGame.Name,
                    Level = characterGame.Level,
                    ChaoticStatus = 0,
                    PkCnt = 0
                }
            };

            var weapon = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Weapon);

            if (weapon != null)
            {
                displayedCharactersModel.Character.Weapon = weapon.ItemId;
            }

            var shield = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Shield);

            if (shield != null)
            {
                displayedCharactersModel.Character.Shield = shield.ItemId;
            }

            var armor = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Armor);

            if (armor != null)
            {
                displayedCharactersModel.Character.Armor = armor.ItemId;
            }

            var ring1 = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Ring1);

            if (ring1 != null)
            {
                displayedCharactersModel.Character.Ring1 = ring1.ItemId;
            }

            var ring2 = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Ring2);

            if (ring2 != null)
            {
                displayedCharactersModel.Character.Ring2 = ring2.ItemId;
            }

            var amulet = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Amulet);

            if (amulet != null)
            {
                displayedCharactersModel.Character.Amulet = amulet.ItemId;
            }

            var boot = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Boot);

            if (boot != null)
            {
                displayedCharactersModel.Character.Boot = boot.ItemId;
            }

            var glove = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Glove);

            if (glove != null)
            {
                displayedCharactersModel.Character.Glove = glove.ItemId;
            }

            var cap = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Cap);

            if (cap != null)
            {
                displayedCharactersModel.Character.Cap = cap.ItemId;
            }

            var belt = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Belt);

            if (belt != null)
            {
                displayedCharactersModel.Character.Belt = belt.ItemId;
            }

            var cloak = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Cloak);

            if (cloak != null)
            {
                displayedCharactersModel.Character.Cloak = cloak.ItemId;
            }

            var expertnessMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.ExpertnessMaterial);

            if (expertnessMaterial != null)
            {
                displayedCharactersModel.Character.ExpertnessMaterial = expertnessMaterial.ItemId;
            }

            var soulMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.SoulMaterial);

            if (soulMaterial != null)
            {
                displayedCharactersModel.Character.SoulMaterial = soulMaterial.ItemId;
            }

            var defenceMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.DefenceMaterial);

            if (defenceMaterial != null)
            {
                displayedCharactersModel.Character.DefenceMaterial = defenceMaterial.ItemId;
            }

            var attackMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.AttackMaterial);

            if (attackMaterial != null)
            {
                displayedCharactersModel.Character.AttackMaterial = attackMaterial.ItemId;
            }

            var llifeMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.LifeMaterial);

            if (llifeMaterial != null)
            {
                displayedCharactersModel.Character.LifeMaterial = llifeMaterial.ItemId;
            }

            var eventAMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventAMaterial);

            if (eventAMaterial != null)
            {
                displayedCharactersModel.Character.EventAMaterial = eventAMaterial.ItemId;
            }

            var eventBMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventBMaterial);

            if (eventBMaterial != null)
            {
                displayedCharactersModel.Character.EventBMaterial = eventBMaterial.ItemId;
            }

            var eventCMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventCMaterial);

            if (eventCMaterial != null)
            {
                displayedCharactersModel.Character.EventCMaterial = eventCMaterial.ItemId;
            }

            clientTo.Send(displayedCharactersModel);
        }

        public void SendDisplayedItems(GameSession client, IEnumerable<PublicItemGameModel> itemGameModels)
        {
            ExistedItemAckModel displayedItemModel = new ExistedItemAckModel();

            foreach (var itemGameModel in itemGameModels)
            {
                PublicItem item = new PublicItem
                {
                    Item = new Packets.Server.Game.Structures.Item()
                    {
                        Flag = itemGameModel.Item.Flag,
                        SerialNumber = (ulong)itemGameModel.Item.Id,
                        ItemId = itemGameModel.Item.ItemId,
                        Count = itemGameModel.Item.Count,
                        EndTick = itemGameModel.Item.EndTick,
                        ItemStatus = (byte)itemGameModel.Item.ItemStatus,
                        UseCount = itemGameModel.Item.UseCount,
                        EatTime = itemGameModel.Item.EatTime,
                        TermOfEffectivity = itemGameModel.Item.TermOfEffectivity,
                        ItemBind = (byte)itemGameModel.Item.ItemBind,
                        Restore = itemGameModel.Item.Restore,
                        Hole = itemGameModel.Item.Hole
                    },
                    Position = itemGameModel.Position,
                    UniqueIdentifier = itemGameModel.UniqueIdentifier
                };

                displayedItemModel.Items.Add(item);
            }

            client.Send(displayedItemModel);
        }

        public void SendDisplayedDetailsItem(GameSession client, PublicItemGameModel itemDroppedGame)
        {
            EnteredItemAckModel enteredItemModel = new EnteredItemAckModel()
            {
                Item = new PublicItem
                {
                    Item = new Packets.Server.Game.Structures.Item()
                    {
                        Flag = itemDroppedGame.Item.Flag,
                        SerialNumber = (ulong)itemDroppedGame.Item.Id,
                        ItemId = itemDroppedGame.Item.ItemId,
                        Count = itemDroppedGame.Item.Count,
                        EndTick = itemDroppedGame.Item.EndTick,
                        ItemStatus = (byte)itemDroppedGame.Item.ItemStatus,
                        UseCount = itemDroppedGame.Item.UseCount,
                        EatTime = itemDroppedGame.Item.EatTime,
                        TermOfEffectivity = itemDroppedGame.Item.TermOfEffectivity,
                        ItemBind = (byte)itemDroppedGame.Item.ItemBind,
                        Restore = itemDroppedGame.Item.Restore,
                        Hole = itemDroppedGame.Item.Hole
                    },
                    UniqueIdentifier = itemDroppedGame.UniqueIdentifier,
                    Position = itemDroppedGame.Position
                }
            };

            client.Send(enteredItemModel);
        }

        public void SendDisplayedUnit(GameSession client, IEnumerable<UnitGameModel> unitGameModels)
        {
            ExistedMonAckModel displayedNpcMonsterModel = new ExistedMonAckModel();

            foreach (var unitGameModel in unitGameModels)
            {
                Monster npc = new Monster
                {
                    AliveOrDead = (byte)(unitGameModel.DeadTime == null ? 1 : 0),
                    AttackRate = unitGameModel.AttackRate,
                    Reputation = unitGameModel.Reputation,
                    DirectionSight = unitGameModel.DirectionSight,
                    Hp = (short)(unitGameModel.Hp * 100 / unitGameModel.HpMax),
                    Level = 0,
                    MonsterId = unitGameModel.UnitId,
                    MoveRate = unitGameModel.MoveRate,
                    OwnerName = "",
                    OwnerPcGuildNo = 0,
                    OwnerPcNo = 0,
                    ParmNo = (uint)unitGameModel.UnitId,
                    Position = unitGameModel.Position,
                    SummonType = 0,
                    UniqueIdentifier = unitGameModel.UniqueIdentifier,
                    TransformationId = unitGameModel.UnitId
                };

                displayedNpcMonsterModel.NpcMonsters.Add(npc);
            }

            client.Send(displayedNpcMonsterModel);
        }

        public void SendDisplayedDetailsUnit(GameSession client, UnitGameModel unitGameModel)
        {
            EnteredMonAckModel enteredMonAckModel = new EnteredMonAckModel()
            {
                Monster = new Monster()
                {
                    AliveOrDead = (byte)(unitGameModel.DeadTime == null ? 1 : 0),
                    AttackRate = unitGameModel.AttackRate,
                    Reputation = unitGameModel.Reputation,
                    DirectionSight = unitGameModel.DirectionSight,
                    Hp = unitGameModel.Hp,
                    Level = 0,
                    MonsterId = unitGameModel.UnitId,
                    MoveRate = unitGameModel.MoveRate,
                    OwnerName = "",
                    OwnerPcGuildNo = 0,
                    OwnerPcNo = 0,
                    ParmNo = (uint)unitGameModel.UnitId,
                    Position = unitGameModel.Position,
                    SummonType = 0,
                    UniqueIdentifier = unitGameModel.UniqueIdentifier,
                    TransformationId = unitGameModel.UnitId
                }
            };

            client.Send(enteredMonAckModel);
        }

        public void SendExitMap(GameSession client, UniqueIdentifier uniqueItemDrop, ExitMapWhy exitMapWhy)
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
