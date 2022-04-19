using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Login.Models.Receive
{
    /// <summary>
    ///     Model authorization client by login and password
    /// </summary>
    [Model(PacketType.AuthorizationLogin)]
    public class AuthorizationLoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}