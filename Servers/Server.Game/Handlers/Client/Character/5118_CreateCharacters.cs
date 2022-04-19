using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Database.Interfaces;
using Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Game.Handlers.Client.Character
{
    /// <summary>
    ///     Обработчик пакета создания персонажа
    /// </summary>
    public class CreateCharacters : AcHandler<CreateCharactersModel>
    {
        public override int Code { get; set; } = 5118;

        public override IEnumerable<int> Treatment(ConnectionModel connection, CreateCharactersModel model)
        {
            ServiceProvider serviceProvider = Program.ServiceCollection.BuildServiceProvider();

            using (IDatabaseContext databaseContext = serviceProvider.GetService<IDatabaseContext>())
            {
                IQueryable<CharacterModel> characters = databaseContext.Characters.Where(c => c.AccountId == connection.AccountId);

                if (characters.Count() >= 3)
                {
                    connection.ErrorCode = (uint) ServerError.NoCharInvalidSlot;
                    return new List<int> {1102};
                }

                CharacterModel characterSlot = characters.FirstOrDefault(c => c.SlotNumber == model.SlotNumber);

                if (characterSlot != null)
                {
                    connection.ErrorCode = (uint) ServerError.NoUserCharSlotBusy;
                    return new List<int> {1102};
                }

                CharacterModel characterName = databaseContext.Characters.FirstOrDefault(c => c.Name == model.Name);

                if (characterName != null)
                {
                    connection.ErrorCode = (uint) ServerError.NoCharAlreadyExistNm;
                    return new List<int> {1102};
                }

                // Создание персонажа
                CharacterModel character = new CharacterModel
                {
                    AccountId = connection.AccountId,
                    Name = model.Name,
                    Level = 1,
                    SlotNumber = model.SlotNumber,
                    ClassId = (byte) model.ClassId,
                    Gender = model.Gender,
                    TypeHairStyle = model.TypeHairStyle,
                    TypeFace = model.TypeFace,
                    CreateDate = DateTime.Now
                };

                // Заполнение основынх характеристик персонажа
                if (model.ClassId == CharacterClass.Knight) // Рыцарь
                {
                    character.Attack = 3;
                    character.Defence = 1;
                    character.Force = 15;
                    character.Adroitness = 10;
                    character.Intelligence = 10;

                    character.HealthPoint = 93;
                    character.HealthPointMax = 93;
                    character.MagicPoint = 51;
                    character.MagicPointMax = 51;

                    character.SpeedAttack = 800;
                    character.SpeedRun = 350;

                    // Координаты начальной точки
                    character.CoordinateX = 687549f;
                    character.CoordinateZ = 13432.3f;
                    character.CoordinateY = 10135f;
                }
                else if (model.ClassId == CharacterClass.Ranger) // Рейджер
                {
                    character.Defence = 1;
                    character.Force = 10;
                    character.Adroitness = 15;
                    character.Intelligence = 10;

                    character.HealthPoint = 76;
                    character.HealthPointMax = 76;
                    character.MagicPoint = 51;
                    character.MagicPointMax = 51;

                    character.SpeedAttack = 800;
                    character.SpeedRun = 350;

                    // Координаты начальной точки
                    character.CoordinateX = 744517.4f;
                    character.CoordinateZ = 22199.07f;
                    character.CoordinateY = 60425.5f;
                }
                else if (model.ClassId == CharacterClass.Magician) // Маг
                {
                    character.Defence = 1;
                    character.Force = 12;
                    character.Adroitness = 12;
                    character.Intelligence = 12;

                    character.HealthPoint = 83;
                    character.HealthPointMax = 83;
                    character.MagicPoint = 56;
                    character.MagicPointMax = 56;

                    character.SpeedAttack = 800;
                    character.SpeedRun = 350;

                    // Координаты начальной точки
                    character.CoordinateX = 788935.9f;
                    character.CoordinateZ = 13894.15f;
                    character.CoordinateY = 689347.7f;
                }
                else if (model.ClassId == CharacterClass.Assassin) // Ассасин
                {
                    character.Defence = 1;
                    character.Force = 12;
                    character.Adroitness = 13;
                    character.Intelligence = 10;

                    character.HealthPoint = 83;
                    character.HealthPointMax = 83;
                    character.MagicPoint = 51;
                    character.MagicPointMax = 51;

                    character.SpeedAttack = 800;
                    character.SpeedRun = 350;

                    // Координаты начальной точки
                    character.CoordinateX = 696802f;
                    character.CoordinateZ = 12019f;
                    character.CoordinateY = 113712f;
                }
                else if (model.ClassId == CharacterClass.Summoner) // Призыватель
                {
                    character.Defence = 1;
                    character.Force = 12;
                    character.Adroitness = 12;
                    character.Intelligence = 11;

                    character.HealthPoint = 83;
                    character.HealthPointMax = 83;
                    character.MagicPoint = 53;
                    character.MagicPointMax = 53;

                    character.SpeedAttack = 1000;
                    character.SpeedRun = 350;

                    // Координаты начальной точки
                    character.CoordinateX = 788900f;
                    character.CoordinateZ = 13893.5f;
                    character.CoordinateY = 689343f;
                }

                // TODO Для разработки
                character.SpeedRun = 1000;
                character.CoordinateX = 358777f;
                character.CoordinateZ = 15610f;
                character.CoordinateY = 300150f;

                // Создание экипировки
                character.Equipment = new EquipmentModel();

                databaseContext.Characters.Add(character);
                databaseContext.SaveChanges();

                return new List<int> {5119};
            }
        }
    }
}