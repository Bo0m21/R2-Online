namespace DumpAndParserPackets
{

    class Program
    {
        static void Main(string[] args)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //string connectionsJson = File.ReadAllText(@"..\..\..\Dump5108.json");
            //List<ConnectionPacketModel> connectionsList = JsonConvert.DeserializeObject<List<ConnectionPacketModel>>(connectionsJson).Where(c => c.Opcode == "5108").ToList();


            //List<NpcMonsterModel> NpcMonsters = new List<NpcMonsterModel>();
            //foreach (ConnectionPacketModel conenction in connectionsList)
            //{
            //    foreach (NpcMonsterModel npc in DisplayedNpcMonsterParser.Parse(conenction.Data))
            //    {
            //        NpcMonsters.Add(npc);
            //    }
            //}

            //File.WriteAllText(@"..\..\..\NPCs.json", JsonConvert.SerializeObject(NpcMonsters.Where(x => x.UID.Class == 2), Formatting.Indented));
            //File.WriteAllText(@"..\..\..\Monsters.json", JsonConvert.SerializeObject(NpcMonsters.Where(x => x.UID.Class == 1), Formatting.Indented));

            //Console.WriteLine("Complete!!!");
        }
    }
}
