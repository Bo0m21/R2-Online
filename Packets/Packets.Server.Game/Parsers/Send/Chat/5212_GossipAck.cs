using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Chat;

namespace Packets.Server.Game.Parsers.Send.Chat
{
    /// <summary>
    ///     Parser for chat ack
    /// </summary>
    [ParserSend]
    public class GossipAck
    {
        [ParserAction(Core.Enums.PacketType.GossipAck)]
        public byte[] Parsing(GossipAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.UniqueIdentifier.Write(formationPackage);
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.FromName, 15));
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.ToName, 15));
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(model.Message, 101));

            return formationPackage.GetBytes();
        }
    }
}