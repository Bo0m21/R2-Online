using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Character;

namespace Packets.Server.Game.Parsers.Receive.Character
{
    /// <summary>
    ///     Parser for do move req
    /// </summary>
    [ParserReceive]
    public class DoMoveReq
    {
        [ParserAction(PacketType.DoMoveReq)]
        public DoMoveReqModel Parsing(byte[] data)
        {
            DoMoveReqModel doMoveReqModel = new DoMoveReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            doMoveReqModel.Position.Read(formationPackage);
            doMoveReqModel.Direction = formationPackage.ReadFloat();
            doMoveReqModel.Action = formationPackage.ReadUInteger();
            doMoveReqModel.Flag = formationPackage.ReadByte();

            return doMoveReqModel;
        }
    }
}