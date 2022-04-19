using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model end jump
    /// </summary>
    [Model(PacketType.JumpEndCharacter)]
    public class JumpEndCharacterModel
    {
        public UniqueId SessionGameId { get; set; }
        public uint Action { get; set; }
        public float DirectionSight { get; set; }
    }
}