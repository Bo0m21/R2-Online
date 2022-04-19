using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Character;

namespace Packets.Server.Game.Parsers.Receive.Character
{
    /// <summary>
    ///     Parser for char direction req
    /// </summary>
    [ParserReceive]
    public class CharDirReq
    {
        [ParserAction(PacketType.CharDirReq)]
        public CharDirectionReqModel Parsing(byte[] data)
        {
            CharDirectionReqModel charDirReqModel = new CharDirectionReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            charDirReqModel.Direction = formationPackage.ReadFloat();

            return charDirReqModel;
        }
    }
}