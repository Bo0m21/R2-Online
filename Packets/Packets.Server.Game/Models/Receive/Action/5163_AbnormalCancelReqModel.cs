using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive.Action
{
    /// <summary>
    ///     Model for abnormal remove req
    /// </summary>
    [Model(PacketType.AbnormalRemoveReq)]
    public class AbnormalRemoveReqModel
    {
        public int Type { get; set; }
    }
}
