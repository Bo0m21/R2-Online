using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Character.Characteristics
{
    /// <summary>
    ///     Model characteristic in inventory
    /// </summary>
    [Model(PacketType.InventoryCharacteristic)]
    public class InventoryCharacteristicModel
    {
        public short DDd { get; set; }
        public short MDd { get; set; }
        public short RDd { get; set; }
        public short DPv { get; set; }
        public short MPv { get; set; }
        public short RPv { get; set; }
        public short DDv { get; set; }
        public short DHit { get; set; }
        public short RDv { get; set; }
        public short RHit { get; set; }
        public short MDv { get; set; }
        public short MHit { get; set; }
        public short Str { get; set; }
        public short Dex { get; set; }
        public short Int { get; set; }
        public short CriticalHit { get; set; }
        public short HpMax { get; set; }
        public short MpMax { get; set; }
    }
}