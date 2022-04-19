using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Login.Models.Receive
{
    /// <summary>
    ///     Select server model
    /// </summary>
    [Model(PacketType.SelectServer)]
    public class SelectServerModel
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public short ServerId { get; set; }
    }
}