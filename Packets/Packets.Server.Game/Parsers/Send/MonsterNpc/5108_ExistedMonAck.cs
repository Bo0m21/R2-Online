using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Core.Utilities;
using Packets.Server.Game.Models.Send.MonsterNpc;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Parsers.Send.MonsterNpc
{
    /// <summary>
    ///     Parser for existed mon ack
    /// </summary>
    [ParserSend]
    public class ExistedMonAck
    {
        [ParserAction(PacketType.ExistedMonAck)]
        public byte[] Parsing(ExistedMonAckModel model)
        {
            FormationPackage formationPackage = new FormationPackage();

            formationPackage.AddUShort((ushort)model.NpcMonsters.Count);

            foreach (MonsterApiModel monsterNpc in model.NpcMonsters)
            {
                monsterNpc.Write(formationPackage);
            }

            return formationPackage.GetBytes();
        }
    }
}