using Packets.Server.Game.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game.Models.Game
{
    public class GObject
    {
        public UniqueId UniqueId { get; set; }
        public Vector3 PositionCur { get; set; }
    }
}
