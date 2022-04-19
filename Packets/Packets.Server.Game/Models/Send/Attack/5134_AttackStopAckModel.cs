﻿using Packets.Core.Attributes;
using Packets.Core.Enums;
using Packets.Server.Game.Enums;
using Packets.Server.Game.Structures;

namespace Packets.Server.Game.Models.Send.Attack
{
    /// <summary>
    ///     Model for attack stop ack
    /// </summary>
    [Model(PacketType.AttackStopAck)]
    public class AttackStopAckModel
    {
        public AttackStopAckModel()
        {
            OffenceSesionGameId = new UniqueIdentifier(UniqueIdentifierType.Player);
        }

        public UniqueIdentifier OffenceSesionGameId { get; set; }
    }
}