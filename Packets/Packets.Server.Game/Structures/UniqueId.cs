using Packets.Core.Utilities;
using Packets.Server.Game.Enums;

namespace Packets.Server.Game.Structures
{
    public class UniqueId
    {
        public uint Id { get; set; }
        public uint Class { get; set; }
        public uint Seq { get; set; }
        public uint IsSeq { get; set; }

        public UniqueId(UniqueIdentifierType type)
        {
            Class = (uint)type;
        }

        public void Read(FormationPackage formationPackage)
        {
            uint number = formationPackage.ReadUInteger();
            Id = number & 0xFFFFF;
            Class = (number >> 20) & 0x1F;
        }

        public void Write(FormationPackage formationPackage)
        {
            uint number = 0;
            number += 1;
            number <<= 3;
            number += 7;
            number <<= 5;
            number += Class;
            number <<= 20;
            number += Id;
            formationPackage.AddUInteger(number);
        }
    }
}
