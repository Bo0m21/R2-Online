﻿using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Attack
{
    /// <summary>
    ///     Model for attack ack
    /// </summary>
    [Model(PacketType.AttackAck)]
    public class AttackAckModel
    {
        public AttackAckModel()
        {
            OffenseSessionGameId = new UniqueId(UniqueIdentifierType.Player);
            DefenseSessionGameId = new UniqueId(UniqueIdentifierType.Player);
            OffensePosition = new Vector3();
        }

        public UniqueId OffenseSessionGameId { get; set; }
        public UniqueId DefenseSessionGameId { get; set; }
        public TypeHit TypeHit { get; set; }
        public Vector3 OffensePosition { get; set; }
        public short HpAttacked { get; set; }
    }

    /// <summary>
    ///     Type hit
    /// </summary>
    public enum TypeHit : byte
    {
        Miss = 0x00,
        Hit = 0x01,
        Crit = 0x02
    }
}