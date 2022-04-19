using Packets.Core.Attributes;
using Packets.Core.Enums;

namespace Packets.Server.Game.Models.Send.Settings
{
    /// <summary>
    ///     Model server time
    /// </summary>
    [Model(PacketType.ServerTime)]
    public class ServerTimeModel
    {
        public int ServerTick { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public short DayOfWeek { get; set; }
        public short Day { get; set; }
        public short Hour { get; set; }
        public short Minute { get; set; }
        public short Second { get; set; }
        public short Millisecond { get; set; }
    }
}