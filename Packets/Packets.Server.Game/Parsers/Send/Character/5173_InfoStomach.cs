using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;



namespace Packets.Server.Game.Parsers.Send.Character
{
    class InfoStomach
    {
        [ParserAction(PacketType.InfoStomachAck)]
        public byte[] Parse(InfoStomachModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddInteger(model.Stomach);
            formationPackage.AddByte(model.StomachStatus);

            return formationPackage.GetBytes();
        }
    }
}
