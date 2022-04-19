using Database.DataModel.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Models.Send.Character;
using Server.Game.Core.Factories.Interfaces;
using Server.Game.Models.Game;
using Server.Game.Network;
using System.Linq;

namespace Server.Game.Core.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public void SendCompleteCreateCharacters(GameSession client, GPc pc)
        {
            CompleteCreateCharacterModel completeCreateCharactersModel = new CompleteCreateCharacterModel()
            {
                CharacterId = (int)pc.Simple.PcNo,
                Str = pc.Ability.Str,
                Dex = pc.Ability.Dex,
                Int = pc.Ability.Int
            };

            client.Send(completeCreateCharactersModel);
        }

        public void SendCompleteDeleteCharacters(GameSession client, GPc pc)
        {
            CompleteDeleteCharacterModel completeDeleteCharactersModel = new CompleteDeleteCharacterModel();

            // Send empty packet

            client.Send(completeDeleteCharactersModel);
        }

        public void SendInformationCharacters(GameSession client)
        {
            InformationCharacterModel informationCharactersModel = new InformationCharacterModel();

            foreach (var pc in client.Pcs)
            {
                informationCharactersModel.Characters.Add(new Character
                {
                    Id = (int)pc.Simple.PcNo,
                    Class = (byte)pc.Simple.Class,
                    Gender = pc.Simple.Sex,
                    Head = pc.Simple.Head,
                    Face = pc.Simple.Face,
                    Level = (short)pc.Simple.Level,
                    Name = pc.Simple.NickName,
                    Str = pc.Ability.Str,
                    Dex = pc.Ability.Dex,
                    Int = pc.Ability.Int,
                    Chaotic = pc.Detail.Chaotic,
                    Position = pc.PositionCur
                });

                Equipment equipment = new Equipment();

                var weapon = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Weapon);
                if (weapon != null)
                {
                    equipment.Weapon = new Item
                    {
                        Id = (ulong)weapon.Item.SerialNumber,
                        ItemId = weapon.Item.Id
                    };
                }

                var shield = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Shield);
                if (shield != null)
                {
                    equipment.Shield = new Item
                    {
                        Id = (ulong)shield.Item.SerialNumber,
                        ItemId = shield.Item.Id
                    };
                }

                var armor = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Armor);
                if (armor != null)
                {
                    equipment.Armor = new Item
                    {
                        Id = (ulong)armor.Item.SerialNumber,
                        ItemId = armor.Item.Id
                    };
                }

                var ring1 = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Ring1);
                if (ring1 != null)
                {
                    equipment.FirstRing = new Item
                    {
                        Id = (ulong)ring1.Item.SerialNumber,
                        ItemId = ring1.Item.Id
                    };
                }

                var ring2 = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Ring2);
                if (ring2 != null)
                {
                    equipment.SecondRing = new Item
                    {
                        Id = (ulong)ring2.Item.SerialNumber,
                        ItemId = ring2.Item.Id
                    };
                }

                var amulet = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Amulet);
                if (amulet != null)
                {
                    equipment.Necklace = new Item
                    {
                        Id = (ulong)amulet.Item.SerialNumber,
                        ItemId = amulet.Item.Id
                    };
                }

                var boot = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Boot);
                if (boot != null)
                {
                    equipment.Boots = new Item
                    {
                        Id = (ulong)boot.Item.SerialNumber,
                        ItemId = boot.Item.Id
                    };
                }

                var glove = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Glove);
                if (glove != null)
                {
                    equipment.Gloves = new Item
                    {
                        Id = (ulong)glove.Item.SerialNumber,
                        ItemId = glove.Item.Id
                    };
                }

                var cap = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Cap);
                if (cap != null)
                {
                    equipment.Helmet = new Item
                    {
                        Id = (ulong)cap.Item.SerialNumber,
                        ItemId = cap.Item.Id
                    };
                }

                var belt = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Belt);
                if (belt != null)
                {
                    equipment.Belt = new Item
                    {
                        Id = (ulong)belt.Item.SerialNumber,
                        ItemId = belt.Item.Id
                    };
                }

                var cloak = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.Cloak);
                if (cloak != null)
                {
                    equipment.Cloak = new Item
                    {
                        Id = (ulong)cloak.Item.SerialNumber,
                        ItemId = cloak.Item.Id
                    };
                }

                var expertnessMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.ExpertnessMaterial);
                if (expertnessMaterial != null)
                {
                    equipment.SphereMastery = new Item
                    {
                        Id = (ulong)expertnessMaterial.Item.SerialNumber,
                        ItemId = expertnessMaterial.Item.Id
                    };
                }

                var soulMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.SoulMaterial);
                if (soulMaterial != null)
                {
                    equipment.SphereSoul = new Item
                    {
                        Id = (ulong)soulMaterial.Item.SerialNumber,
                        ItemId = soulMaterial.Item.Id
                    };
                }

                var defenceMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.DefenseMaterial);
                if (defenceMaterial != null)
                {
                    equipment.SphereDefense = new Item
                    {
                        Id = (ulong)defenceMaterial.Item.SerialNumber,
                        ItemId = defenceMaterial.Item.Id
                    };
                }

                var attackMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.AttackMaterial);
                if (attackMaterial != null)
                {
                    equipment.SphereDestruction = new Item
                    {
                        Id = (ulong)attackMaterial.Item.SerialNumber,
                        ItemId = attackMaterial.Item.Id
                    };
                }

                var llifeMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.LifeMaterial);
                if (llifeMaterial != null)
                {
                    equipment.SphereLife = new Item
                    {
                        Id = (ulong)llifeMaterial.Item.SerialNumber,
                        ItemId = llifeMaterial.Item.Id
                    };
                }

                var eventAMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventAMaterial);
                if (eventAMaterial != null)
                {
                    equipment.SphereLuck = new Item
                    {
                        Id = (ulong)eventAMaterial.Item.SerialNumber,
                        ItemId = eventAMaterial.Item.Id
                    };
                }

                var eventBMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventBMaterial);
                if (eventBMaterial != null)
                {
                    equipment.SphereReincarnation = new Item
                    {
                        Id = (ulong)eventBMaterial.Item.SerialNumber,
                        ItemId = eventBMaterial.Item.Id
                    };
                }

                var eventCMaterial = pc.Equip.FirstOrDefault(i => i.Item.EquipPos == ItemEquipTypeEnum.EventCMaterial);
                if (eventCMaterial != null)
                {
                    equipment.SphereCharacteristics = new Item
                    {
                        Id = (ulong)eventCMaterial.Item.SerialNumber,
                        ItemId = eventCMaterial.Item.Id
                    };
                }

                informationCharactersModel.Equipments.Add(equipment);
            }

            client.Send(informationCharactersModel);
        }
    }
}
