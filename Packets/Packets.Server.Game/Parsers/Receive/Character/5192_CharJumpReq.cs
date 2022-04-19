using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Character;

namespace Packets.Server.Game.Parsers.Receive.Character
{
    /// <summary>
    ///     Parser for char jump req
    /// </summary>
    [ParserReceive]
    public class CharJumpReq
    {
        [ParserAction(PacketType.CharJumpReq)]
        public CharJumpReqModel Parsing(byte[] data)
        {
            CharJumpReqModel charJumpReqModel = new CharJumpReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            charJumpReqModel.Action = formationPackage.ReadUInteger();
            charJumpReqModel.MoveDirection = formationPackage.ReadFloat();

            return charJumpReqModel;
        }
    }
}