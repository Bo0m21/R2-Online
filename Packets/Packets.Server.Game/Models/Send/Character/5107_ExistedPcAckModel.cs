using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    ///     Model existed pc
    /// </summary>
    [Model(PacketType.ExistedPcAck)]
    public class ExistedPcAckModel
    {
        public ExistedPcAckModel()
        {
            Character = new List<PublicPc>();
        }

        public List<PublicPc> Character { get; set; }
    }
}