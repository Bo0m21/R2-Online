using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Login.Models.Send
{
    /// <summary>
    ///     Error type server model
    /// </summary>
    [Model(PacketType.LoginServerError)]
    public class LoginServerErrorModel
    {
        public ServerErrorType ErrorType { get; set; }
    }

    /// <summary>
    ///     Server error type
    /// </summary>
    public enum ServerErrorType : uint
    {
        NoUser = 267425736,
        PasswordWrong = 2493403489,
        NoUserLoginAnother = 2412965047,
        IncorrectServer = 166780708
    }
}