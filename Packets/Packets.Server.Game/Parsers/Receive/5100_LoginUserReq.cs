using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive;

namespace Packets.Server.Game.Parsers.Receive
{
    /// <summary>
    ///     Parser for login user req
    /// </summary>
    [ParserReceive]
    public class LoginUserReq
    {
        [ParserAction(PacketType.LoginUserReq)]
        public LoginUserReqModel Parsing(byte[] data)
        {
            LoginUserReqModel loginUserReqModel = new LoginUserReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            loginUserReqModel.AccountId = formationPackage.ReadUInteger();
            loginUserReqModel.SessionId = formationPackage.ReadInteger();
            formationPackage.ReadBytes(4);
            loginUserReqModel.Password = FormationPackageUtility.GetText(formationPackage.ReadBytes(21), 0);

            return loginUserReqModel;
        }
    }
}