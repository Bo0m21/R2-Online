using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Login.Models.Receive;

namespace Packets.Server.Login.Parsers.Receive
{
    /// <summary>
    ///     Parser authorization by login and password
    /// </summary>
    [ParserReceive]
    public class AuthorizationLogin
    {
        [ParserAction(PacketType.AuthorizationLogin)]
        public AuthorizationLoginModel Parsing(byte[] data)
        {
            AuthorizationLoginModel authorizationLoginModel = new AuthorizationLoginModel
            {
                Login = GetLogin(data),
                Password = GetPassword(data)
            };

            return authorizationLoginModel;
        }

        private string GetLogin(byte[] data)
        {
            byte codeLogin = data[256];
            codeLogin = (byte) (codeLogin / 8);

            int offsetLogin;
            switch (codeLogin)
            {
                case 0:
                    offsetLogin = 151;
                    break;
                case 1:
                    offsetLogin = 37;
                    break;
                case 2:
                    offsetLogin = 87;
                    break;
                case 3:
                    offsetLogin = 336;
                    break;
                case 4:
                    offsetLogin = 129;
                    break;
                case 5:
                    offsetLogin = 289;
                    break;
                case 6:
                    offsetLogin = 172;
                    break;
                case 7:
                    offsetLogin = 199;
                    break;
                default:
                    offsetLogin = 220;
                    break;
            }

            return FormationPackageUtility.GetText(data, offsetLogin);
        }

        private string GetPassword(byte[] data)
        {
            byte codePassword = data[81];
            codePassword = (byte) (codePassword / 2);

            int offsetPassword;
            switch (codePassword)
            {
                case 0:
                    offsetPassword = 260;
                    break;
                case 1:
                    offsetPassword = 60;
                    break;
                case 2:
                    offsetPassword = 108;
                    break;
                case 3:
                    offsetPassword = 4;
                    break;
                case 4:
                    offsetPassword = 314;
                    break;
                case 5:
                    offsetPassword = 357;
                    break;
                default:
                    offsetPassword = 390;
                    break;
            }

            return FormationPackageUtility.GetText(data, offsetPassword);
        }
    }
}