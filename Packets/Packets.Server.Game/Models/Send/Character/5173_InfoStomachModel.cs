using Packets.Core.Attributes;
using Packets.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packets.Server.Game.Models.Send.Character
{
    /// <summary>
    /// Модель голода
    /// </summary>
    [Model(PacketType.InfoStomachAck)]
    public class InfoStomachModel
    {
        /// <summary>
        /// Актуальный голод
        /// </summary>
        public int Stomach { get; set; }

        /// <summary>
        /// Статус голода, ( >70, 70< )
        /// </summary>
        public byte StomachStatus { get; set; }
    }
}
