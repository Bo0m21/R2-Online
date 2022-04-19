using System.Collections.Generic;
using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send
{
    /// <summary>
    ///     Model complete enter world and items to inventory
    /// </summary>
    [Model(PacketType.CompleteEnterWorld)]
    public class CompleteEnterWorldModel
    {
        public CompleteEnterWorldModel()
        {
            Items = new List<Item>();
        }

        public UniqueIdentifier SessionGameId { get; set; }
        public Vector3 Position { get; set; }
        public short Reputation { get; set; }
        public List<Item> Items { get; set; }
        public short MoveRate { get; set; }
        public short AttackRate { get; set; }
    }
}