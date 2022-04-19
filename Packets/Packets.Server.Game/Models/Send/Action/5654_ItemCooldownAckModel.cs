using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Action
{
    /// <summary>
    ///     Model cooldown ack
    /// </summary>
    [Model(PacketType.ItemCooldown)]
    public class ItemCooldownAckModel
    {
        public int ItemId { get; set; }
    }
}