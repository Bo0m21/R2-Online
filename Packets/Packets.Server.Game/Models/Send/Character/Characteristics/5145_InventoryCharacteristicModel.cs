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
        public short DDv { get; set; }
        public short MDv { get; set; }
        public short RDv { get; set; }
        public short DPv { get; set; }
        public short MPv { get; set; }
        public short RPv { get; set; }
        public short DDD { get; set; }
        public short DHit { get; set; }
        public short RDD { get; set; }
        public short RHit { get; set; }
        public short MDD { get; set; }
        public short MHit { get; set; }
        public short Str { get; set; }
        public short Dex { get; set; }
        public short Int { get; set; }
        public short CriticalHit { get; set; }
        public int HpMax { get; set; }
        public int MpMax { get; set; }
    }
}