using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.MonsterNpc;

namespace Packets.Server.Game.Parsers.Send.MonsterNpc
{
    /// <summary>
    ///     Parser for entered mon ack
    /// </summary>
    [ParserSend]
    public class EnteredMonAck
    {
        [ParserAction(PacketType.EnteredMonAck)]
        public byte[] Parsing(EnteredMonAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.Monster.Write(formationPackage);
            formationPackage.AddByte(model.IsTeleport ? (byte)1 : (byte)0);
            formationPackage.AddByte(model.CntAbn);

            return formationPackage.GetBytes();
        }
    }
}