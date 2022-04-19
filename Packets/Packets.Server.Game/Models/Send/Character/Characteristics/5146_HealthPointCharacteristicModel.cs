using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Character.Characteristics
{
    /// <summary>
    ///     Model health and mana
    /// </summary>
    [Model(PacketType.HealthPointCharacteristic)]
    public class HealthPointCharacteristicModel
    {
        public int Hp { get; set; }
        public int Mp { get; set; }
    }
}