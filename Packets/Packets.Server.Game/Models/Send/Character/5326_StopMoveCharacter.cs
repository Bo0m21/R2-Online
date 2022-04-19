using Packets.Core.Attributes;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    [Model(Core.Enums.PacketType.StopMoveCharacter)]
    public class StopMoveCharacterModel
    {
        public UniqueIdentifier SessionGameId { get; set; }
        public Vector3 Position { get; set; }
    }
}
