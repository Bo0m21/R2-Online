using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Npc;

namespace Packets.Server.Game.Parsers.Send.Npc
{
    /// <summary>
    ///     Parser for merchant list ack
    /// </summary>
    [ParserSend]
    public class ScrDialogNoMsg2Ack
    {
        [ParserAction(PacketType.ScrDialogNoMsg2Ack)]
        public byte[] Parsing(ScrDialogNoMsg2AckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.ScriptId);
            model.UniqueIdentifier.Write(formationPackage);
            formationPackage.AddInteger(model.Param);

            return formationPackage.GetBytes();
        }
    }
}