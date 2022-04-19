using Packets.Core.Attributes;
using Packets.Core.Utilities;
using Packets.Core.Enums;
using Packets.Server.Game.Models.Send.Character;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Parsers.Send.Character
{
    /// <summary>
    ///     Парсер пакета отображенного персонажа
    /// </summary>
    [ParserSend]
    public class ExistedPcAck
    {
        [ParserAction(PacketType.ExistedPcAck)]
        public byte[] Parsing(ExistedPcAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddUShort((ushort)model.Character.Count);

            foreach (PublicPc publicPc in model.Character)
            {
                publicPc.Write(formationPackage);
            }

            return formationPackage.GetBytes();
        }
    }
}