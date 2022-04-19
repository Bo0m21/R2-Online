using System.Linq;
using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер отправки информации о персонажах
    /// </summary>
    [ParserSend]
    public class InformationCharacters
    {
        [ParserAction(Core.Enums.PacketType.InformationCharacter)]
        public byte[] Parsing(InformationCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            // Не расшифрованные байты
            formationPackage.AddZeroBytes(1);

            // Информация о персонажах
            for (int i = 0; i < 3; i++)
            {
                Models.Send.Character.Character character = model.Characters.ElementAtOrDefault(i);

                if (character != null)
                {
                    // TODO Изменить модель и вытягивать из базы
                    formationPackage.AddZeroBytes(1); // Есть ли значок гильдии
                    formationPackage.AddZeroBytes(3); // Align
                    formationPackage.AddInteger(character.Id);
                    formationPackage.AddByte(character.Class);
                    formationPackage.AddZeroBytes(3); // Align
                    formationPackage.AddByte(character.Gender);
                    formationPackage.AddByte(character.Head);
                    formationPackage.AddByte(character.Face);
                    formationPackage.AddZeroBytes(1); // Body
                    formationPackage.AddZeroBytes(4); // GuildNo
                    formationPackage.AddZeroBytes(4); // GuildMarkSeq
                    formationPackage.AddZeroBytes(4); // GuildGrade
                    formationPackage.AddZeroBytes(17); // GuildName
                    formationPackage.AddZeroBytes(1); // IsAtkTower
                    formationPackage.AddZeroBytes(2); // DfnsBenefitLv
                    formationPackage.AddZeroBytes(4); // DiscipleNo
                    formationPackage.AddZeroBytes(4); // DiscipleMemberType
                    formationPackage.AddZeroBytes(4); // Hp
                    formationPackage.AddZeroBytes(4); // Mp
                    formationPackage.AddZeroBytes(2); // Stomach
                    formationPackage.AddZeroBytes(1); // StomachStatus
                    formationPackage.AddZeroBytes(5); // Align
                    formationPackage.AddZeroBytes(8); // Exp
                    formationPackage.AddShort(character.Level);
                    formationPackage.AddBytes(FormationPackageUtility.GetBytes(character.Name, 15));
                    formationPackage.AddZeroBytes(3); // Align
                    formationPackage.AddZeroBytes(4); // ChaosBattleSide
                    formationPackage.AddZeroBytes(2); // FieldSvrNo
                    formationPackage.AddZeroBytes(2); // Align
                    formationPackage.AddInteger(character.Id);
                    formationPackage.AddZeroBytes(2); // FieldSvrSeq
                    formationPackage.AddZeroBytes(1); // EmblemOfHonorSeq
                    formationPackage.AddZeroBytes(1); // Align
                    formationPackage.AddShort(character.Level);
                    formationPackage.AddZeroBytes(1); // NationalFlagNo
                    formationPackage.AddZeroBytes(1); // EmblemOfHonorEffectSeq
                    formationPackage.AddZeroBytes(1); // TeamRankEffectSeq
                    formationPackage.AddZeroBytes(3); // Align
                    formationPackage.AddZeroBytes(4); // UTGWMatchGroup
                    formationPackage.AddZeroBytes(4); // Align
                    formationPackage.AddZeroBytes(8); // ExpToLevelUp
                    formationPackage.AddZeroBytes(4); // LastReceiptSection
                }
                else
                {
                    formationPackage.AddZeroBytes(144);
                }
            }

            // Информация о экипировке
            for (int i = 0; i < 3; i++)
            {
                Equipment equipment = model.Equipments.ElementAtOrDefault(i);

                if (equipment != null)
                {
                    // Оружие
                    formationPackage.AddULong(equipment.Weapon?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Weapon?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Щит
                    formationPackage.AddULong(equipment.Shield?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Shield?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Доспех
                    formationPackage.AddULong(equipment.Armor?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Armor?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Первое кольцо
                    formationPackage.AddULong(equipment.FirstRing?.Id ?? 0);
                    formationPackage.AddInteger(equipment.FirstRing?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Второе кольцо
                    formationPackage.AddULong(equipment.SecondRing?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SecondRing?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Ожерелье
                    formationPackage.AddULong(equipment.Necklace?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Necklace?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Ботинки
                    formationPackage.AddULong(equipment.Boots?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Boots?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Перчатки
                    formationPackage.AddULong(equipment.Gloves?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Gloves?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Шлем
                    formationPackage.AddULong(equipment.Helmet?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Helmet?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Ремень
                    formationPackage.AddULong(equipment.Belt?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Belt?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Плащ
                    formationPackage.AddULong(equipment.Cloak?.Id ?? 0);
                    formationPackage.AddInteger(equipment.Cloak?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты


                    // Сфера мастерства
                    formationPackage.AddULong(equipment.SphereMastery?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereMastery?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера души
                    formationPackage.AddULong(equipment.SphereSoul?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereSoul?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера защиты
                    formationPackage.AddULong(equipment.SphereDefense?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereDefense?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера разрушения
                    formationPackage.AddULong(equipment.SphereDestruction?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereDestruction?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера жизни
                    formationPackage.AddULong(equipment.SphereLife?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereLife?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера удачи
                    formationPackage.AddULong(equipment.SphereLuck?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereLuck?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера перевоплощения 
                    formationPackage.AddULong(equipment.SphereReincarnation?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereReincarnation?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    // Сфера характеристик
                    formationPackage.AddULong(equipment.SphereCharacteristics?.Id ?? 0);
                    formationPackage.AddInteger(equipment.SphereCharacteristics?.ItemId ?? 0);
                    formationPackage.AddZeroBytes(4); // Не расшифрованные байты

                    formationPackage.AddZeroBytes(16); // Servant(Питомец)
                }
                else
                {
                    formationPackage.AddZeroBytes(320);
                }
            }

            // Не расшифрованные байты - 12 байт на одного
            formationPackage.AddZeroBytes(36);

            // Сила персонажей
            for (int i = 0; i < 3; i++)
            {
                Models.Send.Character.Character character = model.Characters.ElementAtOrDefault(i);

                if (character != null)
                {
                    formationPackage.AddInteger(character.Str);
                }
                else
                {
                    formationPackage.AddZeroBytes(4);
                }
            }

            // Интелект персонажей
            for (int i = 0; i < 3; i++)
            {
                Models.Send.Character.Character character = model.Characters.ElementAtOrDefault(i);

                if (character != null)
                {
                    formationPackage.AddInteger(character.Int);
                }
                else
                {
                    formationPackage.AddZeroBytes(4);
                }
            }

            // Ловкость персонажей
            for (int i = 0; i < 3; i++)
            {
                Models.Send.Character.Character character = model.Characters.ElementAtOrDefault(i);

                if (character != null)
                {
                    formationPackage.AddInteger(character.Dex);
                }
                else
                {
                    formationPackage.AddZeroBytes(4);
                }
            }

            // Репутация персонажей
            for (int i = 0; i < 3; i++)
            {
                Models.Send.Character.Character character = model.Characters.ElementAtOrDefault(i);

                if (character != null)
                {
                    formationPackage.AddInteger(character.Reputation);
                }
                else
                {
                    formationPackage.AddZeroBytes(4);
                }
            }

            // Координаты персонажа
            for (int i = 0; i < 3; i++)
            {
                Models.Send.Character.Character character = model.Characters.ElementAtOrDefault(i);

                if (character != null)
                {
                    // Координаты персонажа
                    formationPackage.AddFloat(character.Position.X);
                    formationPackage.AddFloat(character.Position.Y);
                    formationPackage.AddFloat(character.Position.Z);
                }
                else
                {
                    formationPackage.AddZeroBytes(12);
                }
            }

            // Не расшифрованные байты
            formationPackage.AddZeroBytes(9);

            return formationPackage.GetBytes();
        }
    }
}