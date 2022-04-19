using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Login.Models.Receive;

namespace Packets.Server.Login.Parsers.Receive
{
    /// <summary>
    ///     Parser select server
    /// </summary>
    [ParserReceive]
    public class SelectServer
    {
        [ParserAction(PacketType.SelectServer)]
        public SelectServerModel Parsing(byte[] data)
        {
            SelectServerModel authorizationModel = new SelectServerModel();

            FormationPackage formationPackage = new FormationPackage(data);
            authorizationModel.AccountId = formationPackage.ReadInteger();
            authorizationModel.Login = FormationPackageUtility.GetText(formationPackage.ReadBytes(20), 0);
            authorizationModel.ServerId = formationPackage.ReadShort();

            return authorizationModel;
        }
    }
}