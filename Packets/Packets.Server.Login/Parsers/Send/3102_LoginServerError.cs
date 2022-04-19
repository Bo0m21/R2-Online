using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Login.Models.Send;

namespace Packets.Server.Login.Parsers.Send
{
    /// <summary>
    ///     Parser server error
    /// </summary>
    [ParserSend]
    public class LoginServerError
    {
        [ParserAction(PacketType.LoginServerError)]
        public byte[] Parsing(LoginServerErrorModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddUInteger((uint) model.ErrorType);

            return formationPackage.GetBytes();
        }
    }
}