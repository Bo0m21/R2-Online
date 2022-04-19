using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Receive
{
    /// <summary>
    ///     Model for login user req
    /// </summary>
    [Model(PacketType.LoginUserReq)]
    public class LoginUserReqModel
    {
        public uint AccountId { get; set; }
        public int SessionId { get; set; }
        public string Password { get; set; }
    }
}