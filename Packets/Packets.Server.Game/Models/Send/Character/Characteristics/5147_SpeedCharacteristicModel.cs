using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character.Characteristics
{
    /// <summary>
    ///     Model characteristic sped
    /// </summary>
    [Model(PacketType.SpeedCharacteristic)]
    public class SpeedCharacteristicModel
    {
        public short AttackRate { get; set; }
        public short MoveRate { get; set; }
        public UniqueId SessionGameId { get; set; }
    }
}