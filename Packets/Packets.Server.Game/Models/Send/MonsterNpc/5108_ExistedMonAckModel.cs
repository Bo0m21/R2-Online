using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.MonsterNpc
{
    /// <summary>
    ///     Model for existed mon ack
    /// </summary>
    [Model(PacketType.ExistedMonAck)]
    public class ExistedMonAckModel
    {
        public ExistedMonAckModel()
        {
            NpcMonsters = new List<MonsterApiModel>();
        }

        public List<MonsterApiModel> NpcMonsters { get; set; }
    }
}