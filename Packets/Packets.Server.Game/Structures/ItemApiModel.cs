using Packets.Core.Utilities;

namespace Packets.Server.Game.Structures
{
    public class ItemApiModel
    {
        public byte Flag { get; set; }
        public ulong SerialNumber { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public uint EndTick { get; set; }
        public byte ItemStatus { get; set; }
        public short UseCount { get; set; }
        public uint EatTime { get; set; }
        public int TermOfEffectivity { get; set; }
        public byte ItemBind { get; set; }
        public byte Restore { get; set; }
        public byte Hole { get; set; }

        public void Read(FormationPackage formationPackage)
        {
            Flag = formationPackage.ReadByte();
            formationPackage.ReadBytes(7);
            SerialNumber = formationPackage.ReadULong();
            ItemId = formationPackage.ReadInteger();
            Count = formationPackage.ReadInteger();
            EndTick = formationPackage.ReadUInteger();
            ItemStatus = formationPackage.ReadByte();
            formationPackage.ReadBytes(1);
            UseCount = formationPackage.ReadShort();
            EatTime = formationPackage.ReadUInteger();
            formationPackage.ReadInteger();
            formationPackage.ReadUInteger();
            formationPackage.ReadUInteger();
            TermOfEffectivity = formationPackage.ReadInteger();
            ItemBind = formationPackage.ReadByte();
            Restore = formationPackage.ReadByte();
            Hole = formationPackage.ReadByte();
            formationPackage.ReadBytes(1);
        }

        public void Write(FormationPackage formationPackage)
        {
            formationPackage.AddByte(Flag);
            formationPackage.AddZeroBytes(7);
            formationPackage.AddULong(SerialNumber);
            formationPackage.AddInteger(ItemId);
            formationPackage.AddInteger(Count);
            formationPackage.AddUInteger(EndTick);
            formationPackage.AddByte(ItemStatus);
            formationPackage.AddZeroBytes(1);
            formationPackage.AddShort(UseCount);
            formationPackage.AddUInteger(EatTime);
            formationPackage.AddZeroBytes(4);
            formationPackage.AddZeroBytes(4);
            formationPackage.AddZeroBytes(4);
            formationPackage.AddInteger(TermOfEffectivity);
            formationPackage.AddByte(ItemBind);
            formationPackage.AddByte(Restore);
            formationPackage.AddByte(Hole);
            formationPackage.AddZeroBytes(1);
        }
    }
}
