using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Inventory
{
    /// <summary>
    ///     Model for reinforce Nak
    /// </summary>
    [Model(PacketType.ReinforceNak1)]
    public class ReinforceNak1Model
    {
        public byte IsDestroy { get; set; }
        public ulong SerialNumber { get; set; }
    }
}
