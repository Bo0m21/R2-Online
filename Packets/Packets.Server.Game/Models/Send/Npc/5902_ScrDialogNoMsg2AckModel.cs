using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Npc
{
    /// <summary>
    ///     Model for ack npc dialog
    /// </summary>
    [Model(PacketType.ScrDialogNoMsg2Ack)]
    public class ScrDialogNoMsg2AckModel
    {
        public int ScriptId { get; set; }

        /// <summary>
        ///     Unique Npc
        /// </summary>
        public UniqueId UniqueIdentifier { get; set; }
        public int Param { get; set; }
    }
}
