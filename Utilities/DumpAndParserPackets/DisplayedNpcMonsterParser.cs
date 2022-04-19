namespace DumpAndParserPackets
{
    public static class DisplayedNpcMonsterParser
    {
        //public static IEnumerable<NpcMonsterModel> Parse(byte[] data)
        //{
        //    FormationPackage formationPackage = new FormationPackage(data);

        //    formationPackage.ReadShort();
        //    formationPackage.ReadShort();
        //    formationPackage.ReadShort();

        //    short count = formationPackage.ReadShort();

        //    for (int i = 0; i < count; i++)
        //    {
        //        NpcMonsterModel monsterNpc = new NpcMonsterModel(true);

        //        monsterNpc.Flag = formationPackage.ReadShort();
        //        monsterNpc.AttackSpeed = formationPackage.ReadShort();
        //        monsterNpc.MovingSpeed = formationPackage.ReadShort();
        //        formationPackage.ReadBytes(14);
        //        monsterNpc.UID.Read(formationPackage);
        //        monsterNpc.ParmNo = formationPackage.ReadUInteger();
        //        monsterNpc.Position.Read(formationPackage);
        //        monsterNpc.DirectionSight = formationPackage.ReadFloat();
        //        monsterNpc.MonsterId = formationPackage.ReadInteger();
        //        monsterNpc.TransformationId = formationPackage.ReadInteger();
        //        monsterNpc.Chaotic = formationPackage.ReadShort();
        //        monsterNpc.Level = formationPackage.ReadUShort();
        //        monsterNpc.Hp = formationPackage.ReadShort();
        //        monsterNpc.OwnerName = FormationPackageUtility.GetText(formationPackage.ReadBytes(15));
        //        monsterNpc.SummonType = formationPackage.ReadByte();
        //        formationPackage.ReadBytes(6);
        //        monsterNpc.OwnerPcNo = formationPackage.ReadInteger();
        //        monsterNpc.OwnerPcGuildNo = formationPackage.ReadUInteger();

        //        yield return monsterNpc;
        //    }
        //}
    }
}
