using Packets.Core.Utilities;
using Packets.Server.Game.Enums;

namespace Packets.Server.Game.Structures
{
    public class Monster
    {
        public Monster()
        {
            UniqueIdentifier = new UniqueIdentifier(UniqueIdentifierType.Monster);
            Position = new Vector3();
        }

        public short AliveOrDead { get; set; }
        public short AttackRate { get; set; }
        public short MoveRate { get; set; }
        public UniqueIdentifier UniqueIdentifier { get; set; }
        public uint ParmNo { get; set; }
        public Vector3 Position { get; set; }
        public float DirectionSight { get; set; }
        public int MonsterId { get; set; }
        public int TransformationId { get; set; }
        public short Reputation { get; set; }
        public ushort Level { get; set; }
        public short Hp { get; set; }
        public string OwnerName { get; set; }
        public byte SummonType { get; set; }
        public int OwnerPcNo { get; set; }
        public uint OwnerPcGuildNo { get; set; }

        public void Read(FormationPackage formationPackage)
        {
            AliveOrDead = formationPackage.ReadShort();
            AttackRate = formationPackage.ReadShort();
            MoveRate = formationPackage.ReadShort();
            formationPackage.ReadBytes(14);
            UniqueIdentifier.Read(formationPackage);
            ParmNo = formationPackage.ReadUInteger();
            Position.Read(formationPackage);
            DirectionSight = formationPackage.ReadFloat();
            MonsterId = formationPackage.ReadInteger();
            TransformationId = formationPackage.ReadInteger();
            Reputation = formationPackage.ReadShort();
            Level = formationPackage.ReadUShort();
            Hp = formationPackage.ReadShort();
            OwnerName = FormationPackageUtility.GetText(formationPackage.ReadBytes(15), 0);
            SummonType = formationPackage.ReadByte();
            formationPackage.ReadBytes(6);
            OwnerPcNo = formationPackage.ReadInteger();
            OwnerPcGuildNo = formationPackage.ReadUInteger();
        }

        public void Write(FormationPackage formationPackage)
        {
            formationPackage.AddShort(AliveOrDead);
            formationPackage.AddShort(AttackRate);
            formationPackage.AddShort(MoveRate);
            formationPackage.AddZeroBytes(14);
            UniqueIdentifier.Write(formationPackage);
            formationPackage.AddUInteger(ParmNo);
            Position.Write(formationPackage);
            formationPackage.AddFloat(DirectionSight);
            formationPackage.AddInteger(MonsterId);
            formationPackage.AddInteger(TransformationId);
            formationPackage.AddShort(Reputation);
            formationPackage.AddUShort(Level);
            formationPackage.AddShort(Hp);
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(OwnerName, 15));
            formationPackage.AddByte(SummonType);
            formationPackage.AddZeroBytes(6);
            formationPackage.AddInteger(OwnerPcNo);
            formationPackage.AddUInteger(OwnerPcGuildNo);
        }
    }
}
