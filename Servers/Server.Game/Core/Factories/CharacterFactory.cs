using Database.Balance.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.GameModels;
using Server.Game.Network;
using System.Linq;

namespace Server.Game.Core.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public void SendCompleteCreateCharacters(GameSession client, CharacterGameModel characterGame)
        {
            CompleteCreateCharacterModel completeCreateCharactersModel = new CompleteCreateCharacterModel()
            {
                CharacterId = characterGame.Id,
                Str = characterGame.Str,
                Dex = characterGame.Dex,
                Int = characterGame.Int
            };

            client.Send(completeCreateCharactersModel);
        }

        public void SendCompleteDeleteCharacters(GameSession client, CharacterGameModel characterGame)
        {
            CompleteDeleteCharacterModel completeDeleteCharactersModel = new CompleteDeleteCharacterModel();

            // Send empty packet

            client.Send(completeDeleteCharactersModel);
        }

        public void SendInformationCharacters(GameSession client)
        {
            InformationCharacterModel informationCharactersModel = new InformationCharacterModel();

            foreach (var characterGame in client.Characters)
            {
                informationCharactersModel.Characters.Add(new Character
                {
                    Id = characterGame.Id,
                    Class = (byte)characterGame.Class,
                    Gender = characterGame.Gender,
                    Face = characterGame.Face,
                    Head = characterGame.Head,
                    Level = characterGame.Level,
                    Name = characterGame.Name,
                    Str = characterGame.Str,
                    Dex = characterGame.Dex,
                    Int = characterGame.Int,
                    Reputation = characterGame.Reputation,
                    Position = characterGame.Position
                });

                Equipment equipment = new Equipment();

                var weapon = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Weapon);

                if (weapon != null)
                {
                    equipment.Weapon = new Item
                    {
                        Id = (ulong)weapon.Id,
                        ItemId = weapon.ItemId
                    };
                }

                var shield = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Shield);

                if (shield != null)
                {
                    equipment.Shield = new Item
                    {
                        Id = (ulong)shield.Id,
                        ItemId = shield.ItemId
                    };
                }

                var armor = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Armor);

                if (armor != null)
                {
                    equipment.Armor = new Item
                    {
                        Id = (ulong)armor.Id,
                        ItemId = armor.ItemId
                    };
                }

                var ring1 = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Ring1);

                if (ring1 != null)
                {
                    equipment.FirstRing = new Item
                    {
                        Id = (ulong)ring1.Id,
                        ItemId = ring1.ItemId
                    };
                }

                var ring2 = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Ring2);

                if (ring2 != null)
                {
                    equipment.SecondRing = new Item
                    {
                        Id = (ulong)ring2.Id,
                        ItemId = ring2.ItemId
                    };
                }

                var amulet = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Amulet);

                if (amulet != null)
                {
                    equipment.Necklace = new Item
                    {
                        Id = (ulong)amulet.Id,
                        ItemId = amulet.ItemId
                    };
                }

                var boot = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Boot);

                if (boot != null)
                {
                    equipment.Boots = new Item
                    {
                        Id = (ulong)boot.Id,
                        ItemId = boot.ItemId
                    };
                }

                var glove = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Glove);

                if (glove != null)
                {
                    equipment.Gloves = new Item
                    {
                        Id = (ulong)glove.Id,
                        ItemId = glove.ItemId
                    };
                }

                var cap = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Cap);

                if (cap != null)
                {
                    equipment.Helmet = new Item
                    {
                        Id = (ulong)cap.Id,
                        ItemId = cap.ItemId
                    };
                }

                var belt = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Belt);

                if (belt != null)
                {
                    equipment.Belt = new Item
                    {
                        Id = (ulong)belt.Id,
                        ItemId = belt.ItemId
                    };
                }

                var cloak = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.Cloak);

                if (cloak != null)
                {
                    equipment.Cloak = new Item
                    {
                        Id = (ulong)cloak.Id,
                        ItemId = cloak.ItemId
                    };
                }

                var expertnessMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.ExpertnessMaterial);

                if (expertnessMaterial != null)
                {
                    equipment.SphereMastery = new Item
                    {
                        Id = (ulong)expertnessMaterial.Id,
                        ItemId = expertnessMaterial.ItemId
                    };
                }

                var soulMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.SoulMaterial);

                if (soulMaterial != null)
                {
                    equipment.SphereSoul = new Item
                    {
                        Id = (ulong)soulMaterial.Id,
                        ItemId = soulMaterial.ItemId
                    };
                }

                var defenceMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.DefenceMaterial);

                if (defenceMaterial != null)
                {
                    equipment.SphereDefense = new Item
                    {
                        Id = (ulong)defenceMaterial.Id,
                        ItemId = defenceMaterial.ItemId
                    };
                }

                var attackMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.AttackMaterial);

                if (attackMaterial != null)
                {
                    equipment.SphereDestruction = new Item
                    {
                        Id = (ulong)attackMaterial.Id,
                        ItemId = attackMaterial.ItemId
                    };
                }

                var llifeMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.LifeMaterial);

                if (llifeMaterial != null)
                {
                    equipment.SphereLife = new Item
                    {
                        Id = (ulong)llifeMaterial.Id,
                        ItemId = llifeMaterial.ItemId
                    };
                }

                var eventAMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventAMaterial);

                if (eventAMaterial != null)
                {
                    equipment.SphereLuck = new Item
                    {
                        Id = (ulong)eventAMaterial.Id,
                        ItemId = eventAMaterial.ItemId
                    };
                }

                var eventBMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventBMaterial);

                if (eventBMaterial != null)
                {
                    equipment.SphereReincarnation = new Item
                    {
                        Id = (ulong)eventBMaterial.Id,
                        ItemId = eventBMaterial.ItemId
                    };
                }

                var eventCMaterial = characterGame.Items.FirstOrDefault(i => i.Position == (ItemEquipType)ItemPositionType.EventCMaterial);

                if (eventCMaterial != null)
                {
                    equipment.SphereCharacteristics = new Item
                    {
                        Id = (ulong)eventCMaterial.Id,
                        ItemId = eventCMaterial.ItemId
                    };
                }

                informationCharactersModel.Equipments.Add(equipment);
            }

            client.Send(informationCharactersModel);
        }
    }
}
