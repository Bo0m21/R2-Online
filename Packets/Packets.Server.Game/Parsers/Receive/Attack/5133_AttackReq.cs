using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Attack;

namespace Packets.Server.Game.Parsers.Receive.Attack
{
    /// <summary>
    ///     Parser for attack req
    /// </summary>
    [ParserReceive]
    public class AttackReq
    {
        [ParserAction(PacketType.AttackReq)]
        public AttackReqModel Parsing(byte[] data)
        {
            AttackReqModel attackReqModel = new AttackReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            attackReqModel.TargetSessionGameId.Read(formationPackage);
            attackReqModel.AttackType = formationPackage.ReadUShort();
            attackReqModel.AttackPosition.Read(formationPackage);
            attackReqModel.AttackFlag = formationPackage.ReadByte();

            return attackReqModel;
        }
    }
}