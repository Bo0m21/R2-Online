using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model complete create character
    /// </summary>
    [Model(PacketType.CompleteCreateCharacter)]
    public class CompleteCreateCharacterModel
    {
        public int CharacterId { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Int { get; set; }
    }
}