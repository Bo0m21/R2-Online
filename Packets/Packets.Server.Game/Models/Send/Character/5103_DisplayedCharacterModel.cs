using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model displayed character
    /// </summary>
    [Model(PacketType.DisplayedCharacter)]
    public class DisplayedCharacterModel
    {
        public PublicPc Character { get; set; }

        public bool IsTeleport { get; set; }
    }
}