using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for exit map gbj ack
    /// </summary>
    [ParserSend]
    public class ExitMapGbjAck
    {
        [ParserAction(PacketType.ExitMapGbjAck)]
        public byte[] Parsing(ExitMapGbjAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.UniqueItemDrop.Write(formationPackage);
            formationPackage.AddByte((byte)(model.Why));

            return formationPackage.GetBytes();
        }
    }
}
