using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model for send character
    /// </summary>
    [Model(PacketType.InformationCharacter)]
    public class InformationCharacterModel
    {
        public InformationCharacterModel()
        {
            Characters = new List<Character>();
            Equipments = new List<Equipment>();
        }

        public List<Character> Characters { get; set; }
        public List<Equipment> Equipments { get; set; }
    }

    /// <summary>
    ///     Model character
    /// </summary>
    public class Character
    {
        public int Id { get; set; }
        public byte Class { get; set; }
        public byte Gender { get; set; }
        public byte Head { get; set; }
        public byte Face { get; set; }

        public short Level { get; set; }
        public string Name { get; set; }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Int { get; set; }
        public int Chaotic { get; set; }

        public Vector3 Position { get; set; }
    }

    /// <summary>
    ///     Model equipment
    /// </summary>
    public class Equipment
    {
        public Item Weapon { get; set; }
        public Item Shield { get; set; }
        public Item Armor { get; set; }
        public Item FirstRing { get; set; }
        public Item SecondRing { get; set; }
        public Item Necklace { get; set; }
        public Item Boots { get; set; }
        public Item Gloves { get; set; }
        public Item Helmet { get; set; }
        public Item Belt { get; set; }
        public Item Cloak { get; set; }

        public Item SphereMastery { get; set; }
        public Item SphereSoul { get; set; }
        public Item SphereDefense { get; set; }
        public Item SphereDestruction { get; set; }
        public Item SphereLife { get; set; }
        public Item SphereLuck { get; set; }
        public Item SphereReincarnation { get; set; }
        public Item SphereCharacteristics { get; set; }
    }

    /// <summary>
    ///     Model item
    /// </summary>
    public class Item
    {
        public ulong Id { get; set; }
        public int ItemId { get; set; }
    }
}