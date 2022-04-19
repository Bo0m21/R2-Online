using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Receive.Npc
{
    /// <summary>
    ///     Model for req npc dialog
    /// </summary>
    [Model(PacketType.ScriptProcReq)]
    public class ScriptProcReqModel
    {
        public ScriptProcReqModel()
        {
            UniqueIdentifier = new UniqueIdentifier(UniqueIdentifierType.Npc);
        }
        /// <summary>
        ///     Unique Npc
        /// </summary>
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public ScriptAction ScriptAction { get; set; }
        public int Param { get; set; }
    }
}
