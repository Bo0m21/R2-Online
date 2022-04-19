using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model moved character
    /// </summary>
    [Model(PacketType.MovedCharacter)]
    public class MovedCharacterModel
    {
        public UniqueId SessionGameId { get; set; }
        public Vector3 Position { get; set; }
        public short MoveRate { get; set; }
        public byte Flag { get; set; }
        public float DirectionSight { get; set; }
        public uint Action { get; set; }
    }
}