using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Receive.Action;
using System;

namespace Packets.Server.Game.Parsers.Receive.Attack
{
    /// <summary>
    ///     Parser for use skill pack req
    /// </summary>
    [ParserReceive]
    public class UseSkillPackReq
    {
        [ParserAction(PacketType.UseSkillPackReq)]
        public UseSkillPackReqModel Parsing(byte[] data)
        {
            UseSkillPackReqModel useSkillPackReqModel = new UseSkillPackReqModel();

            FormationPackage formationPackage = new FormationPackage(data);
            useSkillPackReqModel.SkillId = formationPackage.ReadInteger();
            useSkillPackReqModel.TargetUniqueId.Read(formationPackage);
            useSkillPackReqModel.IsTeam = formationPackage.ReadByte();

            return useSkillPackReqModel;
        }
    }
}