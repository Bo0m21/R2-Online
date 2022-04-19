using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.Character;

namespace Packets.Server.Game.Parsers.Send.Character
{
    [ParserSend]
    public class StopMoveCharacter
    {
        [ParserAction(Core.Enums.PacketType.StopMoveCharacter)]
        public byte[] Parse(StopMoveCharacterModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            model.SessionGameId.Write(formationPackage);
            model.Position.Write(formationPackage);
            formationPackage.AddByte(0); // Flag is always zero

            return formationPackage.GetBytes();
        }
    }
}
