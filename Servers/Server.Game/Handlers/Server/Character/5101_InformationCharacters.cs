using System.Linq;
using Core.Models;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Game.Handlers.Server.Character
{
    /// <summary>
    ///     Обработчик пакета персонажей
    /// </summary>
    public class InformationCharacters : AsHandler<InformationCharactersModel>
    {
        public override int Code { get; set; } = 5101;

        public override InformationCharactersModel Treatment(ConnectionModel connection)
        {
            var informationCharactersModel = new InformationCharactersModel();
            ServiceProvider serviceProvider = Program.ServiceCollection.BuildServiceProvider();

            using (IDatabaseContext databaseContext = serviceProvider.GetService<IDatabaseContext>())
            {
                IQueryable<CharacterModel> characters = databaseContext.Characters
                    .Include(e => e.Equipment)
                    .Include(i => i.Items)
                    .Where(c => c.AccountId == connection.AccountId);

                foreach (CharacterModel character in characters)
                {
                    informationCharactersModel.Characters.Add(new Models.Server.Character.Character
                    {
                        Id = character.Id,
                        ClassId = character.ClassId,
                        Gender = character.Gender,
                        TypeFace = character.TypeFace,
                        TypeHairStyle = character.TypeHairStyle,
                        Level = character.Level,
                        Name = character.Name,
                        Force = character.Force,
                        Intelligence = character.Intelligence,
                        Adroitness = character.Adroitness,
                        Reputation = character.Reputation,
                        CoordinateX = character.CoordinateX,
                        CoordinateZ = character.CoordinateZ,
                        CoordinateY = character.CoordinateY
                    });

                    var equipment = new Equipment();

                    if (character.Equipment.Weapon != null)
                    {
                        equipment.Weapon = new Item
                        {
                            Id = character.Equipment.Weapon.Id,
                            ItemId = character.Equipment.Weapon.ItemId
                        };
                    }

                    if (character.Equipment.Shield != null)
                    {
                        equipment.Shield = new Item
                        {
                            Id = character.Equipment.Shield.Id,
                            ItemId = character.Equipment.Shield.ItemId
                        };
                    }

                    if (character.Equipment.Armor != null)
                    {
                        equipment.Armor = new Item
                        {
                            Id = character.Equipment.Armor.Id,
                            ItemId = character.Equipment.Armor.ItemId
                        };
                    }

                    if (character.Equipment.FirstRing != null)
                    {
                        equipment.FirstRing = new Item
                        {
                            Id = character.Equipment.FirstRing.Id,
                            ItemId = character.Equipment.FirstRing.ItemId
                        };
                    }

                    if (character.Equipment.SecondRing != null)
                    {
                        equipment.SecondRing = new Item
                        {
                            Id = character.Equipment.SecondRing.Id,
                            ItemId = character.Equipment.SecondRing.ItemId
                        };
                    }

                    if (character.Equipment.Necklace != null)
                    {
                        equipment.Necklace = new Item
                        {
                            Id = character.Equipment.Necklace.Id,
                            ItemId = character.Equipment.Necklace.ItemId
                        };
                    }

                    if (character.Equipment.Boots != null)
                    {
                        equipment.Boots = new Item
                        {
                            Id = character.Equipment.Boots.Id,
                            ItemId = character.Equipment.Boots.ItemId
                        };
                    }

                    if (character.Equipment.Gloves != null)
                    {
                        equipment.Gloves = new Item
                        {
                            Id = character.Equipment.Gloves.Id,
                            ItemId = character.Equipment.Gloves.ItemId
                        };
                    }

                    if (character.Equipment.Helmet != null)
                    {
                        equipment.Helmet = new Item
                        {
                            Id = character.Equipment.Helmet.Id,
                            ItemId = character.Equipment.Helmet.ItemId
                        };
                    }

                    if (character.Equipment.Belt != null)
                    {
                        equipment.Belt = new Item
                        {
                            Id = character.Equipment.Belt.Id,
                            ItemId = character.Equipment.Belt.ItemId
                        };
                    }

                    if (character.Equipment.Cloak != null)
                    {
                        equipment.Cloak = new Item
                        {
                            Id = character.Equipment.Cloak.Id,
                            ItemId = character.Equipment.Cloak.ItemId
                        };
                    }

                    if (character.Equipment.SphereMastery != null)
                    {
                        equipment.SphereMastery = new Item
                        {
                            Id = character.Equipment.SphereMastery.Id,
                            ItemId = character.Equipment.SphereMastery.ItemId
                        };
                    }

                    if (character.Equipment.SphereSoul != null)
                    {
                        equipment.SphereSoul = new Item
                        {
                            Id = character.Equipment.SphereSoul.Id,
                            ItemId = character.Equipment.SphereSoul.ItemId
                        };
                    }

                    if (character.Equipment.SphereDefense != null)
                    {
                        equipment.SphereDefense = new Item
                        {
                            Id = character.Equipment.SphereDefense.Id,
                            ItemId = character.Equipment.SphereDefense.ItemId
                        };
                    }

                    if (character.Equipment.SphereDestruction != null)
                    {
                        equipment.SphereDestruction = new Item
                        {
                            Id = character.Equipment.SphereDestruction.Id,
                            ItemId = character.Equipment.SphereDestruction.ItemId
                        };
                    }

                    if (character.Equipment.SphereLife != null)
                    {
                        equipment.SphereLife = new Item
                        {
                            Id = character.Equipment.SphereLife.Id,
                            ItemId = character.Equipment.SphereLife.ItemId
                        };
                    }

                    if (character.Equipment.SphereLuck != null)
                    {
                        equipment.SphereLuck = new Item
                        {
                            Id = character.Equipment.SphereLuck.Id,
                            ItemId = character.Equipment.SphereLuck.ItemId
                        };
                    }

                    if (character.Equipment.SphereReincarnation != null)
                    {
                        equipment.SphereReincarnation = new Item
                        {
                            Id = character.Equipment.SphereReincarnation.Id,
                            ItemId = character.Equipment.SphereReincarnation.ItemId
                        };
                    }

                    if (character.Equipment.SphereCharacteristics != null)
                    {
                        equipment.SphereCharacteristics = new Item
                        {
                            Id = character.Equipment.SphereCharacteristics.Id,
                            ItemId = character.Equipment.SphereCharacteristics.ItemId
                        };
                    }

                    informationCharactersModel.Equipments.Add(equipment);
                }
            }

            return informationCharactersModel;
        }
    }
}