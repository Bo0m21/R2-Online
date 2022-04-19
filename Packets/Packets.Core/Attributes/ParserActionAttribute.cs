using System;
using Packets.Core.Enums;

namespace Packets.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ParserActionAttribute : Attribute
    {
        public PacketType PacketType { get; }

        public ParserActionAttribute(PacketType packetType)
        {
            PacketType = packetType;
        }
    }
}
