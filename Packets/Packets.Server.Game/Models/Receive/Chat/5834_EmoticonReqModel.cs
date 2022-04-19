using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Chat
{
    /// <summary>
    ///     Model for emoji req
    /// </summary>
    [Model(PacketType.EmoticonReq)]
    public class EmoticonReqModel
    {
        public int Type { get; set; }
    }
}