using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Inventory;

namespace Packets.Server.Game.Parsers.Send.Inventory
{
    /// <summary>
    ///     Parser for info weight
    /// </summary>
    [ParserSend]
    public class InfoWeightAck
    {
        [ParserAction(PacketType.InfoWeightAck)]
        public byte[] Parsing(InfoWeightAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.MaxWeight);
            formationPackage.AddInteger(model.Weight);
            formationPackage.AddByte(model.WeightStatus);

            return formationPackage.GetBytes();
        }
    }
}
