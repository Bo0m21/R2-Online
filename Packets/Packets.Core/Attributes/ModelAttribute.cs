using System;
using Packets.Core.Enums;

namespace Packets.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModelAttribute : Attribute
    {
        public PacketType PacketType { get; }

        public ModelAttribute(PacketType packetType)
        {
            PacketType = packetType;
        }
    }
}
