using Packets.Core.Utilities;
using Packets.Server.Game.Enums;

namespace Packets.Server.Game.Structures
{
    public class PublicPc
    {
        public PublicPc()
        {
            UniqueIdentifier = new UniqueIdentifier(UniqueIdentifierType.Player);
            Position = new Vector3();
        }

        public UniqueIdentifier UniqueIdentifier { get; set; }

        public short AttackRate { get; set; }
        public short MoveRate { get; set; }
        
        public byte AliveOrDead { get; set; }
        
        public byte Class { get; set; }
        public byte Gender { get; set; }
        public byte Head { get; set; }
        public byte Face { get; set; }
        
        public Vector3 Position { get; set; }
        
        public float Dir { get; set; }
        public int PkCnt { get; set; }
        public int Reputation { get; set; }
        public int ChaoticStatus { get; set; }
        
        public string Name { get; set; }
        public short Level { get; set; }
        
        public int Weapon { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Ring1 { get; set; }
        public int Ring2 { get; set; }
        public int Amulet { get; set; }
        public int Boot { get; set; }
        public int Glove { get; set; }
        public int Cap { get; set; }
        public int Belt { get; set; }
        public int Cloak { get; set; }
        public int ExpertnessMaterial { get; set; }
        public int SoulMaterial { get; set; }
        public int DefenceMaterial { get; set; }
        public int AttackMaterial { get; set; }
        public int LifeMaterial { get; set; }
        public int EventAMaterial { get; set; }
        public int EventBMaterial { get; set; }
        public int EventCMaterial { get; set; }
        public int Servant { get; set; }

        public void Read(FormationPackage formationPackage)
        {
            formationPackage.ReadBytes(4);
            AliveOrDead = formationPackage.ReadByte();
            formationPackage.ReadBytes(1);
            AttackRate = formationPackage.ReadShort();
            MoveRate = formationPackage.ReadShort();
            formationPackage.ReadBytes(14);

            UniqueIdentifier.Read(formationPackage);

            Class = formationPackage.ReadByte();
            Gender = formationPackage.ReadByte();
            Head = formationPackage.ReadByte();
            Face = formationPackage.ReadByte();

            formationPackage.ReadBytes(16);

            Position.Read(formationPackage);
            Dir = formationPackage.ReadFloat();

            PkCnt = formationPackage.ReadInteger();
            Reputation = formationPackage.ReadInteger();
            ChaoticStatus = formationPackage.ReadInteger();
            Name = FormationPackageUtility.GetText(formationPackage.ReadBytes(15), 0);
            formationPackage.ReadBytes(37);

            Weapon = formationPackage.ReadInteger();
            Shield = formationPackage.ReadInteger();
            Armor = formationPackage.ReadInteger();
            Ring1 = formationPackage.ReadInteger();
            Ring2 = formationPackage.ReadInteger();
            Amulet = formationPackage.ReadInteger();
            Boot = formationPackage.ReadInteger();
            Glove = formationPackage.ReadInteger();
            Cap = formationPackage.ReadInteger();
            Belt = formationPackage.ReadInteger();
            Cloak = formationPackage.ReadInteger();
            ExpertnessMaterial = formationPackage.ReadInteger();
            SoulMaterial = formationPackage.ReadInteger();
            DefenceMaterial = formationPackage.ReadInteger();
            AttackMaterial = formationPackage.ReadInteger();
            LifeMaterial = formationPackage.ReadInteger();
            EventAMaterial = formationPackage.ReadInteger();
            EventBMaterial = formationPackage.ReadInteger();
            EventCMaterial = formationPackage.ReadInteger();
            Servant = formationPackage.ReadInteger();

            formationPackage.ReadBytes(4);

            Level = formationPackage.ReadShort();

            formationPackage.ReadBytes(22);
        }

        public void Write(FormationPackage formationPackage)
        {
            formationPackage.AddZeroBytes(4);
            formationPackage.AddByte(AliveOrDead);
            formationPackage.AddZeroBytes(1);
            formationPackage.AddShort(AttackRate);
            formationPackage.AddShort(MoveRate);
            formationPackage.AddZeroBytes(14);

            UniqueIdentifier.Write(formationPackage);

            formationPackage.AddByte(Class);
            formationPackage.AddByte(Gender);
            formationPackage.AddByte(Head);
            formationPackage.AddByte(Face);
            formationPackage.AddZeroBytes(16);

            Position.Write(formationPackage);
            formationPackage.AddFloat(Dir);

            formationPackage.AddInteger(PkCnt);
            formationPackage.AddInteger(Reputation);
            formationPackage.AddInteger(ChaoticStatus);
            formationPackage.AddBytes(FormationPackageUtility.GetBytes(Name, 15));
            formationPackage.AddZeroBytes(37);

            formationPackage.AddInteger(Weapon);
            formationPackage.AddInteger(Shield);
            formationPackage.AddInteger(Armor);
            formationPackage.AddInteger(Ring1);
            formationPackage.AddInteger(Ring2);
            formationPackage.AddInteger(Amulet);
            formationPackage.AddInteger(Boot);
            formationPackage.AddInteger(Glove);
            formationPackage.AddInteger(Cap);
            formationPackage.AddInteger(Belt);
            formationPackage.AddInteger(Cloak);
            formationPackage.AddInteger(ExpertnessMaterial);
            formationPackage.AddInteger(SoulMaterial);
            formationPackage.AddInteger(DefenceMaterial);
            formationPackage.AddInteger(AttackMaterial);
            formationPackage.AddInteger(LifeMaterial);
            formationPackage.AddInteger(EventAMaterial);
            formationPackage.AddInteger(EventBMaterial);
            formationPackage.AddInteger(EventCMaterial);
            formationPackage.AddInteger(Servant);

            formationPackage.AddZeroBytes(4);
            formationPackage.AddShort(Level);

            formationPackage.AddZeroBytes(22);
        }
    }
}
