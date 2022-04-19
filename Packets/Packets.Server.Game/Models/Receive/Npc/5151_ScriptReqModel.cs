using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Npc
{
    /// <summary>
    ///     Model for req npc dialog
    /// </summary>
    [Model(PacketType.ScriptReq)]
    public class ScriptReqModel
    {
        public ScriptReqModel()
        {
            UniqueIdentifier = new UniqueId(UniqueIdentifierType.Npc);
        }
        /// <summary>
        ///     Unique Npc
        /// </summary>
        public UniqueId UniqueIdentifier { get; set; }
        public int Param { get; set; }
    }
}
