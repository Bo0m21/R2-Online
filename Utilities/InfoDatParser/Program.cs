using System;
using Packets.Core.Utilities;

namespace InfoDatParser
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\sergeyneklyudov\Desktop\Info.dat");
            FormationPackage formationPackage = new FormationPackage(bytes);

            int len1 = formationPackage.GetBytes().Length;

            int count = formationPackage.ReadInteger();

            for (int i = 0; i < count; i++)
            {
                int int0 = formationPackage.ReadInteger();

                int size1 = formationPackage.ReadInteger();
                byte[] text1 = formationPackage.ReadBytes(size1);

                int int1 = formationPackage.ReadInteger();
                int int2 = formationPackage.ReadInteger();
                short short1 = formationPackage.ReadShort();
                short short2 = formationPackage.ReadShort();
                short short3 = formationPackage.ReadShort();

                int size2 = formationPackage.ReadInteger();
                byte[] text2 = formationPackage.ReadBytes(size2);

                int int3 = formationPackage.ReadInteger();
                int int4 = formationPackage.ReadInteger();
                short short34 = formationPackage.ReadShort();
                int size3 = formationPackage.ReadInteger();

                int size31 = formationPackage.ReadInteger();
                byte[] text3 = formationPackage.ReadBytes(size31);

                int size4 = formationPackage.ReadInteger();
                byte[] text4 = formationPackage.ReadBytes(size4);

                short short11 = formationPackage.ReadShort();
                byte short112 = formationPackage.ReadByte();
                int size14 = formationPackage.ReadInteger();
                short short412 = formationPackage.ReadShort();

                byte short1121 = formationPackage.ReadByte();
                short short1112 = formationPackage.ReadShort();
                int size1114 = formationPackage.ReadInteger();
                short short11112 = formationPackage.ReadShort();

                int size41 = formationPackage.ReadInteger();
                int size42 = formationPackage.ReadInteger();
                int size43 = formationPackage.ReadInteger();
                byte size44 = formationPackage.ReadByte();

                byte short22 = formationPackage.ReadByte();
                byte short23 = formationPackage.ReadByte();
                long short24 = formationPackage.ReadLong();
                byte short25 = formationPackage.ReadByte();

                byte short26 = formationPackage.ReadByte();
                byte short27 = formationPackage.ReadByte();
                byte short28 = formationPackage.ReadByte();
                byte short29 = formationPackage.ReadByte();

                short short211 = formationPackage.ReadShort();
                short short212 = formationPackage.ReadShort();
                short short2123 = formationPackage.ReadShort();
                short short2112 = formationPackage.ReadShort();

                byte short2121 = formationPackage.ReadByte();
                byte short2331 = formationPackage.ReadByte();
            }


            int len2 = formationPackage.GetBytes().Length;

            int count1 = formationPackage.ReadInteger();

            for (int i = 0; i < count1; i++)
            {
                int size41 = formationPackage.ReadInteger();
                int size42 = formationPackage.ReadInteger();
            }

            int len3 = formationPackage.GetBytes().Length;


            Console.WriteLine("Hello World!");
        }
    }
}
