using System;
using Packets.Core.Enums;

namespace Packets.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandlerActionAttribute : Attribute
    {
        public PacketType PacketType { get; }

        public HandlerActionAttribute(PacketType packetType)
        {
            PacketType = packetType;
        }
    }
}
